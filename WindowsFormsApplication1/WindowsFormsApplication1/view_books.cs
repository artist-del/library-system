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
    public partial class view_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public view_books()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void view_books_Load(object sender, EventArgs e)
        {
            disp_books();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.books_info where book_name like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("No Books Found!");

                    textBox1.Text = "";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.books_info where book_author like('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                con.Close();

                if (i == 0)
                {
                    MessageBox.Show("No Books Found!");
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.books_info where id=" + i + "";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    booksname.Text = dr["book_name"].ToString();
                    authorname.Text = dr["book_author"].ToString();
                    publication.Text = dr["book_publication"].ToString();
                    quantity_name.Text = dr["book_quantity"].ToString();
                }
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update dbo.books_info set book_name='"+booksname.Text+"', book_author='"+authorname.Text+"', book_publication='"+publication.Text+"', book_quantity='"+quantity_name.Text+"' where id = "+i+"";
                cmd.ExecuteNonQuery();
                con.Close();
                disp_books();
                MessageBox.Show("Record Update successfully");
                panel3.Visible = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void disp_books()
    {
        try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.books_info";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dbo.books_info where id = " + i + "";
                cmd.ExecuteNonQuery();
                con.Close();
                disp_books();
                MessageBox.Show("Book Successfully Delete");
                panel3.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
