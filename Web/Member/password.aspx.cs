using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NameName.Model;
using NameName.DAL;

public partial class Member_password : System.Web.UI.Page
{
    UserCookieInfo uc;
    protected void Page_Load(object sender, EventArgs e)
    {
        uc = new WebUserCookie(WebUserCookie.CookierUser).GetCookiesValues();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (p2.Text != p3.Text)
        {
            Session[WebHint.Web_Hint] = new WebHint("两次输入的新密码不一致，请重新输入！", "#", HintFlag.错误);
            Response.Redirect(WebHint.HintURL);
        }
        DALUser du = new DALUser();
        
        UserInfo u = du.GetByUserName(uc.UserName);

        if (u.Pwd != p1.Text)
        {
            Session[WebHint.Web_Hint] = new WebHint("原密码输入错误！", "#", HintFlag.错误);
            Response.Redirect(WebHint.HintURL);
        }

        u.Pwd = p2.Text;
        du.Save(u);
        Session[WebHint.Web_Hint] = new WebHint("操作成功！", "Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }
}
