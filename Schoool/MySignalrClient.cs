using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoool
{
    public class MySignalrClient
    {

        public event Action<int, string> OnMessageRecive;
        HubConnection hub;
        int userId;
        public MySignalrClient(int userId)
        {
            this.userId = userId;
        }
        public void Connect()
        {
            hub = new HubConnectionBuilder()
               .WithAutomaticReconnect()
               .WithUrl("https://localhost:7276/MyChatHub", h =>
                {
                    h.Headers.Add("userId", userId.ToString());
                }).Build();

            hub.StartAsync();

            hub.On<int, string>("ReciveMessage", (userId, msg) =>
              {
                  OnMessageRecive(userId, msg);
              });
        }

        public void Send(int userId,string msg)
        {
            hub.SendAsync("SendMessage", userId, msg);
        }
    }
}
