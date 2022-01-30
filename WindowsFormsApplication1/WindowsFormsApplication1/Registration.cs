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
    public partial class Registration_page : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Registration_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.library_management_system values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();




                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                MessageBox.Show("Your Have Registered!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login_page lp = new Login_page();
            lp.Show();
            this.Hide();
        }

        private void Registration_page_Load(object sender, EventArgs e)
        {

        }
    }
}
