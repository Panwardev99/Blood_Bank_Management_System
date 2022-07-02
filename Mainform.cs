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
    public partial class Mainform : Form
    {
        
        public Mainform()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer Vd = new BloodTransfer();
            Vd.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
            Ob.Show();
            this.Hide();

        }
        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor Vd = new ViewDonor();
            Vd.Show();
            this.Hide();


        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Vd = new Patient();
            Vd.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock Vd = new BloodStock();
            Vd.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard Vd = new Dashboard();
            Vd.Show();
            this.Hide();
        }
    }
}
