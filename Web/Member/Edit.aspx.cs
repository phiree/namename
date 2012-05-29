using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.DAL;
using NameName.Model;
public partial class Member_Edit : System.Web.UI.Page
{
    string UserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = Request["username"];
        if (!IsPostBack)
        {
            BindDepart();
            BindRight();
            BindUser();
        }
    }

    private void BindUser()
    {

        //显示控制

    }

    private void BindDepart()
    {
        DALDepart dalDepart = new DALDepart();

        ddlDepart.DataSource = dalDepart.GetDeparts();
        ddlDepart.DataTextField = "DepartName";
        ddlDepart.DataValueField = "DepartId";
        ddlDepart.DataBind();
    }

    private void BindRight()
    {
        //zy
    }

    private void SaveUser()
    {

    }
    private void DeleteUser()
    { }

    private void InitPwd()
    {
    }

}