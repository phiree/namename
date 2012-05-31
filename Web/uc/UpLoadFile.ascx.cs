using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

public partial class uc_UpLoadFile : System.Web.UI.UserControl
{
    public delegate bool DeleteImg();
    public event DeleteImg OnDeleteImg;

    public delegate void UpLoadAfter(string filename);
    public event UpLoadAfter OnUpLoadAfter;

    public string FileName
    {
        get
        {
            return HiddenField1.Value;
        }
        set
        {
            HiddenField1.Value = value;
            if (HiddenField1.Value.Trim() == "")
            {
                view.Visible = false;
                FileView.NavigateUrl = "#";
                divViewSmall.Visible = false;
                LinkButton1.Visible = false;
            }
            else
            {
                view.Visible = true;
                divViewSmall.Visible = true;
                LinkButton1.Visible = true;

                FileView.NavigateUrl = "/propic/imgsmall/" + HiddenField1.Value;
                divViewSmall.InnerHtml = "<img src='/propic/imgsmall/" + HiddenField1.Value + "' />";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lb.Text = "";
        }
    }

    protected void btnUpLoad_Click(object sender, EventArgs e)
    {
        if (fp.HasFile)
        {
            if (fp.FileBytes.Length > 10 * 1024 * 1024)
            {
                Session[WebHint.Web_Hint] = new WebHint("上传文件太大。请确保上传的文件不超过10M。", "#", HintFlag.跳转);
                Response.Redirect(WebHint.HintURL);
            }
            try
            {

                string filename = Guid.NewGuid().ToString() + fp.FileName.Substring(fp.FileName.LastIndexOf("."));
                HiddenField1.Value = filename;
                view.Visible = true;
                divViewSmall.Visible = true;
                divViewSmall.InnerHtml = "<img src='/propic/imgsmall/" + HiddenField1.Value + "' />";

                LinkButton1.Visible = true;
                fp.SaveAs(Server.MapPath("/propic/imgsmall/") + HiddenField1.Value);
                FileView.NavigateUrl = "/propic/imgsmall/" + HiddenField1.Value;
                lb.Text = "上传成功";



                //图片,需要生成缩略图
                if (!GetThumbnail(filename))
                {
                    lb.Text = "生成缩略图失败!请重新上传图片!";
                }


                if (OnUpLoadAfter != null)
                {
                    OnUpLoadAfter(Path.GetFileNameWithoutExtension(fp.FileName));
                }
            }
            catch (Exception ee)
            {
                lb.Text = "出错，错误信息:" + ee.ToString();
                return;
            }
        }
        else
        {
            lb.Text = "请选择需要上传的文件！";
        }
    }


    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="imgUrl">文件路径</param>
    /// <returns>返回生成成功与否</returns>
    private bool GetThumbnail(string fname)
    {
        //imgUrl = "83132e0d-4632-4fb7-91bf-3b2bfaebfa90.jpg";// "64eca27b-73a6-4418-8813-1b6b4caf679d.jpg";

        //如果已经存在小图片,就不要处理
        if (File.Exists(Server.MapPath("/propic/ImgSmall/" + fname)))
        {
            return false;
        }
        else
        {
            try
            {
                Bitmap originBmp = new Bitmap(Server.MapPath("/propic/ImgBig/" + fname));
                int w = 160;
                int h = 120;
                string[] osize = GetIMGSize(Server.MapPath("/propic/ImgBig/" + fname)).Split('*');

                double d = Convert.ToDouble(osize[0]) / Convert.ToDouble(osize[1]);

                if (d > 4.0 / 3.0)
                {
                    w = 160;
                    h = (int)(Convert.ToDouble(160) * 1.0 / d);
                }
                else
                {
                    h = 120;
                    w = (int)(Convert.ToDouble(120) * d);
                }
                Bitmap resizedBmp = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(resizedBmp);
                //设置高质量插值法   
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //设置高质量,低速度呈现平滑程度   
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //消除锯齿 
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(originBmp, new Rectangle(0, 0, w, h), new Rectangle(0, 0, originBmp.Width, originBmp.Height), GraphicsUnit.Pixel);

                resizedBmp.Save(Server.MapPath("/propic/ImgSmall/" + fname), ImageFormat.Jpeg);
                g.Dispose();
                resizedBmp.Dispose();
                originBmp.Dispose();
            }
            catch (Exception ee)
            {
                lb.Text = ee.Message;
            }

            return true;
        }
    }

    /// <summary>
    /// 获得图片的尺寸
    /// </summary>
    /// <param name="imgUrl"></param>
    /// <returns></returns>
    private string GetIMGSize(string imgUrl)
    {
        try
        {
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(Server.MapPath(imgUrl));
            return imgPhoto.Width.ToString() + "*" + imgPhoto.Height.ToString();
        }
        catch
        {
            return "160*120";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (OnDeleteImg != null)
        {
            if (OnDeleteImg())
            {
                lb.Text = "删除成功!";
            }
            else
                lb.Text = "删除失败!";
        }
    }

    public void ClearAll()
    {
        HiddenField1.Value = "";
        view.Visible = false;
        LinkButton1.Visible = false;
    }
}
