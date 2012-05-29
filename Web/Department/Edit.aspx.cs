using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.Model;
using NameName.DAL;
public partial class Department_Edit : System.Web.UI.Page
{
    DALDepart dalDepart = new DALDepart();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddDepart_Click(object sender, EventArgs e)
    {
        DepartInfo depart = new DepartInfo();
        depart.DepartID = Guid.Empty;
        depart.DepartName = tbxDepart.Text;
        depart.DeleteFlag = false;  
        dalDepart.Save(depart);
    }
}