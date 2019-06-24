using System;
using System.Windows.Forms;

namespace MangalysServer
{
    public class FormDispatcher
    {
        public static RichTextBox RichTextBox { get; set; }
        public static PictureBox PictureBox { get; set; }
        public static TreeView TreeView { get; set; }
        public static ContextMenuStrip ActionCtxMenuStrip { get; set; }

        public static void AppendLog(string text)
        {
            if (RichTextBox.InvokeRequired)
            {
                RichTextBox.Invoke((MethodInvoker)delegate ()
                {
                    AppendLog(text);
                });
            }
            else
            {
                RichTextBox.AppendText(Environment.NewLine + text);
            }
        }

        public static void AddClient(string machinename, string username)
        {
            if (TreeView.InvokeRequired)
            {
                TreeView.Invoke((MethodInvoker)delegate ()
                {
                    AddClient(machinename, username);
                });
            } else
            {
                TreeView.BeginUpdate();
                TreeView.Nodes[0].Nodes.Add($"{username} ({machinename})");
                TreeView.Nodes[0].Nodes[0].ContextMenuStrip = ActionCtxMenuStrip;
                TreeView.EndUpdate();
            }
        }
    }
}
