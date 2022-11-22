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

namespace belajarEdit_update_data
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi konn = new koneksi();

        void cleardata()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        void tampildata() {
            SqlConnection con = konn.getconn();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from tbsiswa", con);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbsiswa");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbsiswa";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tampildata();
            cleardata();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum lengkap");
            }
            else {
                SqlConnection con = konn.getconn();
                try
                {
                    cmd = new SqlCommand("insert into tbsiswa values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("input data berhasi");
                    tampildata();
                    cleardata();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
