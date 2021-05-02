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
    public partial class frm_Secretary_Department : Form
    {
        public frm_Secretary_Department()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection();

        private void frm_Secretary_Department_Load(object sender, EventArgs e)
        {
            // veritabanından bölümleri datagride çekicez.
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Departments", cnnct.connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // bölüm ekleme işlemini yapıyoruz.
            SqlCommand command = new SqlCommand("Insert into Tbl_Departments (DepartmentName) values (@p1)", cnnct.connection());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();

            txtName.Clear();

            MessageBox.Show("Bölüm başarıyla eklendi.", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // tablodan bir kere tıkladıgımız bransın verilerini ilgili yerlere yazdırıcaz.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Sectiğimiz bölümleri sileriz.
            SqlCommand command = new SqlCommand("Delete From Tbl_Departments where IdDepartment=@p1", cnnct.connection());
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Bölüm başarıyla silindi", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Sectiğimiz bölümü güncelleriz.
            SqlCommand command = new SqlCommand("Update Tbl_Departments set DepartmentName=@p1 where IdDepartment=@p2", cnnct.connection());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtID.Text);
            command.ExecuteNonQuery();
            cnnct.connection().Close();
            MessageBox.Show("Bölüm başarıyla güncellendi.", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
