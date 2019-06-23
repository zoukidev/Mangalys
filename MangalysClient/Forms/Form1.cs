using MangalysProtocol.Messages;
using MangalysProtocol.Network;
using System;
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

            Client.OnStatusUpdate += OnStatusUpdate;
            Client.OnReceive += OnReceive;

            Client.Start("127.0.0.1", 3000);

            Client.Send(new MangalysProtocol.Messages.BasicInfoMessage("DemoMaboule"));

            pictureBox1.Image = TakeScreenshot();
        }

        private void OnStatusUpdate(string status)
        {
            FormDispatcher.AppendLog(status + Environment.NewLine);
        }

        private void OnReceive(byte[] buffer)
        {
            FormDispatcher.AppendLog($"on receive {buffer.Length} bytes" + Environment.NewLine);
        }

        private Bitmap TakeScreenshot()
        {

            var bmpScreenshot = new Bitmap(
                Screen.PrimaryScreen.Bounds.Width / 2,
                Screen.PrimaryScreen.Bounds.Height / 2,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            using (var gfxScreenshot = Graphics.FromImage(bmpScreenshot))
            {
                gfxScreenshot.CopyFromScreen(
                    Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0,
                    0,
                    Screen.PrimaryScreen.Bounds.Size,
                    CopyPixelOperation.SourceCopy
                );
            }

            return bmpScreenshot;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = TakeScreenshot();

            Thread.Sleep(200);

            var image = ImageToByteArray(pictureBox1.Image);
            Console.WriteLine("image length: "+image.Length);
            Client.Send(new MangalysProtocol.Messages.BasicVideoMessage(image));
        }
    }
}
