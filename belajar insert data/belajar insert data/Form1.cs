using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_insert_data
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi kon = new koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        void tampildata()
        {
            SqlConnection Con = kon.Getcon();
            try
            {
                Con.Open();
                cmd = new SqlCommand("select * from tbsiswa", Con);
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
                Con.Close();
            }
        }

        void cleardata()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "";
            textBox5.Text = "";
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
                MessageBox.Show("Anda belum lengkap memasukan data");
            }
            else {
                SqlConnection conn = kon.Getcon();
                try
                {
                    cmd = new SqlCommand("insert into tbsiswa values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data berhasi");
                    tampildata();
                    cleardata();

                }
                catch(Exception x) {
                    MessageBox.Show(x.ToString());
                }
            }
        }
    }
}