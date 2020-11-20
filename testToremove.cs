using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Test3Bot
{
    public partial class testToremove : Form
    {
        static string token = "1435782913:AAFSobKEno3EcqLZ9gfCG38w9sUWlnd3UkQ";
        TelegramBotClient Client = new TelegramBotClient(token);
        public testToremove()
        {
            InitializeComponent();
        }
        ChatId RemoverId = new ChatId(129079785);
        ChatId Me = new ChatId(100);
        private void ListenButton_Click(object sender, EventArgs e)
        {

            Client.OnMessage += Client_OnMessage;
            Client.StartReceiving();
        }

        private async void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (!e.Message.From.IsBot)
            {
                if (Me.Identifier != e.Message.From.Id)
                {
                    try
                    {
                        await Client.SendTextMessageAsync(RemoverId, "/start");
                        Me = new ChatId(e.Message.From.Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    await Client.ForwardMessageAsync(RemoverId, e.Message.From.Id, e.Message.MessageId);
            }
            else
            {
                await Client.ForwardMessageAsync(Me, RemoverId, e.Message.MessageId);
            }

        }

        private void Stop_Click(object sender, EventArgs e)
        {

        }
    }
}
