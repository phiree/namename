using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NameName.Model;
using NameName.DAL;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebUserCookie.ClearCookie();

        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        UserInfo u = new DALUser().GetByUserName(username.Value);
        if (u != null)
        {
            if (password.Value != u.Pwd)
            {
                Session[WebHint.Web_Hint] = new WebHint("登录失败,密码错误", "#", HintFlag.错误);
                Response.Redirect("Hint.aspx");
            }
            else
            {
                //账本判断
                new DALAccount().AccountInit();

                //记录用户信息
                new WebUserCookie(WebUserCookie.CookierUser).WriteCookies(new UserCookieInfo(u.UserName, u.TrueName, u.RightSet));

                //跳转到页面
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Session[WebHint.Web_Hint] = new WebHint("登录失败,没有这个用户名", "#", HintFlag.错误);
            Response.Redirect("Hint.aspx");
        }

    }
}
