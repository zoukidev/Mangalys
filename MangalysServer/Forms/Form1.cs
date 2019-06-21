using MangalysProtocol.Network;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MangalysServer
{
    public partial class Form1 : Form
    {
        ServerListener Server = new ServerListener();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormDispatcher.RichTextBox = richTextBox1;

            Network.Handle.Setup();

            Server.OnStatusUpdate += OnStatusUpdate;
            Server.OnAccept += OnAccept;
            Server.OnReceive += OnReceive;

            Server.Start("127.0.0.1", 3000);
        }

        private void OnStatusUpdate(string status)
        {
            FormDispatcher.AppendLog(status + Environment.NewLine);
        }

        private void OnAccept(Client client)
        {
            FormDispatcher.AppendLog("on new client accepted" + Environment.NewLine);
        }

        private void OnReceive(Client client, byte[] buffer)
        {
            Network.Handle.Process(client, buffer);
        }
    }
}
