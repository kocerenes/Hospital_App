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
    public partial class frm_Secretary_AppointmentList : Form
    {
        public frm_Secretary_AppointmentList()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection();

        private void frm_Secretary_AppointmentList_Load(object sender, EventArgs e)
        {
            // Datagride RAndevu tablosunu cekicez.
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Appointments", cnnct.connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cnnct.connection().Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
