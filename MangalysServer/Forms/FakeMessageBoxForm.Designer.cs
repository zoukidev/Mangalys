﻿namespace MangalysServer.Forms
{
    partial class FakeMessageBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.msg_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MsgType_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnType_listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(169, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // title_textBox
            // 
            this.title_textBox.Location = new System.Drawing.Point(12, 32);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(508, 26);
            this.title_textBox.TabIndex = 2;
            // 
            // msg_richTextBox
            // 
            this.msg_richTextBox.Location = new System.Drawing.Point(12, 196);
            this.msg_richTextBox.Name = "msg_richTextBox";
            this.msg_richTextBox.Size = new System.Drawing.Size(508, 83);
            this.msg_richTextBox.TabIndex = 3;
            this.msg_richTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Message";
            // 
            // MsgType_listBox
            // 
            this.MsgType_listBox.FormattingEnabled = true;
            this.MsgType_listBox.ItemHeight = 20;
            this.MsgType_listBox.Location = new System.Drawing.Point(12, 88);
            this.MsgType_listBox.Name = "MsgType_listBox";
            this.MsgType_listBox.Size = new System.Drawing.Size(508, 24);
            this.MsgType_listBox.TabIndex = 6;
            this.MsgType_listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Button Type";
            // 
            // BtnType_listBox
            // 
            this.BtnType_listBox.FormattingEnabled = true;
            this.BtnType_listBox.ItemHeight = 20;
            this.BtnType_listBox.Location = new System.Drawing.Point(12, 142);
            this.BtnType_listBox.Name = "BtnType_listBox";
            this.BtnType_listBox.Size = new System.Drawing.Size(508, 24);
            this.BtnType_listBox.TabIndex = 8;
            // 
            // FakeMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 363);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnType_listBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MsgType_listBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msg_richTextBox);
            this.Controls.Add(this.title_textBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FakeMessageBoxForm";
            this.Text = "FakeMessageBoxForm";
            this.Load += new System.EventHandler(this.FakeMessageBoxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.RichTextBox msg_richTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox MsgType_listBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox BtnType_listBox;
    }
}