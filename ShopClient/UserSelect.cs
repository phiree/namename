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
        public Guid ShopId
        {
            get;
            set;
        }
        public UserSelect()
        {

            if (ShopId == null || ShopId == Guid.Empty)
            {
                return;
            }

            InitializeComponent();
        }
        public void LoadUsers()
        {
            ShopInfo shop = new DALShopInfo().GetByShopID(ShopId);
            IList<UserInfo> users = shop.ShopUsers;
            Dictionary<string,UserInfo> SourceUsers=new Dictionary<string,UserInfo>();
            foreach(UserInfo user in users)
            {
             SourceUsers.Add(user.UserName,user);
            }

            GridBuilder<UserInfo> UserGrid = new GridBuilder<UserInfo>(SourceUsers,
                new Size(100, 100), panel1, 4, 20, 20);
            UserGrid.BuildButtons();
            UserGrid.OnBindButtonClick += new GridBuilder<UserInfo>.BindButtonClick(UserGrid_OnBindButtonClick);

        }

        void UserGrid_OnBindButtonClick(Button b)
        {
            b.Click += new EventHandler(UserBtnclick);
        }
        void UserBtnclick(object sender, EventArgs e)
        {
            Login login = new Login();
            Button btn = sender as Button;
            login.UserName = btn.Text;
            login.ShowDialog();
        }
    }
}
