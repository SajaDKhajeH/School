using School.Model;
using Stimulsoft.Report;
using Stimulsoft.Report.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmTestReport : Form
    {
        public FrmTestReport()
        {
            InitializeComponent();
            Crack();

        }

        private void FrmTestReport_Load(object sender, EventArgs e)
        {
            FillDgv();
        }

        private void FillDgv()
        {
            var students = GetStudents();

            dataGridView1.DataSource = students.ToList();
        }

        private List<MyPrintTestItemModel> GetStudents()
        {
            List<MyPrintTestItemModel> students = new List<MyPrintTestItemModel>();

            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                students.Add(new MyPrintTestItemModel
                {
                    Name = "StudentNumber " + i,
                    LastName = Guid.NewGuid().ToString(),
                    Radif = i + 1,
                    Score = rnd.Next(1, 20),
                    Address = Guid.NewGuid().ToString() + "salam" + Guid.NewGuid().ToString()
                });
            }
            students = students.Where(x => x.Name.Contains(textBox1.Text)).ToList();
            return students;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crack();

            string path = Path.Combine(Application.StartupPath, "Reports", "ReportStudents.mrt");
            StiReport stiReport = new StiReport();
            stiReport.Load(path);

            stiReport.Dictionary.Variables["AcademyTitle"].Value = "آموزشگاه زبان لیمس";
            stiReport.Dictionary.Variables["ReportDate"].Value = DateTime.Now.ToShortDateString();
            stiReport.Dictionary.Variables["ReportTime"].Value = DateTime.Now.TimeOfDay.ToString();
            stiReport.Dictionary.Variables["Logo"].ValueObject = File.ReadAllBytes("1.png");

            var students = GetStudents();
            stiReport.RegBusinessObject("BOStudents", students);

            var chart = stiReport.GetComponentByName("Chart1") as StiChart;

            stiReport.RegData("MyChartData", students.Select(x => new { x.Name, x.Score }).ToList());

            chart.DataSourceName = "MyChartData";

            stiReport.Render();
            stiReport.ExportDocument(StiExportFormat.Pdf, Path.Combine(Application.StartupPath, DateTime.Now.Ticks.ToString() + ".pdf"));
            //stiReport.Print();
            //stiReport.Show();
        }

        private void Crack()
        {
            string lk;
            string acc;

            lk = Path.Combine(Application.StartupPath, "license.key");
            acc = Path.Combine(Application.StartupPath, "account.dat");

            string stiDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Stimulsoft");

            string lkDes = Path.Combine(stiDir, "license.key");
            string accDes = Path.Combine(stiDir, "account.dat");

            if (!File.Exists(lkDes))
                File.Copy(lk, lkDes);
            if (!File.Exists(accDes))
                File.Copy(acc, accDes);

        }
    }
}
