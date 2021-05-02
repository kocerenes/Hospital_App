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
    public partial class frm_Announcements : Form
    {
        public frm_Announcements()
        {
            InitializeComponent();
        }

        Sql_Connection cnnct = new Sql_Connection();

        private void frm_Announcements_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Tbl_Announcements", cnnct.connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cnnct.connection().Close();
        }
    }
}
