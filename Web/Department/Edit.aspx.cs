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

    string departid;
    DepartInfo di;
    protected void Page_Load(object sender, EventArgs e)
    {
        departid = Request["DepartID"];
        if (!IsPostBack)
        {
            if (departid != null)
            {
                BindDepart();

            }
            else
            {
                btnDelete.Visible = false;
            }
        }
    }

    private void BindDepart()
    {
        di = dalDepart.GetById(new Guid(departid));
        tbOrderNo.Text = di.OrderNO.ToString();
        tbDepartName.Text = di.DepartName;

    }

    protected void btnAddDepart_Click(object sender, EventArgs e)
    {
        DepartInfo depart = new DepartInfo();
        if (departid == null)
        {
            depart.DepartID = Guid.Empty;
        }
        else
        {
            depart.DepartID = new Guid(departid);
        }
        depart.OrderNO = Convert.ToInt32(tbOrderNo.Text);
        depart.DepartName = tbDepartName.Text;
        depart.DeleteFlag = false;
        dalDepart.Save(depart);

        Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Member/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
       IList<UserInfo> us= di.DepartUsers;
        if (us.Count == 0)
        {
            dalDepart.Delete(new Guid(departid));
            Session[WebHint.Web_Hint] = new WebHint("删除成功", "/Member/Default.aspx", HintFlag.跳转);
        }
        else
        {
            Session[WebHint.Web_Hint] = new WebHint("该部门下还有人员,不能删除", "#", HintFlag.错误);
        }
        Response.Redirect(WebHint.HintURL);
    }
}