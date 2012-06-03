using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.DAL;
using NameName.Model;
namespace ShopClient
{

    public partial class UserSelect : Form
    {
        bool ToExit = true;

        //Guid ShopId = GlobalValue.GShop.ShopID;

        public UserSelect()
        {

            if (GlobalValue.GShop == null)
            {
                return;
            }

            InitializeComponent();
            LoadUsers();
        }

        public void LoadUsers()
        {
            lbshopinfo.Text = GlobalValue.GShop.AreaInfo.AreaName + " - " + GlobalValue.GShop.ShopName;
            IList<UserInfo> users = GlobalValue.GShop.ShopUsers;
            GridBuilder<UserInfo> UserGrid = new GridBuilder<UserInfo>(users, new Size(120, 120), panel1, 3, 50, 50);
            UserGrid.OnAddItem += new GridBuilder<UserInfo>.AddItem(UserGrid_OnAddItem);
            UserGrid.BuildButtons();
        }

        void UserGrid_OnAddItem(UserInfo t, Rectangle position, Control gridcontainer)
        {
            Button btn = new Button();
            btn.Left = position.Left;
            btn.Top = position.Top; ;
            btn.Size = position.Size;
            btn.Text = t.TrueName;
            btn.Tag = t;
            btn.Click += new EventHandler(UserBtnclick);
            gridcontainer.Controls.Add(btn);
        }

        void UserBtnclick(object sender, EventArgs e)
        {
            Login login = new Login();
            Button btn = sender as Button;
            UserInfo u = (UserInfo)btn.Tag;
            login.UserName = u.UserName;

            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GlobalValue.GUser = u;
                Program.mainfrm.LoginSuccess();
                ToExit = false;
                this.Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ToExit = false;
            this.Close();
            new ShopSelect().Show();

        }

        private void UserSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ToExit)
            {
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
