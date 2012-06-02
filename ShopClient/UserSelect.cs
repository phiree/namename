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
            int initIndex=0, initTop = 0, initLeft = 0, width = 40, height = 40, space = 30, cols = 4;
            foreach (UserInfo user in users)
            {
                int rowIndex = initIndex / cols;
                int colIndex = initIndex % cols;

                int left =colIndex* (space + width);
                Button btn = new Button();

                initIndex++;
            }
        }
    }
}
