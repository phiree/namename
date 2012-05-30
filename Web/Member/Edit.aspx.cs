using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NameName.DAL;
using NameName.Model;

public partial class Member_Edit : System.Web.UI.Page
{
    string UserName;
    DALUser du = new DALUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = Request["username"];
        if (!IsPostBack)
        {
            BindDepart();
            BindRight();
            if (UserName != null)
            {
                BindUser();
                tbUserName.ReadOnly = true;
            }
            else
            {
                tbUserName.ReadOnly = false;
                btnDelete.Visible = false;
                btnInitPwd.Visible = false;
            }
        }
    }

    private void BindUser()
    {
        //显示控制
        UserInfo ui = du.GetByUserName(UserName);
        tbUserName.Text = ui.UserName;
        tbTrueName.Text = ui.TrueName;
        tbOrderNo.Text = ui.OrderNO.ToString();
        ddlDepart.SelectedValue = ui.DepartID.ToString();
        tbTel.Text = ui.Tel;
        tbMobile.Text = ui.Mobile;
        foreach (ListItem li in cbxRights.Items)
        {
            li.Selected = Common.IsRole(Convert.ToInt32(li.Value), ui.RightSet);
        }
    }

    private void BindDepart()
    {
        DALDepart dalDepart = new DALDepart();

        ddlDepart.DataSource = dalDepart.GetDeparts();
        ddlDepart.DataTextField = "DepartName";
        ddlDepart.DataValueField = "DepartId";
        ddlDepart.DataBind();
    }

    private void BindRight()
    {
        foreach (EnumRight u in Enum.GetValues(typeof(EnumRight)))
        {
            cbxRights.Items.Add(new ListItem(u.ToString(), ((int)u).ToString()));
        }
    }

    private void SaveUser()
    {
        UserInfo ui = null;
        if (UserName == null)
        {
            //判断用户名是否存在
            ui = du.GetByUserName(tbUserName.Text);
            if (ui != null)
            {
                Session[WebHint.Web_Hint] = new WebHint("已经存在的用户名,不能重复创建!", "#", HintFlag.错误);
                Response.Redirect(WebHint.HintURL);
            }
            else
            {
                ui = new UserInfo();
                ui.UserName = tbUserName.Text;
            }
        }
        else
        {
            ui = du.GetByUserName(UserName);
        }
        ui.TrueName = tbTrueName.Text;
        ui.OrderNO = Convert.ToInt32(tbOrderNo.Text);
        ui.DepartID = new Guid(ddlDepart.SelectedValue);
        ui.Tel = tbTel.Text;
        ui.Mobile = tbMobile.Text;

        int right = 0;
        foreach (ListItem li in cbxRights.Items)
        {
            if (li.Selected)
            {
                right |= Convert.ToInt32(li.Value);
            }
        }

        ui.RightSet = right;

        du.Save(ui);

        Session[WebHint.Web_Hint] = new WebHint("保存成功", "/Member/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }

    private void DeleteUser()
    {
        du.Delete(UserName);

        Session[WebHint.Web_Hint] = new WebHint("用户删除成功", "/Member/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }

    private void InitPwd()
    {
        du.InitPwd(UserName);

        Session[WebHint.Web_Hint] = new WebHint("密码初始化成功", "/Member/Default.aspx", HintFlag.跳转);
        Response.Redirect(WebHint.HintURL);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveUser();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        InitPwd();
    }
    protected void btnInitPwd_Click(object sender, EventArgs e)
    {
        DeleteUser();
    }
}