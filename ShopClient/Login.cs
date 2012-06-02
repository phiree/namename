using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserSelect().Show();
        }
    }
}
