using School.BLL;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            System.Timers.Timer t = new System.Timers.Timer();
            //System.Threading.Timer timer = new System.Threading.    
            t.Interval = 1000;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
         
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmStudents().Show();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
        }
        private void btnLessons_Click(object sender, EventArgs e)
        {
            new FrmLessons().Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
