using School.BLL;
using School.DataAccess;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //System.Timers.Timer t = new System.Timers.Timer();
            ////System.Threading.Timer timer = new System.Threading.    
            //t.Interval = 1000;
            //t.Elapsed += T_Elapsed;
            //t.Start();
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

        private async void btnSendSMS_Click(object sender, EventArgs e)
        {
            int succ = 0;
            int fail = 0;
            List<SmsModel> list = GetMembers();
            SMS sms = new SMS();

            //0
            await SaveChangeAsync(1);
            await SaveChangeAsync(2);
            await SaveChangeAsync(3);
            //3

            //0
            var t1 = SaveChangeAsync(1);
            var t2 = SaveChangeAsync(2);
            var t3 = SaveChangeAsync(3);

            await Task.WhenAll(t1, t2, t3);
            Task.WaitAll(t1, t2, t3);
            //1.5

            //await Task.Run(() =>
            //{
            // foreach (var item in list)
            // {
            //     new Thread((() =>
            //     {
            //         if (sms.SendSMS(item))
            //         {
            //             succ++;
            //         }
            //         else
            //         {
            //             fail++;
            //         }
            //     })).Start();
            // }
            // await Task.Run(async () =>
            //{
            //    while (succ + fail != list.Count)
            //    {
            //        await Task.Delay(1);
            //    }
            //});
            //});
            List<int> items = new List<int>();
            Dictionary<string, string> s = new Dictionary<string, string>();
            object o = new object();

            await Task.Run(() =>
            {
                return "";
            }).ContinueWith((i) =>
            {

            }).ContinueWith(z =>
            {

            });
            label1.Text = "";

            await Task.Run(() =>
            {
                Parallel.ForEach(list, (item) =>
                {
                    bool suucess = sms.SendSMS(item);
                    lock (o)
                    {
                        if (suucess)
                        {
                            succ++;

                            Interlocked.Increment(ref succ);
                            //succ++;
                        }
                        else
                        {
                            fail++;
                        }
                    };
                });
            });

            lblSucc.Text = succ.ToString();
            lblError.Text = fail.ToString();
            //MessageBox.Show(items.Count.ToString());
        }
        async Task SaveChangeAsync(int o)
        {

        }
        private List<SmsModel> GetMembers()
        {
            var list = new List<SmsModel>();

            for (int i = 0; i < 10000; i++)
            {
                list.Add(new SmsModel
                {
                    Mobile = "0913239" + i,
                    Text = i.ToString()
                });
            }
            return list;
        }
    }
}
