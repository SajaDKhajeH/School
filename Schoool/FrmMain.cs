﻿using School.DataAccess;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmStudents().Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var t = new Teacher();
            t.Insert("ali", "alavi", "0912");
        }
    }
}