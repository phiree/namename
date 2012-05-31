using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

public partial class Member_UserEdit : System.Web.UI.Page
{
    UserCookieInfo uc;
    DALUser du = new DALUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        uc = new WebUserCookie(WebUserCookie.CookierUser).GetCookiesValues();

        if (!IsPostBack)
        {
            BindDepart();
            BindUserInfo();

        }
    }
    DALDepart dalDepart = new DALDepart();
    private void BindDepart()
    {
      

        ddlDepart.DataSource = dalDepart.GetDeparts();
        ddlDepart.DataTextField = "DepartName";
        ddlDepart.DataValueField = "DepartId";
        ddlDepart.DataBind();
    }

    private void BindUserInfo()
    {
        UserInfo u = du.GetByUserName(uc.UserName);
        tbusername.Text = u.UserName;
        tbTrueName.Text = u.TrueName;
        tbMobile.Text = u.Mobile;
        tbTel.Text = u.Tel;
        ddlDepart.SelectedValue = u.DepartInfo.DepartID.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserInfo u = du.GetByUserName(uc.UserName);
        u.TrueName = tbTrueName.Text;
        u.DepartInfo =dalDepart.GetById( new Guid(ddlDepart.SelectedValue));
        u.Tel = tbTel.Text;
        u.Mobile = tbMobile.Text;
        du.Save(u);
    }
}