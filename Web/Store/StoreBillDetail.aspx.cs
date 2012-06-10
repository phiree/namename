using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.DAL;
using NameName.Model;
/// <summary>
/// 一个商品详细的 进出 库详情
/// </summary>
public partial class Store_ProDetail : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {
        Guid proId = new Guid(Request["proid"]);
        BindDetail(proId);
    }
    void BindDetail(Guid proid)
    {
        GridView1.DataSource = BuildTestData();
        GridView1.DataBind();
    }

    private List<Shop_AccountDetail> BuildTestData()
    {
        List<Shop_AccountDetail> details = new List<Shop_AccountDetail>();
        for (int i = 0; i < 100; i++)
        {
            Shop_AccountDetail d = new Shop_AccountDetail();

            ShopInfo si = new ShopInfo();
            si.ShopName = "shopname" + i;
            d.ShopInfo = si;

            d.Account_Period = new Account_Period();
            d.BillDate = DateTime.Now;
            d.BillNO = "BillNo";
            d.ChkQty = d.CurrQty = d.ExpQty =d.ImpQty= i;
            details.Add(d);
            
        }
        return details;
    }
}