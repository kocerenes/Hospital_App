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
using System.Data.Common;

namespace Hospital_Project
{
    public partial class frm_Secretary_DoctorPanel : Form
    {
        public frm_Secretary_DoctorPanel()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection();

        private void frm_Secretary_DoctorPanel_Load(object sender, EventArgs e)
        {
            // Datagridviewe Doktor tablosunu cektik.
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Doctors", cnnct.connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;


            // comboboxa bölümleri ekleme.
            SqlCommand command = new SqlCommand("Select DepartmentName From Tbl_Departments", cnnct.connection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbDepartment.Items.Add(reader[0]);
            }
            cnnct.connection().Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // sekreterin doktor ekleme sorgusunu yazdık.
            SqlCommand command = new SqlCommand("Insert into Tbl_Doctors(DoctorName,DoctorSurname,DoctorBranch,DoctorTC,DoctorPassword) values (@p1,@p2,@p3,@p4,@p5)", cnnct.connection());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbDepartment.Text);
            command.Parameters.AddWithValue("@p4", mskTC.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();

            txtName.Clear();
            txtSurname.Clear();
            cmbDepartment.Text = "";
            mskTC.Text = "";
            txtPassword.Clear();

            MessageBox.Show("Doktor başarıyla kaydedildi", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; // hücrenin 0. sütununa göre satır indexi alsın.
            // Aktarma işlemleri
            txtName.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); // secilen satırın 1. hücresindeki deger.
            txtSurname.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString(); // secilen satırın 2. hücresindeki deger.
            cmbDepartment.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();  // secilen satırın 3. hücresindeki deger.
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString(); // secilen satırın 4. hücresindeki deger.
            txtPassword.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString(); // secilen satırın 5. hücresindeki deger.       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Doktor silme sorgusu
            SqlCommand command = new SqlCommand("Delete From Tbl_Doctors Where DoctorTC=@p1", cnnct.connection());
            command.Parameters.AddWithValue("@p1", mskTC.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Kayıt başarıyla silindi", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Doktor bilgilerini güncelleme sorgusu
            SqlCommand command = new SqlCommand("Update Tbl_Doctors set DoctorName=@p1,DoctorSurname=@p2,DoctorBranch=@p3,DoctorPassword=@p5 where DoctorTC=@p4", cnnct.connection());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbDepartment.Text);
            command.Parameters.AddWithValue("@p4", mskTC.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Doktor başarıyla güncellendi", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
