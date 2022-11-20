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

namespace Belajar_crud_menampilkan_data
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi konn=new koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = konn.Getconn();
            try {
                conn.Open();
                cmd = new SqlCommand("Select * from tbsiswa",conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbsiswa");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbsiswa";
                dataGridView1.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G) {
                MessageBox.Show(G.ToString());
            }
            finally {
                conn.Close();
            }
        }
    }
}
