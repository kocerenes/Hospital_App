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
    public partial class Frm_DoctorPanel : Form
    {
        public Frm_DoctorPanel()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection(); // bağlantıyı cagırdık.
        public string TC;


        // duyuruların bulundugu paneli açtık.
        private void button2_Click(object sender, EventArgs e)
        {
            frm_Announcements announcements = new frm_Announcements();
            announcements.Show();
        }

        private void Frm_DoctorPanel_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;

            // AD soyad cekme.
            SqlCommand command = new SqlCommand("Select DoctorName,DoctorSurname From Tbl_Doctors Where DoctorTC=@p1", cnnct.connection());
            command.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblNameSurname.Text = reader[0] + " " + reader[1];
            }
            cnnct.connection().Close();


            // Giriş yapan doktora ait randevuları datagride aktarma.
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Appointments Where AppointmentDoctor= '" + lblNameSurname.Text + "'", cnnct.connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cnnct.connection().Close();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frm_DoctorİnformationUpdate informationUpdate = new frm_DoctorİnformationUpdate();
            informationUpdate.TC = lblTC.Text;
            informationUpdate.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // komple programı kapatma komutu.
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // doktorun kendiisne ait randevularından birine bir kere tıkladıgında o randevuyu alan kişinin şikayetleri
            // richtextbox aracına gelicek.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchPatientİnformation.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
