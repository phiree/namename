<%@ WebHandler Language="C#" Class="ShopUserDelete" %>

using System;
using System.Web;
using NameName.DAL;
using NameName.Model;

public class ShopUserDelete : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        new DALUser().RemoveUserFromShop(context.Request["UserName"]);
        context.Response.Write("OK");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}