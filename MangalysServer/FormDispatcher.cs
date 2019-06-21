using System;
using System.Windows.Forms;

namespace MangalysServer
{
    public class FormDispatcher
    {
        public static RichTextBox RichTextBox { get; set; }

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
    }
}
