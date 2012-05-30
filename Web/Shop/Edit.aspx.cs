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
            ddlarea.SelectedValue = si.AreaID.ToString();
            tbAddress.Text = si.Address;
            tbTel.Text = si.Tel;
            tbFax.Text = si.Fax;
            cbIsCenter.Checked = si.IsCenter;
        }
        else
        {
            btnDelete.Visible = divShopUser.Visible = false;
        }
    }

    private void BindArea()
    {
        DALArea da = new DALArea();
        IList<AreaInfo> ais = da.GetAreas();
        ddlarea.DataTextField = "AreaName";
        ddlarea.DataValueField = "AreaID";
        ddlarea.DataSource = ais;
        ddlarea.DataBind();
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
        //判断门店下面是否有人

        dsi.Delete(new Guid(shopid));
        Session[WebHint.Web_Hint] = new WebHint("删除成功", "/Shop/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }
}