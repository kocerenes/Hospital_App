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
    public partial class Frm_PatientRecord : Form
    {
        public Frm_PatientRecord()
        {
            InitializeComponent();
        }
        
        Sql_Connection cnnct = new Sql_Connection(); //sql baglantı sınıfından nesne oluşturdum.

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // sorgu parametrelerinin verildiği kısım.
            SqlCommand command = new SqlCommand("insert into Tbl_Patients (PatientName,PatientSurname,PatientTC,PatientTelNo,PatientPassword,PatientGender) values (@p1,@p2,@p3,@p4,@p5,@p6)",cnnct.connection() );

            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", MskRegisterTC.Text);
            command.Parameters.AddWithValue("@p4", MskRegisterPhone.Text);
            command.Parameters.AddWithValue("@p5", txtRegisterPsswrd.Text);
            command.Parameters.AddWithValue("@p6", cmbRegisterGender.Text);

            command.ExecuteNonQuery(); // ExecuteNonQuery() metodu etkilediği kayıt sayısını döndürür.update insert delete işlemlerinde kullanılır.

            cnnct.connection().Close(); // bağlantımızı kapattık.
            MessageBox.Show("Kaydınız başarıyla gerçekleşmiştir. Şifreniz: " + txtRegisterPsswrd.Text,"İnformation",MessageBoxButtons.OK,MessageBoxIcon.Information);



        }
    }
}
