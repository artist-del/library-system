using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mdi_user : Form
    {
        private int childFormNumber = 0;

        public mdi_user()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_books ab = new add_books();
            ab.Show();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_books vb = new view_books();
            vb.Show();
        }

        private void mdi_user_Load(object sender, EventArgs e)
        {

        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_student_info asi = new add_student_info();
            asi.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_student_info vsi = new view_student_info();
            vsi.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void viewBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            view_books nb = new view_books();
            nb.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            issue_books ib = new issue_books();
            ib.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            books_return br = new books_return();
            br.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_page lp = new Login_page();
            lp.Show();
            this.Hide();
        }

        private void booksRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            books_stock bs = new books_stock();
            bs.Show();
        }

        private void booksDailyWeeklyRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            books_daily_record bdr = new books_daily_record();
            bdr.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
