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
    public partial class BloodTransfer : Form
    {
        public BloodTransfer()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Documents\\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PNum from PatientTb1", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PName", typeof(int));
            dt.Load(rdr);
            PatientIdCb.ValueMember = "PNum";
            PatientIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetData()
        {
            //helps to get the BloodGroup and name of the patient 

            Con.Open();
            string query = "select * from BloodTb1 where PNum'" + PatientIdCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PatNameTb.Text = dr["PName"].ToString();
                BloodGroup.Text = dr["PBGroup"].ToString();

            }
            Con.Close();
        }
        int stock = 0;
        private void GetStock(string Bgroup)
        {
            //helps to get the actual stock of blood on particular blood group

            Con.Open();
            string query = "select * from BloodTb1 where BGroup'" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();
        }
        private void BloodTransfer_Load(object sender, EventArgs e)
        {

        }
        /*int oldstock;
        private void GetStock(string Bgroup)
        {
            //helps to get the actual stock of blood on particular blood group

            Con.Open();
            string query = "select * from BloodTb1 where BGroup'" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();
        }*/
            private void PatientIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(BloodGroup.Text);
            if (stock > 0)
            {
                TransferBtn.Visible = true;
                AvailableLbl.Text = "Available Stock";
                AvailableLbl.Visible = true;
            }
            else
            {
                AvailableLbl.Text = " Stock not available ";
                AvailableLbl.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }
        private void Reset()
        {
            PatNameTb.Text = "";
            //PatientdCb.SelectionIndex = -1;
            BloodGroup.Text = "";
            AvailableLbl.Visible = false;
            TransferBtn.Visible = false;
        }
        private void updateStock()
        {
            int newstock = stock -1;
            try
            {
                string query = "update BloodTb1 set BStock=" + newstock+ "where BGroup =" + BloodGroup.Text + "';";
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Patient Successfully Deleted");
                Con.Close();
                Reset();
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTb1 values('" + PatNameTb.Text + "','" + BloodGroup.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully transfer");
                    Con.Close();
                    GetStock(BloodGroup.Text);
                    updateStock();
                    Reset();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock BStock = new BloodStock();
            BStock.Show();
            this.Hide();
        }

        private void PatientIdCb_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
           
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
