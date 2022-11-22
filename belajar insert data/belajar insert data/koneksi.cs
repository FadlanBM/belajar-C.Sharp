using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace belajar_insert_data
{
    internal class koneksi
    {
        public SqlConnection Getcon() {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data source=WIN-4T7LHOS9DNI; initial catalog=dbsiswa; integrated security=true;";
            return con;
        }
    }
}
