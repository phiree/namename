using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.DAL;
using NameName.Model;
using NameName.Model.Enums;
/// <summary>
/// 采购单列表
/// 筛选条件: 起至时间,状态,
/// </summary>
public partial class PurchaseList_Default : System.Web.UI.Page
{
    DALPurchase dp = new DALPurchase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BeginDate.Value = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            EndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            BindList();

            
        }

    }
    protected void btn_Click(object s, EventArgs e)
    {
        BindList();
    }

    private void BindList()
    {
        string begindate =  BeginDate.Value;
        string enddate = EndDate.Value;
        PurchaseState state=(PurchaseState)(Convert.ToInt32(rbl.SelectedValue) );

        IList<Pur_List> list =dp.GetList(begindate, enddate, state);
        rptPurList.DataSource = list;
        rptPurList.DataBind();
    }

    protected void lbAdd_Click(object sender, EventArgs e)
    {
        rbl.SelectedIndex = 0;

     UserCookieInfo   uc = new WebUserCookie(WebUserCookie.CookierUser).GetCookiesValues();

        dp.Create(uc.UserName);
        BindList();
    }
}