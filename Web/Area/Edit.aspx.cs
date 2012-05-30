using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

/// <summary>
/// 价格初始化: 
/// 1)创建一个区域
/// 2)创建所有产品 
/// 3)为所有产品指定该区域的价格.
/// 4)之后创建的
/// 
/// </summary>
public partial class Area_Edit : System.Web.UI.Page
{
    DALArea dalArea = new DALArea();

    string areaid;
    AreaInfo ai;
    protected void Page_Load(object sender, EventArgs e)
    {
        areaid = Request["AreaID"];
        if (!IsPostBack)
        {

            if (areaid != null)
            {

                BindArea();
            }
            else
            {
                btnDelete.Visible = false;
                divSetPrice.Visible = false;
            }
        }
    }

    private void BindArea()
    {
        IList<AreaInfo> ais = dalArea.GetAreas();
        ddlarea.DataTextField = "AreaName";
        ddlarea.DataValueField = "AreaID";
        ddlarea.DataSource = ais;
        ddlarea.DataBind();

        ai = dalArea.GetByAreaID(new Guid(areaid));
        tbOrderNo.Text = ai.OrderNO.ToString();
        tbAreaName.Text = ai.AreaName;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        AreaInfo areainfo = new AreaInfo();
        if (areaid == null)
        {
            areainfo.AreaID = Guid.Empty;
        }
        else
        {
            areainfo.AreaID = new Guid(areaid);
        }
        areainfo.OrderNO = Convert.ToInt32(tbOrderNo.Text);
        areainfo.AreaName = tbAreaName.Text;
        areainfo.DeleteFlag = false;
        dalArea.Save(areainfo);

        Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Shop/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (dalArea.Delete(new Guid(areaid)))
        {
            Session[WebHint.Web_Hint] = new WebHint("删除成功", "/Shop/Default.aspx", HintFlag.跳转);
        }
        else
        {
            Session[WebHint.Web_Hint] = new WebHint("该区域下还有门店,不能删除", "#", HintFlag.错误);
        }
        Response.Redirect(WebHint.HintURL);
    }
    protected void btnSetPrice_Click(object sender, EventArgs e)
    {
        //设置产品价格
        if (ddlarea.SelectedValue.ToUpper() == areaid.ToUpper())
        {
            Session[WebHint.Web_Hint] = new WebHint("不能复制本区域的价格", "#", HintFlag.错误);
            Response.Redirect(WebHint.HintURL);
        }

        //价格复制

    }
}