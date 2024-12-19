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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmStudents : Form
    {
        CancellationTokenSource ts;
        public FrmStudents()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            ts = new CancellationTokenSource();
        }

        private async void FrmStudents_Load(object sender, EventArgs e)
        {
            ShowProgress(true);
            await FillDGVAsync();
            ShowProgress(false);
        }

        private void ShowProgress(bool showProgress)
        {
            panel1.Visible = showProgress;

            if (showProgress)
            {
                lblPlsWait.BringToFront();
            }
            else
            {
                lblPlsWait.SendToBack();
            }
        }
        private async Task FillDGVAsync()
        {
            var a = await Task.Run(async () =>
            {
                StudentService st = new StudentService();
                var items = await st.GetDataAsync(ts.Token);
                return items;
            });
            if (dataGridView1.Created)
                dataGridView1.DataSource = a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent frm = new FrmStudent();
            frm.StudentInserted += Frm_StudentInserted;

            frm.OnStudentInserted = () => { FillDGVAsync(); };

            frm.ShowDialog();
            FillDGVAsync();
        }
        private void Frm_StudentInserted(object sender, EventArgs e)
        {
            FillDGVAsync();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDGVAsync();
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
                        FillDGVAsync();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }
            }
        }

        private void FrmStudents_FormClosed(object sender, FormClosedEventArgs e)
        {
            ts.Cancel();
        }
    }
}
