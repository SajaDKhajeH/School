using School.BLL;
using School.Model;
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
    public partial class FrmLesson : Form
    {
        public FrmLesson()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            LessonDto lesson = new LessonDto()
            {
                Title = txtTitle.Text
            };
            Lesson l = new Lesson();
            var result = l.Insert(lesson);
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
