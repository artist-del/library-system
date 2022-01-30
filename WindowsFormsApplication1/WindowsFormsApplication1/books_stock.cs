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
    public partial class books_stock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public books_stock()
        {
            InitializeComponent();
        }

        private void books_stock_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_books_info();
        }
        public void fill_books_info()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select book_name, book_author, book_quantity, available_qty from dbo.books_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Visible = true;
            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dbo.issue_books where book_name ='"+i.ToString()+"' and books_return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select book_name, book_author, book_quantity, available_qty from dbo.books_info where book_name like('%"+textBox1.Text+"%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView2.SelectedCells[4].Value.ToString();
            textBox2.Text = i.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            ////(username, password)
            //smtp.Credentials = new NetworkCredential("artzrase45@gmail.com", "artzayaterase1");
            ////(from, to, subject, body)
            //MailMessage mail = new MailMessage("artzrase45@gmail.com", textBox2.Text, "this is for book return notice", textBox3.Text);
            //mail.Priority = MailPriority.High;
            //smtp.Send(mail);
            //MessageBox.Show("mail send");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
