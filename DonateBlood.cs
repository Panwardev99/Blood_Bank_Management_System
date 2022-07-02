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

namespace Bloodbankmanagement2
{
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }


        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static DataTable DataSource;

        public static object SelectedRows{ get; internal set; }
        
        private void populate()
        {
            Con.Open();
            string Query = "select * from DonorTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDG.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor Ob = new ViewDonor();
            Ob.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DonateBlood_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bloodBankDbDataSet2.BloodTb1' table. You can move, or remove it, as needed.
            this.bloodTb1TableAdapter.Fill(this.bloodBankDbDataSet2.BloodTb1);
            // TODO: This line of code loads data into the 'bloodBankDbDataSet.DonorTb1' table. You can move, or remove it, as needed.
            this.donorTb1TableAdapter.Fill(this.bloodBankDbDataSet.DonorTb1);
            // TODO: This line of code loads data into the 'bloodBankDbDataSet1.PatientTb1' table. You can move, or remove it, as needed.
            this.patientTb1TableAdapter.Fill(this.bloodBankDbDataSet1.PatientTb1);

        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            //helps to get the actual stock of blood on particular blood group

            Con.Open();
            string query = "select * from BloodTb1 where BGroup'" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query,Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorsDGV.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTb.Text = DonorsDGV.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(BGroupTb.Text);
        }
        private void reset()
        {
            DNameTb.Text = "";
            BGroupTb.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text == "")
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    int stock = oldstock + 1;
                    string query = "update BloodTb1 set BGroup set BStocks='" + stock +"' where BGroup =" + BGroupTb.Text + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successfull");
                    Con.Close();
                    reset();
                    bloodStock();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BloodStockDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
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
    }
}
