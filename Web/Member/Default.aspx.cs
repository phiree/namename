using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;
public partial class Member_Default : System.Web.UI.Page
{
    DALUser dalUser = new DALUser();
    DALDepart dalDepart = new DALDepart();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepart();
        }
    }

    private void BindDepart()
    {
        IList<DepartInfo> departs = dalDepart.GetDeparts();
        rptDepart.DataSource = departs;
        rptDepart.DataBind();
    }

    protected void rptDepart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)

        {
            DepartInfo depart = e.Item.DataItem as DepartInfo;
            Repeater rptUsers = e.Item.FindControl("rptUsers") as Repeater;

            IList<UserInfo> users = dalUser.GetUserByDepartment(depart.DepartID);

            rptUsers.DataSource = users;
            rptUsers.DataBind();
        }
    }
}