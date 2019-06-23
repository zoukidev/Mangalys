using MangalysProtocol.Network;
using System;
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

            Client.OnStatusUpdate += OnStatusUpdate;
            Client.OnReceive += OnReceive;

            Client.Start("127.0.0.1", 3000);

            var msg = new MangalysProtocol.Messages.BasicInfoMessage("is Demo");
            msg.SpecialName = "Retest";
            Client.Send(msg);
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
