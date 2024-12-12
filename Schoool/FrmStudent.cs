using School.BLL;
using School.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmStudent : Form
    {
        //public delegate void StudentInsertedHandler(StudentDto studentDto);
        public event EventHandler StudentInserted;
        public event Action<CreateStudentModel, int> StudentUpdated;
        public Action OnStudentInserted;
        public FrmStudent()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {

            var child1 = new CreateStudentModel
            {
                FirstName = txtName.Text,
                Mobile = txtMobile.Text,
                LastName = txtLastName.Text
            };
            btnSubmit.Text = "pls wait";
            btnSubmit.Enabled = false;
            Stopwatch sw = Stopwatch.StartNew();
            //Thread th = new Thread(new ThreadStart(() =>
            //  {
            //      sw.Stop();
            //      Console.WriteLine(sw.ElapsedMilliseconds);
            //      using (StudentService st = new StudentService())
            //      {
            //          var result = st.Insert(child1);
            //          Invoke(new Action(() =>
            //          {
            //              if (result.Success)
            //              {
            //                  OnStudentInserted();
            //              }
            //              ShowToast(result.Message, result.Success);
            //              btnSubmit.Text = "submit";
            //              btnSubmit.Enabled = true;
            //          }));

            //      }
            //  }));
            //th.Start();

            var result = await Task.Run(() =>
            {
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                using (StudentService st = new StudentService())
                {
                    return st.Insert(child1);
                }
            });
            if (result.Success)
            {
                OnStudentInserted();
            }
            ShowToast(result.Message, result.Success);
            btnSubmit.Text = "submit";
            btnSubmit.Enabled = true;
        }


        private void ShowToast(string message, bool success)
        {
            lblToast.Text = message;
            if (success)
                lblToast.ForeColor = Color.Green;
            else
                lblToast.ForeColor = Color.Red;
        }
    }
}
