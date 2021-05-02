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
    public partial class frm_Secretary_Login : Form
    {
        public frm_Secretary_Login()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection(); // Bağlantıyı cagırdık.

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Sorgular.
            SqlCommand command = new SqlCommand("Select * From Tbl_Secretaries where SecretaryTC=@p1 and SecretaryPassword=@p2", cnnct.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader reader = command.ExecuteReader(); // Okutma işlemi.
            // Okutma işlemi doğruysa sekreter paneli açılır.
            if(reader.Read())
            {
                frm_SecretaryPanel secretaryPanel = new frm_SecretaryPanel();
                secretaryPanel.tc = MskTc.Text;
                secretaryPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bilgilerinizi hatalı girdiniz! Lütfen tekrar deneyin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cnnct.connection().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Entries _Entries = new Frm_Entries();
            _Entries.Show();
            this.Hide();
        }

        private void frm_Secretary_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
