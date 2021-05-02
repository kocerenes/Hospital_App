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

namespace Hospital_Project
{
    public partial class Frm_DoctorLogin : Form
    {
        public Frm_DoctorLogin()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Doktor için veritabanına kayıtlı olan tc ve şifresini sorgulatarak giriş yapmasını saglarız.
            SqlCommand command = new SqlCommand("Select * From Tbl_Doctors where DoctorTC=@p1 and DoctorPassword=@p2", cnnct.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Frm_DoctorPanel doctorPanel = new Frm_DoctorPanel();
                doctorPanel.TC = MskTc.Text;
                doctorPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız. Lütfen tekrar deneyiniz.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cnnct.connection().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Entries _Entries = new Frm_Entries();
            _Entries.Show();
            this.Hide();
        }

        private void Frm_DoctorLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
