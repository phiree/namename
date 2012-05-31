﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

public partial class Product_Edit : System.Web.UI.Page
{
    string proid;
    DALProInfo dpi = new DALProInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        proid = Request["ProID"];
        if (!IsPostBack)
        {
            BindProCate();
            BindProInfo();
        }
    }

    private void BindProInfo()
    {
        if (proid == null)
        {
            btnDelete.Visible = divPrice.Visible = false;
        }
        else
        {
            ProInfo pi = dpi.GetByProID(new Guid(proid));
            ddlProCate.SelectedValue = pi.ProCate;
            tbMemo.Text = pi.Memo;
            tbName.Text = pi.Name;
            tbUnit.Text = pi.Unit;
            UpLoadFile1.FileName = pi.PicName;


            //产品价格
            BindArea();
        }
    }

    DALArea da = new DALArea();
    private void BindArea()
    {
        IList<AreaInfo> ais = da.GetAreas();
        GridView1.DataSource = ais;
        GridView1.DataBind();
    }

    protected string GetPrice(object areaid)
    {
        ProPrice proprice = dpi.GetPrice(new Guid(proid), new Guid(areaid.ToString()));
        if (proprice == null)
            return "";
        else
            return proprice.Price.ToString("0.00");
    }

    private void BindProCate()
    {
        IList<string> cates = dpi.GetProCates();
        foreach (var cate in cates)
        {
            ddlProCate.Items.Add(cate);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ProInfo pro;
        if (proid == null)
        {
            pro = new ProInfo();

        }
        else
        {
            pro = dpi.GetByProID(new Guid(proid));
        }
        pro.Unit = tbUnit.Text;
        pro.ProCate = string.IsNullOrEmpty(tbProCate.Text) ? ddlProCate.SelectedValue : tbProCate.Text;
        pro.Name = tbName.Text;
        pro.Memo = tbMemo.Text;

        pro.PicName = UpLoadFile1.FileName;

        Guid pid = dpi.Save(pro);
        if (proid == null)
        {
            Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Product/edit.aspx?proid=" + pid, HintFlag.跳转);
        }
        else
        {
            Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Product/Default.aspx", HintFlag.跳转);
        }

        Response.Redirect(WebHint.HintURL);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnSavePrice_Click(object se, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                TextBox tbxPrice = row.FindControl("tbPrice") as TextBox;

                Guid areaId = new Guid(tbxPrice.Attributes["areaid"]);

                decimal? price;
                if (tbxPrice.Text == "")
                {
                    price = null;
                }
                else
                {
                    price = decimal.Parse(tbxPrice.Text);
                }

                dpi.SavePrice(new Guid(proid), areaId, price);
            }
        }

        Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Product/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }
}