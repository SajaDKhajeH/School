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
            var result = st.GetData();
            if (result.Success)
            {
                dataGridView1.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent frm = new FrmStudent();
            frm.Inserted += Frm_Inserted;
            frm.ShowDialog();
            FillDGV();
        }

        private void Frm_Inserted(School.BLL.StudentDto obj)
        {
            FillDGV();
        }

        string aaa(int z)
        {
            return "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDGV();
        }
    }
}
