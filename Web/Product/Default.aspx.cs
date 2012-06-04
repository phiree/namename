using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

public partial class Product_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProduct(0);
            BindCates();
        }


    }
    DALProInfo dalPro = new DALProInfo();

    private void BindCates()
    {
       IList<string> cates= dalPro.GetProCates();
       rblCates.DataSource = cates;
       rblCates.DataBind();
    }
    private void BindProduct(int pageIndex)
    {

        int totalRecord;
        string cate = string.Empty;
        if (!cateAll.Checked)
        {
            cate = rblCates.SelectedValue;
        }

        int pageSize = pager.PageSize;
        IList<ProInfo> pros = dalPro.GetProsPaged(tbxProname.Text, cate, pageIndex, pageSize, out totalRecord);
        pager.RecordCount = totalRecord;
        GridView1.DataSource = pros;
        GridView1.DataBind();


    }
    protected void pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pager.CurrentPageIndex = e.NewPageIndex;
        BindProduct(e.NewPageIndex);
    }
    protected void rblCates_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProduct(0);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindProduct(0);
    }
}