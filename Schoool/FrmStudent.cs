using School.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmStudent : Form
    {
        //public delegate void StudentInsertedHandler(StudentDto studentDto);
        public event EventHandler StudentInserted;
        public event Action<StudentDto,int> StudentUpdated;
        public Action OnStudentInserted;
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            var data = new StudentDto
            {
                FirstName = txtName.Text,
                Mobile = txtMobile.Text,
                LastName = txtLastName.Text
            };
            var result = st.Insert(data);
            if (result.Success)
            {
                //if (StudentInserted != null)
                //{
                //    StudentInserted(data, null);
                //}
                //StudentInserted?.Invoke(data, null);
                OnStudentInserted();
            }
            ShowToast(result.Message, result.Success);
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
