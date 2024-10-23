using School.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmStudent : ChangeDbFormBase<StudentDto>
    {
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
                //StudentInserted?.Invoke(data, null);
                OnInserted(data);
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
