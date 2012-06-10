using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;
public partial class Store_ShopDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindList();
    }

    private void BindList()
    {
        GridView1.DataSource = BuildTestData();
        GridView1.DataBind();
    }

    private List<Shop_Store> BuildTestData()
    {
        List<Shop_Store> details = new List<Shop_Store>();
        for (int i = 0; i < 100; i++)
        {
            Shop_Store d = new Shop_Store();

            ShopInfo si = new ShopInfo();
            si.ShopName = "shopname" + i;
            d.ShopInfo = si;

            d.Account_Period = new Account_Period();
            d.ChkQty = d.CurrQty = d.ExpQty = d.ImpQty = i;
            details.Add(d);

        }
        return details;
    }
}