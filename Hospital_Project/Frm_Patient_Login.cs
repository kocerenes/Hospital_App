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
    public partial class Frm_Patient_Login : Form
    {
        public Frm_Patient_Login()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection(); // Sql bağlantısı yapmak için bağlantı sınıfının nesnesini oluşturduk.

        // Bu butona basıldığında Hasta kayıtlı değilse kayıt olması için yeni sayfaya yönlendirilecek.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_PatientRecord patientRecord = new Frm_PatientRecord();
            patientRecord.Show();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // sorgu parametrelerinin verildiği kısım.
            SqlCommand Command = new SqlCommand("Select * From Tbl_Patients Where PatientTC=@p1 and PatientPassword=@p2", cnnct.connection());
            Command.Parameters.AddWithValue("@p1", MskTc.Text); // p1 parametresine passwordu aktarıyoruz.
            Command.Parameters.AddWithValue("@p2", txtPassword.Text); // p2 parametresine Tc yi aktarıyoruz.
            SqlDataReader dataReader = Command.ExecuteReader(); // yazdığımız bilgileri okuması için nesne oluşturduk.

            // Eğer okuduğu değerler doğruysa hasta panelini açar.
            if (dataReader.Read())
            {
                frm_PatientPanel patientPanel = new frm_PatientPanel(); // hasta paneli için nesne oluşturduk.
                patientPanel.Tc = MskTc.Text;
                patientPanel.Show(); // hasta panelini açtırdık.
                this.Hide(); // giriş panelini kapattık.
            }
            else
            {
                MessageBox.Show("Bilgilerinizi hatalı girdiniz! Lütfen tekrar deneyin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cnnct.connection().Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Frm_Entries _Entries = new Frm_Entries();
            _Entries.Show();
            this.Hide();
        }

        private void Frm_Patient_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
