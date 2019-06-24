using MangalysProtocol.Network;
using MangalysServer.Forms;
using System;
using System.Net.Sockets;
using System.Threading;
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
            FormDispatcher.ActionCtxMenuStrip = contextMenuStrip1;
            FormDispatcher.TreeView = treeView1;

            Thread t = new Thread(new ThreadStart(StartServer));
            t.IsBackground = true;
            t.Start();
        }

        private void StartServer()
        {
            Server.OnStatusUpdate += OnStatusUpdate;
            Server.OnAccept += OnAccept;
            Server.OnReceive += OnReceive;

            Server.Start("127.0.0.1", 3000);

            Network.Handle.Setup();
        }

        private void OnStatusUpdate(string status)
        {
            FormDispatcher.AppendLog(status + Environment.NewLine);
        }

        private void OnAccept(Socket socket)
        {
            FormDispatcher.AppendLog("on new client accepted" + Environment.NewLine);
        }

        private void OnReceive(Socket socket, byte[] buffer)
        {
            Network.Handle.Process(socket, buffer);
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new FakeMessageBoxForm();
            form.Show();
        }
    }
}
