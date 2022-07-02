using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Bloodbankmanagement2
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");

        public double BStock { get; private set; }

        private void GetData()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLb1.Text = dt.Rows[0][0].ToString();
            
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTb1", Con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLb1.Text = dt1.Rows[0][0].ToString();


            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from EmployeeTb1", Con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            EmployeeLb1.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("Select count(*) from BloodTb1", Con);

            DataTable dt3 = new DataTable();
            sda3.Fill(dt);
            /*if (dt.Rows.Count > 0)
            {

                int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
                TotalLb1.Text = "" + BStock;
            }*/
            SqlDataAdapter sda4 = new SqlDataAdapter("Select count(*) from BloodTb1 where BGroup='"+"O+"+"'", Con);

            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);

            OplusNumLb1.Text = dt4.Rows[0][0].ToString();
            /*double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);
            //MessageBox.Show(""+OplusPercentage);*/

            SqlDataAdapter sda5 = new SqlDataAdapter("Select count(*) from BloodTb1 where BGroup='" + "O+" + "'", Con);

            DataTable dt5 = new DataTable();
            sda5.Fill(dt);

            OplusNumLb1.Text = dt4.Rows[0][0].ToString();

            SqlDataAdapter sda6 = new SqlDataAdapter("Select count(*) from BloodTb1 where BGroup='" + "AB+" + "'", Con);

            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);

            ABplusNumLb1.Text = dt6.Rows[0][0].ToString();

            SqlDataAdapter sda7 = new SqlDataAdapter("Select count(*) from BloodTb1 where BGroup='" + "O-" + "'", Con);

            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);

            OnegNumLb1.Text = dt7.Rows[0][0].ToString();

            SqlDataAdapter sda8 = new SqlDataAdapter("Select count(*) from BloodTb1 where BGroup='" + "AB-" + "'", Con);

            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);

            ABnegNumLb1.Text = dt8.Rows[0][0].ToString();
            Con.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
            Ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            ViewDonor Ob = new ViewDonor();
            Ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatient Ob = new ViewPatient();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock BStock = new BloodStock();
            BStock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer Bt = new BloodTransfer();
            Bt.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            login Ob = new login();
            Ob.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Hello welcome ,if you have any  urgent requirement post the messsage the click on the POST ");

        }

        private void label15_Click(object sender, EventArgs e)
        {
           /* POST PG = new POST();
            PG.Show();
            this.Hide();*/
        }
    }
}
