using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for WebHint
/// </summary>
[Serializable]
public class WebHint
{
    public static string Web_Hint = "WebHint";
    public static string HintURL = "/Hint.aspx";

    public WebHint(string _hintMsg, string _url, HintFlag _flag)
    {
        hintmsg = _hintMsg;
        url = _url;
        flag = _flag;
    }

    string hintmsg;
    public string Hintmsg
    {
        get { return hintmsg; }
        set { hintmsg = value; }
    }

    string url;
    public string Url
    {
        get { return url; }
        set { url = value; }
    }

    HintFlag flag = HintFlag.错误;//错误、正确
    public HintFlag Flag
    {
        get { return flag; }
        set { flag = value; }
    }
}

public enum HintFlag
{
    错误 = 0,
    跳转 = 1,    
}
