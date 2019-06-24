using MangalysProtocol.Enums;
using MangalysProtocol.Network;
using MangalysServer.Forms;
using MangalysServer.Managers;
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

        #region "Form"
        private void Form1_Load(object sender, EventArgs e)
        {
            FormDispatcher.RichTextBox = richTextBox1;
            FormDispatcher.ActionCtxMenuStrip = contextMenuStrip1;
            FormDispatcher.TreeView = treeView1;

            Thread t = new Thread(new ThreadStart(StartServer));
            t.IsBackground = true;
            t.Start();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new FakeMessageBoxForm();
            form.Show();
        }
        #endregion

        #region "Networking"
        private void StartServer()
        {
            Server.OnStatusUpdate += OnStatusUpdate;
            Server.OnNewClient += OnNewClient;
            Server.OnClientDisconnect += OnClientDisconnect;
            Server.OnReceive += OnReceive;

            Server.Start("127.0.0.1", 3000);

            Network.Handle.Setup();
        }

        private void OnStatusUpdate(ServerStatusEnums status)
        {
            FormDispatcher.AppendLog(status + Environment.NewLine);
        }

        private void OnNewClient(Socket socket)
        {
            ClientsManager.Clients.Add(new Network.Client(socket));
        }

        private void OnClientDisconnect(Socket socket)
        {
            Network.Client client = ClientsManager.Find(socket);
            
            if (client != null)
            {
                ClientsManager.Clients.Remove(client);

                FormDispatcher.RefreshList(ClientsManager.Clients.ToArray());
                FormDispatcher.AppendLog("Un Utilisateur se déconnecte" + Environment.NewLine);
            }
        }

        private void OnReceive(Socket socket, byte[] buffer)
        {
            Network.Client client = ClientsManager.Find(socket);
            Network.Handle.Process(client, buffer);
        }
        #endregion
    }
}
