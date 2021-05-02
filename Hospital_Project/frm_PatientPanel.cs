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
using System.Net;

namespace Hospital_Project
{
    public partial class frm_PatientPanel : Form
    {
        public frm_PatientPanel()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public string Tc; // hasta giriş sayfasında girilen Tc no yu bu panele tasımak için string nesne oluşturduk.

        Sql_Connection cnnct = new Sql_Connection(); // bağlantı sınıfından nesne oluşturduk.

        private void frm_PatientPanel_Load(object sender, EventArgs e)
        {
            lblTc.Text = Tc; // sayfa açılınca giriş yapılan Tc no yu bilgiler kısmındaki tc no kısmına taşıdım.

            // veritabanından ad soyad çekme.
            // Sorguyu yazdık.
            SqlCommand command = new SqlCommand("Select PatientName,PatientSurname From Tbl_Patients Where PatientTC=@p1",cnnct.connection());

            command.Parameters.AddWithValue("@p1", Tc); // Sorgu parametrelerinin verildiği kısım.

            SqlDataReader reader = command.ExecuteReader(); // sorguları okutmak için nesne oluşturuyoruz.
            while (reader.Read())
            {
                lblName.Text = reader[0] + " " + reader[1]; // adı soyadı yazdırdık.
            }
            cnnct.connection().Close();

            //Randevu geçmmişi.
            DataTable dataTable = new DataTable(); // Veri tablosu nesnesi oluşturduk.
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Appointments Where PatientTC="+Tc,cnnct.connection()); //DataAdapter datagride verileri aktarmak için kullandığım komut.
            dataAdapter.Fill(dataTable);  //DataAdapterin içini tablodan gelecek değerle doldur.
            dataGridView1.DataSource = dataTable;

            // bölümleri çekme
            SqlCommand command1 = new SqlCommand("Select DepartmentName From Tbl_Departments", cnnct.connection());
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                cmbDepartment.Items.Add(reader1[0]);
            }
            cnnct.connection().Close();

        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Her bölüm seciminde cmbDoctorun içini temizlememiz gerekir.
            cmbDoctors.Items.Clear();

            SqlCommand command2 = new SqlCommand("Select DoctorName,DoctorSurname From Tbl_Doctors Where DoctorBranch=@p1", cnnct.connection());
            command2.Parameters.AddWithValue("@p1", cmbDepartment.Text); // sorgu
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                cmbDoctors.Items.Add(reader2[0] + " " + reader2[1]);
            }
            cnnct.connection().Close(); // Bağlantıyı kapattık.

        }

        private void cmbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // DataGride Sql den veri çekicez
            DataTable dataTable1 = new DataTable();
            //Sorgu işlemleri.
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter("Select * From Tbl_Appointments Where AppointmentDepartment= '" + cmbDepartment.Text + "'" + " and AppointmentDoctor= '" + cmbDoctors.Text+ "' and AppointmentCase=0", cnnct.connection());
            dataAdapter1.Fill(dataTable1); //DataAdapterin içini tablodan gelecek değerle doldur.
            dataGridView2.DataSource = dataTable1; //datasource , datagridviewin gosterecegi datalari nereden saglayacagini belirten propertisidir.

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Bilgileri düzenlemek için gerekli sayfayı açtık.
            frm_PationİnformationUpdate update = new frm_PationİnformationUpdate();
            update.TcNo = lblTc.Text;
            update.Show();
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // tablodaki bi randevu satırına tıkladıgımızda randevu bilgileri ilgili yerlere taşınıcak.
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtİd.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            // Hastanın Randevu alma işlemi.
            //sorgular
            SqlCommand command = new SqlCommand("Update Tbl_Appointments set AppointmentCase=1,PatientTC=@p1,PatientComplaint=@p2 where IdAppointment=@p3", cnnct.connection());
            command.Parameters.AddWithValue("@p1", lblTc.Text);
            command.Parameters.AddWithValue("@p2", rtbDiscomfort.Text);
            command.Parameters.AddWithValue("@p3", txtİd.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Randevu başarıyla alındı.", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtİd.Clear();
            cmbDepartment.Text = "";
            cmbDoctors.Text="";
            rtbDiscomfort.Clear();
        }


        // Sıkıntılı!!!!!!!!!!!!!!!!!!!!!!!
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "İnformation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                Frm_Entries entries = new Frm_Entries();
                entries.Show();
                this.Hide();
            }
            
        }
    }
}
