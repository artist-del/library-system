using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\rsu_library_system.mdf;Integrated Security=True;Connect Timeout=30");
        
        public add_books()
        {
            InitializeComponent();
        }

        private void add_books_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.books_info values('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "','"+ textBox4.Text+"')";
                cmd.ExecuteNonQuery();
                con.Close();



                MessageBox.Show("Books successfully added!");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }
    }
}
