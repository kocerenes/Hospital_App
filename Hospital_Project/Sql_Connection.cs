using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hospital_Project
{
    // sql bağlantısı için sınıf oluşturdum.
    public class Sql_Connection
    {
        // Sql baplantısı için metod olusturdum.
        public SqlConnection connection()
        {
            SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-74SU5I6;Initial Catalog=HastaneProje;Integrated Security=True");
            Connect.Open();
            return Connect;
        }
    }
}
