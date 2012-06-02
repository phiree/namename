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
            Dictionary<string, UserInfo> SourceUsers = new Dictionary<string, UserInfo>();

            foreach (UserInfo user in users)
            {
                SourceUsers.Add(user.TrueName, user);
            }

            GridBuilder<UserInfo> UserGrid = new GridBuilder<UserInfo>(SourceUsers, new Size(120, 120), panel1, 3, 50, 50);

            UserGrid.OnBindButtonClick += new GridBuilder<UserInfo>.BindButtonClick(UserGrid_OnBindButtonClick);
            UserGrid.BuildButtons();
        }

        void UserGrid_OnBindButtonClick(Button b)
        {
            b.Click += new EventHandler(UserBtnclick);
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
                Program.cashFrm.LoginSuccess();
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
