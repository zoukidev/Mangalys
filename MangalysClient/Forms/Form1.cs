using MangalysClient.Managers.Process;
using MangalysProtocol.Enums;
using MangalysProtocol.Messages;
using MangalysProtocol.Network;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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

            Thread t = new Thread(new ThreadStart(StartClient));
            t.IsBackground = true;

            Thread.Sleep(200);
            t.Start();
        }

        private void StartClient()
        {
            Client.OnStatusUpdate += OnStatusUpdate;
            Client.OnReceive += OnReceive;
            Client.Start("127.0.0.1", 3000);


            Client.Send(new MangalysProtocol.Messages.BasicInfoMessage(Environment.MachineName, Environment.UserName));
        }

        private void OnStatusUpdate(ClientStatusEnums status)
        {
            FormDispatcher.AppendLog(status + Environment.NewLine);
        }

        private void OnReceive(byte[] buffer)
        {
            FormDispatcher.AppendLog($"on receive {buffer.Length} bytes" + Environment.NewLine);
        }
    }
}
