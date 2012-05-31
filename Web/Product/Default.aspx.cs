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
            DALProInfo dpi = new DALProInfo();
            IList<ProInfo> ps = dpi.GetPros();
            GridView1.DataSource = ps;
            GridView1.DataBind();
        }
    }
}