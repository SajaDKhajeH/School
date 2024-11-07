using School.BLL;
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
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void FillDGV()
        {
            StudentService st = new StudentService();
            dataGridView1.DataSource = st.GetData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent frm = new FrmStudent();
            frm.StudentInserted += Frm_StudentInserted;
            frm.OnStudentInserted = FillDGV;
            frm.ShowDialog();
            FillDGV();
        }
        private void Frm_StudentInserted(object sender, EventArgs e)
        {
            FillDGV();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[ColDelete.Name].Index)
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    var id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                    StudentService service = new StudentService();
                    var result = service.Delete(id);
                    if (result.Success)
                    {
                        FillDGV();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
            }
        }
    }
}
