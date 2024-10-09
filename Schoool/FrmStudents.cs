using School.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void FillDGV()
        {
            Student st = new Student();
            string msg = "";
            dataGridView1.DataSource = st.GetData(txtSearch.Text, ref msg);
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent frm = new FrmStudent();
            frm.ShowDialog();
            FillDGV();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDGV();
        }
    }
}
