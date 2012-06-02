using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.Model;
using NameName.DAL;
namespace ShopClient
{
    public partial class Login : Form
    {
        public string UserName { get; set; }
        public Login()
        {
            InitializeComponent();
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
          

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValidated = new DALUser().ValidateUser(UserName, numInupt1.InputValue);
            if (isValidated)
            {
                this.DialogResult = DialogResult.OK;
              
            }
            else
            {
                MessageBox.Show("密码错误");
            }
        }
    }
}
