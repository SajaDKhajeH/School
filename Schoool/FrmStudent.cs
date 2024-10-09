using Models;
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
            var st = new BLL.Student();
            var student = new StudentModel()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Mobile = txtMobile.Text
            };
            var res = st.Insert(student);
            if (!string.IsNullOrEmpty(res))
            {
                MessageBox.Show(res);
            }
        }
    }
}
