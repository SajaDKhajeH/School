using School.BLL;
using School.Model.DTO;
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
        public event Action<CreateStudentModel,int> StudentUpdated;
        public Action OnStudentInserted;
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StudentService st = new StudentService();
            var data = new CreateStudentModel
            {
                FirstName = txtName.Text,
                Mobile = txtMobile.Text,
                LastName = txtLastName.Text
            };
            var result = st.Insert(data);
            if (result.Success)
            {
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
