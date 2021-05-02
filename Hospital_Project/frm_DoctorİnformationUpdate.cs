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
    public partial class frm_DoctorİnformationUpdate : Form
    {
        public frm_DoctorİnformationUpdate()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection();
        public string TC;

        private void frm_DoctorİnformationUpdate_Load(object sender, EventArgs e)
        {
            MskRegisterTC.Text = TC;

            // Doktorun varolan bilgilerini gerekli alanlara taşıyoruz.
            SqlCommand command = new SqlCommand("Select * From Tbl_Doctors Where DoctorTC=@p1", cnnct.connection());
            command.Parameters.AddWithValue("@p1", TC);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtName.Text = reader[1].ToString();
                txtSurname.Text = reader[2].ToString();
                cmbDepartment.Text = reader[3].ToString();
                txtRegisterPsswrd.Text = reader[5].ToString();
            }
            cnnct.connection().Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // bilgileri güncelleme kısmı.
            SqlCommand command = new SqlCommand("Update Tbl_Doctors set DoctorName=@p1,DoctorSurname=@p2,DoctorBranch=@p3,DoctorPassword=@p4 Where DoctorTC=@p5", cnnct.connection());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbDepartment.Text);
            command.Parameters.AddWithValue("@p4", txtRegisterPsswrd.Text);
            command.Parameters.AddWithValue("@p5", MskRegisterTC.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Bilgileriniz başarıyla güncellenmiştir.", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
