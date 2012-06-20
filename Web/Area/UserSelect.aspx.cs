using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.DAL;
using NameName.Model;

public partial class Area_UserSelect : System.Web.UI.Page
{

    DALUser du = new DALUser();
    DALArea ds = new DALArea();


    string areaId;
    protected void Page_Load(object sender, EventArgs e)
    {
        areaId = Request["areaID"];
        if (!IsPostBack)
        {
            aBack.HRef = "/area/Edit.aspx?areaid=" + areaId;
        }
        CreateTableInfo();
    }



    private void CreateTableInfo()
    {
        tbUserSelect.Rows.Clear();

        IList<DepartInfo> departs = new DALDepart().GetDepartsByNotAssignUser();

        foreach (DepartInfo d in departs)
        {
            TableRow trd = new TableRow();
            TableCell tcd = new TableCell();
            tcd.ColumnSpan = 5;
            tcd.Text = "部门:" + d.DepartName;
            trd.Cells.Add(tcd);
            tbUserSelect.Rows.Add(trd);

            IList<UserInfo> users = du.GetAllUserNoAssigned(new Guid( areaId));

            int i = 0;
            TableRow tr = new TableRow();

            foreach (UserInfo u in users)
            {
                if (i % 5 == 0)
                {
                    tr = new TableRow();
                    tr.HorizontalAlign = HorizontalAlign.Center;
                    tbUserSelect.Rows.Add(tr);
                }

                TableCell tc = new TableCell();
                tc.Width = 120;
                CheckBox cb = new CheckBox();
                cb.ID = "cb_" + u.UserName;
                cb.Attributes.Add("UserName", u.UserName);
                cb.Text = u.TrueName;
                tc.Controls.Add(cb);
                tr.Cells.Add(tc);
                i++;
            }

            if (i % 5 != 0)
            {
                for (int j = i % 5; j < 5; j++)
                {
                    TableCell tc = new TableCell();
                    tc.Width = 120;
                    tr.Cells.Add(tc);
                }
            }
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {

        foreach (TableRow tr in tbUserSelect.Rows)
        {
            foreach (TableCell tc in tr.Cells)
            {
                if (tc.Controls.Count > 0)
                {
                    if (tc.Controls[0] is CheckBox)
                    {
                        CheckBox cb = (CheckBox)tc.Controls[0];
                        if (cb.Checked)
                        {
                            UserInfo u = du.GetByUserName(cb.Attributes["UserName"]);
                            u.AreaInfo = ds.GetByAreaID(new Guid(areaId));
                            du.Save(u);
                        }
                    }
                }
            }
        }
        Response.Redirect("/area/Edit.aspx?areaid=" + areaId);
    }
}