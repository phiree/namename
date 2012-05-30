<%@ WebHandler Language="C#" Class="ShopUserSetManager" %>

using System;
using System.Web;
using NameName.DAL;
using NameName.Model;

public class ShopUserSetManager : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        new DALShopInfo().SetManager( context.Request["username"]);

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