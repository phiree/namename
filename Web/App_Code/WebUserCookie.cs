using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///WebUserCookie 的摘要说明
/// </summary>
public class WebUserCookie
{
    public static string CookierUser = "NameName";

    HttpCookie cookie;
    string cookien;

    public WebUserCookie(string cookieName)
    {
        cookie = HttpContext.Current.Request.Cookies[cookieName];
        cookien = cookieName;
    }

    public static void ClearCookie()
    {
        HttpCookie aCookie;
        string cookieName;
        int limit = HttpContext.Current.Request.Cookies.Count;
        for (int i = 0; i < limit; i++)
        {
            cookieName = HttpContext.Current.Request.Cookies[i].Name;
            aCookie = new HttpCookie(cookieName);
            aCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(aCookie);
        }
    }

    public static void ClearCookie(string CookierName)
    {
        HttpCookie aCookie;
        aCookie = new HttpCookie(CookierName);
        aCookie.Expires = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.Cookies.Add(aCookie);
    }

    public UserCookieInfo GetCookiesValues()
    {
        //尝试获取Cookies
        UserCookieInfo cookieValue = null;
        if (cookie != null)
        {
            cookieValue = new UserCookieInfo();
            cookieValue.UserName = HttpUtility.UrlDecode(cookie.Values["UserName"]);
            cookieValue.TrueName = HttpUtility.UrlDecode(cookie.Values["TrueName"]);
            cookieValue.RoleSet = Convert.ToInt64(HttpUtility.UrlDecode(cookie.Values["RoleSet"]));
        }
        else
        {
            if (HttpContext.Current.Session[cookien] != null)
            {
                cookieValue = (UserCookieInfo)HttpContext.Current.Session[cookien];
            }
        }
        return cookieValue;
    }

    public void WriteCookies(UserCookieInfo values)
    {
        //创建cookies,写入初始数据
        cookie = new HttpCookie(cookien);
        cookie.Values.Add("UserName", HttpUtility.UrlEncode(values.UserName));
        cookie.Values.Add("TrueName", HttpUtility.UrlEncode(values.TrueName));
        cookie.Values.Add("RoleSet", HttpUtility.UrlEncode(values.RoleSet.ToString()));
        cookie.Expires = DateTime.Now.AddDays(1);
        HttpContext.Current.Response.Cookies.Add(cookie);
        HttpContext.Current.Session[cookien] = values;
    }
}

public class UserCookieInfo
{
    public UserCookieInfo()
    {

    }

    public UserCookieInfo(string username, string truename, long roleset)
    {
        userName = username;
        trueName = truename;
        roleSet = roleset;

    }

    long roleSet;
    public long RoleSet
    {
        get { return roleSet; }
        set { roleSet = value; }
    }

    string userName;


    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    string trueName;

    public string TrueName
    {
        get { return trueName; }
        set { trueName = value; }
    }

}
