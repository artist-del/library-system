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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class add_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public add_student_info()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                image_str.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void add_student_info_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.image_str.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.student_info values('" + fname.Text + "', '" + Mname.Text + "', '" + Lname.Text + "', @IMG, '" + Student_course.Text + "', '" + Student_address.Text + "', '" + Student_email.Text + "', '"+image_str.Text+"', '" + Student_contact.Text + "')";
                cmd.Parameters.Add(new SqlParameter("@IMG", imageBt));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Upload");

                fname.Text = "";
                Mname.Text = "";
                Lname.Text = "";
                Student_course.Text = "";
                Student_address.Text = "";
                Student_email.Text = "";
                image_str.Text = "";
                Student_contact.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Student_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Student_course_TextChanged(object sender, EventArgs e)
        {

        }

        private void Student_contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mname_TextChanged(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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
    }
}
