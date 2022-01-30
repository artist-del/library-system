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

namespace WindowsFormsApplication1
{
    public partial class books_daily_record : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public books_daily_record()
        {
            InitializeComponent();
        }

        private void report_books_remain_retain_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            books_record();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            int i =0;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
           

                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dbo.issue_books where id = " + i + "";
                cmd.ExecuteNonQuery();
                books_record();
                

                MessageBox.Show("Record Successfully Delete");


           
        }
        public void books_record()
        {
            try
            {
                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.issue_books";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
        }
    }
}
