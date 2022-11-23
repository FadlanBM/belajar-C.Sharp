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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_siswa"].Value.ToString();
                textBox2.Text = row.Cells["nis"].Value.ToString();
                textBox3.Text = row.Cells["no_absen"].Value.ToString();
                textBox4.Text = row.Cells["nama"].Value.ToString();
                textBox5.Text = row.Cells["kelas"].Value.ToString();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum lengkap");
            }
            else
            {
                SqlConnection con = konn.getconn();
                try
                {
                    cmd = new SqlCommand("Update tbsiswa Set id_siswa='" + textBox1.Text + "',nis='" + textBox2.Text + "',no_absen='" + textBox3.Text + "',nama='" + textBox4.Text + "',kelas='" + textBox5.Text + "' where id_siswa='" + textBox1 + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update data berhasi");
                    tampildata();
                    cleardata();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());

                }
            }
        }
    }
}
