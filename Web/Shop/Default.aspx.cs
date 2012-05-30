using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

public partial class Shop_Default : System.Web.UI.Page
{
    DALArea da = new DALArea();
    DALShopInfo ds = new DALShopInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetData();
    }

    private void GetData()
    {
        tbShop.Rows.Clear();
        Common.CreateHeader("门店编码,名称,地址,电话,传真,总部仓库", tbShop, new int[] { });
        IList<AreaInfo> areas = da.GetAreas();
        foreach (AreaInfo area in areas)
        {
            TableRow tra = new TableRow();
            TableCell tca = new TableCell();
            tca.ColumnSpan = 6;
            tca.Text = "区域:<a href='/Area/edit.aspx?areaid=" + area.AreaID.ToString() + "'>" + area.AreaName + "</a>";
            tra.Cells.Add(tca);
            tbShop.Rows.Add(tra);

            IList<ShopInfo> sis = ds.GetShopsByAreaID(area.AreaID);
            foreach (ShopInfo si in sis)
            {
                TableRow trs = new TableRow();
                TableCell tcs1 = new TableCell();
                tcs1.Text = "<a href='/Shop/edit.aspx?ShopID=" + si.ShopID.ToString() + "'>" + si.ShopNo + "</a>";
                trs.Cells.Add(tcs1);

                TableCell tcs2 = new TableCell();
                tcs2.Text = si.ShopName;
                trs.Cells.Add(tcs2);

                TableCell tcs3 = new TableCell();
                tcs3.Text = si.Address;
                trs.Cells.Add(tcs3);

                TableCell tcs4 = new TableCell();
                tcs4.Text = si.Tel;
                trs.Cells.Add(tcs4);

                TableCell tcs5 = new TableCell();
                tcs5.Text = si.Fax;
                trs.Cells.Add(tcs5);

                TableCell tcs6 = new TableCell();
                CheckBox cb = new CheckBox();
                cb.Checked = si.IsCenter;
                cb.ID = "cb_" + si.ShopID.ToString();
                cb.Enabled = false;
                tcs6.Controls.Add(cb);
                trs.Cells.Add(tcs6);

                tbShop.Rows.Add(trs);
            }
        }
    }
}