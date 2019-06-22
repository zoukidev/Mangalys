using MangalysProtocol.Network;
using MangalysProtocol.Messages;
using System;
using System.Windows.Forms;
using System.Threading;

namespace MangalysClient
{
    public partial class Form1 : Form
    {
        ClientListener Client = new ClientListener();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormDispatcher.RichTextBox = richTextBox1;

            Client.OnStatusUpdate += OnStatusUpdate;
            Client.OnReceive += OnReceive;

            Client.Start("127.0.0.1", 3000);

            //Client.Send(new BasicInfoMessage("is Demo"));

            // Thread.Sleep(200);
            // Client.Send(new BasicAnotherInfoMessage("Another demo"));
        }

        private void OnStatusUpdate(string status)
        {
            FormDispatcher.AppendLog(status + Environment.NewLine);
        }

        private void OnReceive(byte[] buffer)
        {
            FormDispatcher.AppendLog($"on receive {buffer.Length} bytes" + Environment.NewLine);
        }
    }
}
