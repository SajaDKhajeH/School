using Newtonsoft.Json;
using School.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmChat : Form
    {
        int studentId;
        public FrmChat(int id)
        {
            InitializeComponent();
            studentId = id;
        }
        ApiStudentResponse student;
        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var chat = new ChatModel
            {
                Text = txtText.Text,
                From = student,
                To = new ApiStudentResponse
                {
                    FullName = cmbTo.Text,
                    Id = cmbTo.SelectedIndex + 1
                },
            };
            var json = JsonConvert.SerializeObject(chat);
            StringContent sc = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7081/Chat", sc);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<OperationResult>(content);
                if (res.Success)
                {
                    RefreshData();
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
        }

        private async void RefreshData()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7081/Chat");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<OperationResult<ChatModel[]>>(content);
                if (res.Success)
                {
                    var messages = res.Data;
                    rtxtOtherMessage.ResetText();
                    rtxtMyMessage.ResetText();
                    foreach (var message in messages)
                    {
                        if (message.From.Id == studentId)
                        {
                            rtxtMyMessage.AppendText(message.Text + "-" + message.Time);
                        }
                        if (message.To.Id == studentId)
                        {
                            rtxtOtherMessage.AppendText(Environment.NewLine);
                            rtxtOtherMessage.AppendText(message.From.FullName);
                            rtxtOtherMessage.AppendText(Environment.NewLine);
                            rtxtOtherMessage.AppendText(message.Text);
                            rtxtOtherMessage.AppendText(Environment.NewLine);
                            rtxtOtherMessage.AppendText(message.Time.ToString());
                            rtxtOtherMessage.AppendText(Environment.NewLine);
                            rtxtOtherMessage.AppendText("---------------------");
                        }
                    }
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
        }

        private async void FrmChat_Load(object sender, EventArgs e)
        {
            await GetStudentInfoAsync();
            RefreshData();
        }

        private async Task GetStudentInfoAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7081/Student");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<OperationResult<ApiStudentResponse[]>>(content);
                if (res.Success)
                {
                    student = res.Data.Single(x => x.Id == studentId);
                    label1.Text = student.FullName;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
