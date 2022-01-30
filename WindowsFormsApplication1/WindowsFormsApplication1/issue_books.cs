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
    public partial class issue_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public issue_books()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int books_qty =0;

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from dbo.books_info where book_name = '" + book_name.Text + "'";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                books_qty = Convert.ToInt32(dr2["available_qty"].ToString());
            }
            if (books_qty > 0)
            {


                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.issue_books values ('" + fname.Text + "', '" + Mname.Text + "', '" + Lname.Text + "', '" + student_contact.Text + "', '" + student_email.Text + "', '" + book_name.Text + "', '" + dateTimePicker1.Value.ToShortDateString() + "', '" + student_address.Text + "','" + student_course.Text + "', '')";
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.books_info set available_qty = available_qty-1 where book_name = '" + book_name.Text + "'";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Books Issue successfully");
                textBox1.Text = "";
                fname.Text = "";
                student_course.Text = "";
                student_address.Text = "";
                student_contact.Text = "";
                student_email.Text = "";
                book_name.Text = "";
                Mname.Text = "";
                Lname.Text = "";


            }
            else
            {
                MessageBox.Show("No Books Available");
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.Student_info where student_name='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 0)
                {
                    MessageBox.Show("This Name not found");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        fname.Text = dr["student_name"].ToString();
                        Mname.Text = dr["student_Mname"].ToString();
                        Lname.Text = dr["student_Lname"].ToString();
                        student_course.Text = dr["student_course"].ToString();
                        student_address.Text = dr["student_address"].ToString();
                        student_contact.Text = dr["student_contact"].ToString();
                        student_email.Text = dr["student_email"].ToString();
                        pictureBox1.ImageLocation = dr["image_str"].ToString();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void issue_books_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void txt_bookName_KeyUp(object sender, KeyEventArgs e)
        {

            int count = 0;

            if (e.KeyCode != Keys.Enter)
            {

                listBox1.Items.Clear();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.books_info where book_name like('%"+book_name.Text+"%')";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["book_name"].ToString());
                    }
                }
            }
        }

        private void txt_bookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_bookName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                book_name.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
                book_name.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
