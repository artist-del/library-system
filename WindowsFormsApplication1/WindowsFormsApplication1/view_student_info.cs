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
    public partial class view_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public view_student_info()
        {
            InitializeComponent();
        }

        private void view_student_info_Load(object sender, EventArgs e)
        {
            student_Info();
           
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.Student_info where id=" + i + "";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    studentname.Text = dr["student_name"].ToString();
                    middle_name.Text = dr["student_Mname"].ToString();
                    last_name.Text = dr["student_Lname"].ToString();
                    studentcourse.Text = dr["student_course"].ToString();
                    student_address.Text = dr["student_address"].ToString();
                    student_email.Text = dr["student_email"].ToString();
                    student_No.Text = dr["student_contact"].ToString();
                    pictureBox1.ImageLocation = dr["image_str"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update dbo.Student_info set student_name = '" + studentname.Text + "',student_Mname='"+ middle_name.Text +"', student_Lname='"+ last_name.Text +"', student_course='" + studentcourse.Text + "', student_address='" + student_address.Text + "', student_email='" + student_email.Text + "', student_contact='" + student_No.Text + "' where id = "+i+"";
                cmd.ExecuteNonQuery();
                con.Close();
                student_Info();
                MessageBox.Show("Update Successfully!");
                panel1.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void student_Info()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.Student_info";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            int i = 0;
            try
            {



                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from dbo.Student_info where student_name like('%" + textBox1.Text + "%') ";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    if (i == 0)
                    {
                        MessageBox.Show("No Student found!");
                    }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void student_email_TextChanged(object sender, EventArgs e)
        {

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
                cmd.CommandText = "Delete from dbo.student_info where id = "+i+"";
                cmd.ExecuteNonQuery();
                con.Close();
                student_Info();
                MessageBox.Show("Successfully Delete!!");
                panel1.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
