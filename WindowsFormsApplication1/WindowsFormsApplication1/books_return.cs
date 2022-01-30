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
    public partial class books_return : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public books_return()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            fill_grid(textBox1.Text);
        }

        private void books_return_Load(object sender, EventArgs e)
        {
           
            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
           
        }
        public void fill_grid(string name)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.issue_books where student_name='" + name.ToString() + "' and books_return_date = ''";
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_RowDefaultCellStyleChanged(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dbo.issue_books where id="+i+"";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lbl_books_name.Text = dr["book_name"].ToString();
                lbl_issue_date.Text = dr["books_issue_date"].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update dbo.issue_books set books_return_date = '"+ dateTimePicker1.Value.ToString() +"' where Id = "+i+"";
            cmd.ExecuteNonQuery();
            

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update dbo.books_info set available_qty = available_qty+1 where book_name = '"+lbl_books_name.Text+"'";
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Books are Successfully Return!");

            panel2.Visible = false;

            fill_grid(textBox1.Text);
            

        }

       
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_books_name_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
