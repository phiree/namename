using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;
/// <summary>
/// 页面功能:
/// 1)绑定一个门店所有商品(也就是一个区域)所有产品的库存信息,点击详情之后 查看每笔交易详情
/// 2)绑定所有产品
/// 
/// </summary>
public partial class Store_Default : System.Web.UI.Page
{
    public string DetailType = "1";//All: 全部门店查询,2:单个门店查询
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindShops();
            BindData();
        }
    }

    void BindData()
    {
        DetailType = ddlShops.SelectedValue == Guid.Empty.ToString() ? "1" : "2";
        string keyWord = tbxkeyword.Text;
        string shopId = ddlShops.SelectedValue;

        IList<Shop_Store> stores = BuildTestData();// new DALShopStore().GetList(shopId, keyWord, 0, 9999);
        dlShopStore.DataSource = stores;
        dlShopStore.DataBind();
      
    }
    /// <summary>
    /// 绑定 库存 
    /// </summary>
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      
        BindData();
    }

    private void BindShops()
    {
        ddlShops.DataSource = new DALShopInfo().GetShops();
        ddlShops.DataTextField = "ShopName";
        ddlShops.DataValueField = "ShopID";
        ddlShops.DataBind();
        ddlShops.Items.Insert(0,new ListItem("全部",Guid.Empty.ToString()));
    }
    private List<Shop_Store> BuildTestData()
    {
        List<Shop_Store> stores = new List<Shop_Store>();

        for (int i = 0; i < 100; i++)
        {
            Account_Period ap = new Account_Period();
            ap.AccountID = Guid.NewGuid();
            ap.BeginDate = DateTime.Now;
            ap.EndDate = DateTime.Now;

            ProInfo pi = new ProInfo();
            pi.Name = "name" + i;
            pi.Unit = "jin";
            ShopInfo si = new ShopInfo();
            si.ShopName = "name" + i;
          

            Shop_Store ss = new Shop_Store();
            
            ss.Account_Period = ap;
            ss.ChkQty = i;
            ss.CurrQty = i;
            ss.ExpQty = i;
            ss.Id = i;
            ss.ImpQty = ss.PreQty = i;
            ss.ProInfo = pi;
            ss.ShopInfo = si;
            stores.Add(ss);
        }

        return stores;
    }
    protected void ddlShops_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}