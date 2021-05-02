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
using Microsoft.SqlServer.Server;

namespace Hospital_Project
{
    public partial class frm_PationİnformationUpdate : Form
    {
        public frm_PationİnformationUpdate()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection(); // Bağlantımızı çağırdık.

        public string TcNo; // Hasta panelinden Hastanın varolan Tc nosunu buraya taşımak için public nesne oluşturduk.

        private void frm_PationİnformationUpdate_Load(object sender, EventArgs e)
        {
            MskRegisterTC.Text = TcNo; // Hastanın tc no sunu yazdırdık.

            // Sorgumuzu yazdık.
            SqlCommand sqlCommand = new SqlCommand("Select * From Tbl_Patients Where PatientTC=@p1", cnnct.connection());
            sqlCommand.Parameters.AddWithValue("@p1", MskRegisterTC.Text);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read()) // Yazdırma işlemini yaptırdık.
            {
                txtName.Text = reader[1].ToString();
                txtSurname.Text = reader[2].ToString();
                MskRegisterPhone.Text = reader[4].ToString();
                txtRegisterPsswrd.Text = reader[5].ToString();
                cmbRegisterGender.Text = reader[6].ToString();
            }
            cnnct.connection().Close(); // Bağlantıyı kapadık.
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Sorgumuzu yazdık.
            SqlCommand sqlCommand2 = new SqlCommand("Update Tbl_Patients set PatientName=@p1, PatientSurname=@p2, PatientTelNo=@p3,PatientPassword=@p4, PatientGender=@p5 where PatientTC=@p6", cnnct.connection());
            sqlCommand2.Parameters.AddWithValue("@p1", txtName.Text);
            sqlCommand2.Parameters.AddWithValue("@p2", txtSurname.Text);
            sqlCommand2.Parameters.AddWithValue("@p3", MskRegisterPhone.Text);
            sqlCommand2.Parameters.AddWithValue("@p4", txtRegisterPsswrd.Text);
            sqlCommand2.Parameters.AddWithValue("@p5", cmbRegisterGender.Text);
            sqlCommand2.Parameters.AddWithValue("@p6", MskRegisterTC.Text);
            sqlCommand2.ExecuteNonQuery(); // Yaptığımız işlemleri gerçekleştirmek için yazdık.
            cnnct.connection().Close(); // Bağlantıyı kapadık.
            MessageBox.Show("information has been successfully updated.", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
