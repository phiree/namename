using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

/// <summary>
/// 指定工作人员  店长
/// </summary>
/// 

public partial class Shop_Edit : System.Web.UI.Page
{
    DALShopInfo dsi = new DALShopInfo();
    string shopid;
    protected void Page_Load(object sender, EventArgs e)
    {
        shopid = Request["shopid"];
        if (!IsPostBack)
        {
            BindArea();
            BindShopInfo();

        }
    }

    private void BindShopInfo()
    {
        if (shopid != null)
        {
            ShopInfo si = dsi.GetByShopID(new Guid(shopid));
            tbShopNo.Text = si.ShopNo;
            tbShopName.Text = si.ShopName;
            ddlarea.SelectedValue = si.AreaInfo.AreaID.ToString();
            tbAddress.Text = si.Address;
            tbTel.Text = si.Tel;
            tbFax.Text = si.Fax;
            cbIsCenter.Checked = si.IsCenter;

            //门店人员
            IList<UserInfo> uis = si.ShopUsers;

            GridView1.DataSource = uis;
            GridView1.DataBind();

        }
        else
        {
            btnDelete.Visible = divShopUser.Visible = false;
        }
    }
    DALArea da = new DALArea();
    private void BindArea()
    {

        IList<AreaInfo> ais = da.GetAreas();
        ddlarea.DataTextField = "AreaName";
        ddlarea.DataValueField = "AreaID";
        ddlarea.DataSource = ais;
        ddlarea.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShopInfo si = new ShopInfo();
        if (shopid == null)
        {
            si.ShopID = Guid.Empty;
        }
        else
        {
            si.ShopID = new Guid(shopid);
        }
        si.ShopNo = tbShopNo.Text;
        si.ShopName = tbShopName.Text;
        si.AreaInfo = da.GetByAreaID(new Guid(ddlarea.SelectedValue));
        si.Address = tbAddress.Text;
        si.Tel = tbTel.Text;
        si.Fax = tbFax.Text;
        si.IsCenter = cbIsCenter.Checked;

        si.DeleteFlag = false;
        dsi.Save(si);

        Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Shop/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //判断门店下面是否有人

        if (dsi.Delete(new Guid(shopid)))
        {
            Session[WebHint.Web_Hint] = new WebHint("删除成功", "/Shop/Default.aspx", HintFlag.跳转);
        }
        else
        {
            Session[WebHint.Web_Hint] = new WebHint("在门店下还有人员存在，不能删除", "#", HintFlag.跳转);
        }
        Response.Redirect(WebHint.HintURL);
    }
}