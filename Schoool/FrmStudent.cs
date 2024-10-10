using School.DataAccess;
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
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            var result = st.Insert(txtName.Text, txtLastName.Text, txtMobile.Text);
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
