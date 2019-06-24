using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangalysServer.Forms
{
    public partial class FakeMessageBoxForm : Form
    {
        public FakeMessageBoxForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon;
            MessageBoxButtons button;

            Enum.TryParse<MessageBoxIcon>(MsgType_listBox.SelectedItem.ToString(), out icon);
            Enum.TryParse<MessageBoxButtons>(BtnType_listBox.SelectedItem.ToString(), out button);

            MessageBox.Show(msg_richTextBox.Text, title_textBox.Text, button, icon);
        }

        private void FakeMessageBoxForm_Load(object sender, EventArgs e)
        {
            // MessageBoxIcon
            MsgType_listBox.Items.Add("None");
            MsgType_listBox.Items.Add("Information");
            MsgType_listBox.Items.Add("Question");
            MsgType_listBox.Items.Add("Warning");
            MsgType_listBox.Items.Add("Error");

            // MessageBoxButtons
            BtnType_listBox.Items.Add("OK");
            BtnType_listBox.Items.Add("OKCancel");
            BtnType_listBox.Items.Add("YesNo");
            BtnType_listBox.Items.Add("YesNoCancel");
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
