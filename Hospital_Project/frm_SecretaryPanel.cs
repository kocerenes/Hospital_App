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
    public partial class frm_SecretaryPanel : Form
    {
        public frm_SecretaryPanel()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        Sql_Connection cnnct = new Sql_Connection(); // Bağlantımızı cagırdık.

        public string tc; // Giriş yapan sekreterin şifresini cekmek için nesne oluşturduk.

        private void frm_SecretaryPanel_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc; // sekreter bilgileri kısmında tc sini yazdırdık.

            // Ad Soyad
            SqlCommand command = new SqlCommand("Select SecretaryNameSurname From Tbl_Secretaries Where SecretaryTC=@p1", cnnct.connection());
            command.Parameters.AddWithValue("@p1", lblTC.Text); // Sorgu
            SqlDataReader reader = command.ExecuteReader(); // Okutma işlemi
            // giriş yapan sekreterin ad soyadını veritabanından cekerek lblnamesuname e yazdırdık.
            while (reader.Read())
            {
                lblNameSurname.Text = reader[0].ToString();
            }
            cnnct.connection().Close(); // Bağlantıyı kapattık.



            // Branşları datagridviewe aktarma.
            DataTable dataTable = new DataTable(); // Veri tablosu nesnesi oluşturduk.
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Departments", cnnct.connection());
            dataAdapter.Fill(dataTable); //DataAdapterin içini tablodan gelecek değerle doldur.
            dataGridView2.DataSource=dataTable;


            // Doktorları datagridviewe aktarma.
            DataTable dataTable1 = new DataTable(); // veri tablosu nesnesi oluşturduk
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter("Select (DoctorName+' '+DoctorSurname) as Doctors,DoctorBranch From Tbl_Doctors", cnnct.connection());
            dataAdapter1.Fill(dataTable1); //DataAdapterin içini tablodan gelecek değerle doldur.
            dataGridView1.DataSource = dataTable1;


            // Bölümleri comboboxa aktarma
            SqlCommand command1 = new SqlCommand("Select DepartmentName From Tbl_Departments", cnnct.connection()); // sorgu
            SqlDataReader reader1 = command1.ExecuteReader(); // okutma işlemi.
            // bölüm adlarını veri tabanından cekerek comboboxa yazdırdık.
            while (reader1.Read())
            {
                cmbDepartment.Items.Add(reader1[0]);
            }
            cnnct.connection().Close(); // Bağlantıyı kapattık.

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // sorgu.
            SqlCommand commandUpdate = new SqlCommand("Insert into Tbl_Appointments (AppointmentDate,AppointmentHour,AppointmentDepartment,AppointmentDoctor) values (@r1,@r2,@r3,@r4)", cnnct.connection());
            commandUpdate.Parameters.AddWithValue("@r1", mskDate.Text);
            commandUpdate.Parameters.AddWithValue("@r2", mskHour.Text);
            commandUpdate.Parameters.AddWithValue("@r3", cmbDepartment.Text);
            commandUpdate.Parameters.AddWithValue("@r4", cmbDoctor.Text);
            commandUpdate.ExecuteNonQuery(); // oluşturma işlemini yaptık.
            cnnct.connection().Close(); // baglantıyı kapattık
            MessageBox.Show("Randevu başarıyla oluşturuldu.");
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear(); // her bölüm secildiğinde önce seilen bölümün doktorlarını comboboxtan siliyoruz.

            // sorgu.
            SqlCommand command = new SqlCommand("Select DoctorName,DoctorSurname From Tbl_Doctors Where DoctorBranch=@p1", cnnct.connection());
            command.Parameters.AddWithValue("@p1", cmbDepartment.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbDoctor.Items.Add(reader[0] + " " + reader[1]);
            }
            cnnct.connection().Close(); // bağlantımızı kapattık.

        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            rchAnnouncement.Clear(); // her duyuru eklendiğinde önceki duyuru silinsin.

            SqlCommand command = new SqlCommand("Insert into Tbl_Announcements (Announcement) values (@d1)", cnnct.connection());
            command.Parameters.AddWithValue("@d1", rchAnnouncement.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Duyuru başarıyla oluşturuldu.");
        }

        private void btnDoctorPanel_Click(object sender, EventArgs e)
        {
            frm_Secretary_DoctorPanel doctorPanel = new frm_Secretary_DoctorPanel();
            doctorPanel.Show();
        }

        private void btnDepartmentPanel_Click(object sender, EventArgs e)
        {
            frm_Secretary_Department secretary_Department = new frm_Secretary_Department();
            secretary_Department.Show();
        }

        private void btnAppointmentList_Click(object sender, EventArgs e)
        {
            frm_Secretary_AppointmentList appointmentList = new frm_Secretary_AppointmentList();
            appointmentList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Announcements announcements = new frm_Announcements();
            announcements.Show();
        }
    }
}
