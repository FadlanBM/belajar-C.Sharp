﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Belajar_crud_menampilkan_data
{
    internal class koneksi
    {
        public SqlConnection Getconn() {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source = WIN-4T7LHOS9DNI; initial catalog=dbsiswa; integreted security=true";
            return Conn;
        }
    }
}
