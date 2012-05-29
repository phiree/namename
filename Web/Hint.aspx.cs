using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Hint : System.Web.UI.Page
{
    public string urlreferrer = "#";
    public string flag = "wrong";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["refUrl"] = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
        }

        if (Session[WebHint.Web_Hint] == null)
        {
            mst.InnerHtml = "操作失败！";

            wrong.InnerHtml = "错误信息：<span style=\"color:Red;\">获取Session内容出错。</span>";
            right.Visible = false;
            flagimg.InnerHtml = "<img src=\"images/w64.png\" alt=\"出错啦！\" />";
            urlreferrer = "";

            backlink.InnerHtml = "<a href=\"javascript:void(0);\" onclick=\"window.history.back()\">3秒后，系统将自动跳转到原来的页面。如果系统没有自动跳转，请点击<span";
            backlink.InnerHtml += " style=\"color: Red;\">这里</span>。</a>";

            flag = "wrong";
        }
        else
        {
            switch (((WebHint)Session[WebHint.Web_Hint]).Flag)
            {
                case HintFlag.错误:
                    mst.InnerHtml = "操作失败！";

                    wrong.InnerHtml = "错误信息：<span style=\"color:Red;\">" + ((WebHint)Session["WebHint"]).Hintmsg + "</span>";
                    right.Visible = false;
                    question.Visible = false;
                    yesno.Visible = false;
                    flagimg.InnerHtml = "<img src=\"/images/w64.png\" alt=\"出错啦！\" />";
                    urlreferrer = "";

                    backlink.InnerHtml = "<a href=\"javascript:void(0);\" onclick=\"window.history.back()\">3秒后，系统将自动跳转到原来的页面。如果系统没有自动跳转，请点击<span";
                    backlink.InnerHtml += " style=\"color: Red;\">这里</span>。</a>";

                    flag = "wrong";
                    break;
                case HintFlag.跳转:
                    mst.InnerHtml = "操作成功！";

                    right.InnerHtml = "<span style=\"color:Red;\">" + ((WebHint)Session["WebHint"]).Hintmsg + "</span>";
                    wrong.Visible = false;
                    question.Visible = false;
                    yesno.Visible = false;
                    flagimg.InnerHtml = "<img src=\"/images/r64.png\" alt=\"操作成功！\" />";
                    urlreferrer = ((WebHint)Session["WebHint"]).Url;

                    backlink.InnerHtml = "<a href=\"" + urlreferrer + "\">3秒后，系统将自动跳转到相关页面。如果系统没有自动跳转，请点击<span";
                    backlink.InnerHtml += " style=\"color: Red;\">这里</span>。</a>";

                    flag = "right";
                    break;                
                default:
                    mst.InnerHtml = "操作失败！";

                    wrong.InnerHtml = "错误信息：<span style=\"color:Red;\">" + ((WebHint)Session["WebHint"]).Hintmsg + "</span>";
                    right.Visible = false;
                    question.Visible = false;
                    yesno.Visible = false;
                    flagimg.InnerHtml = "<img src=\"images/w64.png\" alt=\"出错啦！\" />";
                    urlreferrer = ((WebHint)Session["WebHint"]).Url;

                    backlink.InnerHtml = "<a href=\"" + urlreferrer + "\">3秒后，系统将自动跳转到原来的页面。如果系统没有自动跳转，请点击<span";
                    backlink.InnerHtml += " style=\"color: Red;\">这里</span>。</a>";
                    flag = "login";
                    break;
            }
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        Response.Redirect(((WebHint)Session[WebHint.Web_Hint]).Url.ToString());
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect(Session["refUrl"].ToString());
    }
    
}