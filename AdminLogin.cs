using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloodbankmanagement2
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter the Admin Password");
            }
            else if(AdminPassTb.Text == "password") 
            {
                Employee Exp = new Employee();
                Exp.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Wrong Password Contact the system Admin");
                AdminPassTb.Text = "";
            }
        }
    }
}
