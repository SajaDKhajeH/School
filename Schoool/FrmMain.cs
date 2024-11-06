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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmStudents().Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //string[] branches = new string[]
            //{
            //    "شعبه اول",
            //    "شعبه دوم",
            //    "شعبه سوم"
            //};
            //cmbBranch.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            //cmbBranch.DataSource = branches.ToList();
            //cmbBranch.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cmbBranch.Text);
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            new FrmLessons().Show();
        }
        class St
        {
            public string Name { get; set; }
            public double Score { get; set; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //StudentDto ali = new StudentDto();
            //ali.FirstName = "علی";

            //StudentDto reza = ali;
            //reza.FirstName = "رضا";

            //MessageBox.Show(ali.FirstName);
            //MessageBox.Show(reza.FirstName);

            //string ali = "علی";
            //string reza = ali;
            //reza = "رضا";

            //MessageBox.Show(ali);
            //MessageBox.Show(reza);


            int[] numbers =
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,1,3,67,2,5,98,67,4,3,1
            };
            int a = numbers.First();
            int aa = numbers.FirstOrDefault();
            int aaa = numbers.Last();
            int aaaa = numbers.LastOrDefault();
            int aaaaa = numbers.Where(x => x == 10).Single();
            int aaaaaa = numbers.Where(x => x == 20).SingleOrDefault();
            int aaaaaaa = numbers.ElementAt(8);
            int aaaaaaaa = numbers.ElementAtOrDefault(90);

            var b = numbers.Distinct().ToArray();

            var g = numbers.Count();
            numbers.Min();
            numbers.Max();
            numbers.Average();

            St[] students = { new St { Name = "ali", Score = 20 }, new St { Name = "mary", Score = 0.75 } };



            students.Average(s => s.Score);

            var aaazzz = "aaass".Sum(x => x);
            //students.Sum(x => x);


            Console.WriteLine(aaaaaaaa);



            //Console.WriteLine();

            var floats = numbers.Where(num => (num % 2) != 0)
                .Select(x => (float)x);



            foreach (var f in floats)
            {
                Console.WriteLine(f);
            }

            var zoj =
                from num
                in numbers
                where (num % 2) == 0
                select num;

            var fard = numbers.Where(num => (num % 2) != 0);

            string name = "alireza";
            //string sss = new string(name.Where(c => c == 'a').ToArray());

            //var floats = numbers.Where(num => (num % 2) != 0)
            //    .Select(x => (float)x)
            //    .ToArray();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> l = new List<int>(6);
            Console.WriteLine(l.Capacity);
            l.Add(1);
            l.Add(1);
            l.Add(1);
            Console.WriteLine(l.Capacity);
            l.Add(1);
            l.Add(1);
            Console.WriteLine(l.Capacity);






        }

        private void button4_Click(object sender, EventArgs e)
        {
            var students = StudentDto.GetStudents();

            foreach (var student in students)
            {
                foreach (var lesson in student.Lessons)
                {
                    cmbBranch.Items.Add(lesson);
                }
            }

            students.ForEach(s => s.Lessons.ToList().ForEach(l => cmbBranch.Items.Add(l)));

            cmbBranch.Items.AddRange(students.SelectMany(x => x.Lessons).ToArray());

            int a = 5;
            int? xx = null;




            string aaaa = null;

            List<int> numbers = new List<int>();

            //numbers.Add(null);

            var aa = numbers.Max();

            // Console.WriteLine(aa ?? 10);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double price = 1_000_000;
                double? discount = null;
                if (txtDiscount.Text != "")
                {
                    if (txtDiscount.Text == "takh")
                    {
                        discount = 1000;
                    }
                }
                //double notNullDiscount = 0;
                //if (discount.HasValue)
                //    notNullDiscount = discount.Value;
                //double a = discount == null ? 0 : discount.Value;
                double finalPrice = price - (discount ?? 0);

                MessageBox.Show($"مبلغ نهایی {finalPrice}");

                List<string> men = new List<string>()
                {
                    "ali","reza","nosrat","solat","mahan","sajad"
                };
                List<string> women = new List<string>()
                {
                    "fateme","nosrat","solat","kosar","mahan"
                };

                var concated = men.Concat(women);

                var unioned = men.Union(women);

                var inter = men.Intersect(women);

                var exce = men.Except(women);


                MessageBox.Show($"مبلغ نهایی {finalPrice}");

            }
        }




        //bool WhereFard(int num)
        //{
        //    if ((num % 2) == 0)
        //        return false;
        //    else
        //        return true;
        //}
    }
}
