using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;

public partial class Member_Default : System.Web.UI.Page
{
    DALUser dalUser = new DALUser();
    DALDepart dalDepart = new DALDepart();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetData();
    }

    private void GetData()
    {
        tbUser.Rows.Clear();
        Common.CreateHeader("用户名,姓名,电话,手机", tbUser, new int[] { });
        IList<DepartInfo> departs = dalDepart.GetDeparts();
        foreach (DepartInfo d in departs)
        {
            TableRow trd = new TableRow();
            TableCell tcd = new TableCell();
            tcd.ColumnSpan = 4;
            tcd.Text = "部门:<a href='/Department/edit.aspx?departid=" + d.DepartID.ToString() + "'>" + d.DepartName + "</a>";
            trd.Cells.Add(tcd);
            tbUser.Rows.Add(trd);

            IList<UserInfo> users = d.DepartUsers;
            foreach (UserInfo u in users)
            {
                TableRow tru = new TableRow();
                TableCell tcu1 = new TableCell();
                tcu1.Text = "<a href='/Member/edit.aspx?UserName=" + u.UserName + "'>" + u.UserName + "</a>";
                tru.Cells.Add(tcu1);

                TableCell tcu2 = new TableCell();
                tcu2.Text = u.TrueName;
                tru.Cells.Add(tcu2);

                TableCell tcu3 = new TableCell();
                tcu3.Text = u.Tel;
                tru.Cells.Add(tcu3);

                TableCell tcu4 = new TableCell();
                tcu4.Text = u.Mobile;
                tru.Cells.Add(tcu4);

                tbUser.Rows.Add(tru);
            }
        }
    }
}