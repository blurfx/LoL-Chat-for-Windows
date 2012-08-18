namespace LoLChat_for_Windows
{
    partial class FrmChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChat));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rtbSendMessage = new System.Windows.Forms.RichTextBox();
            this.rtbConversation = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 197);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(341, 39);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // rtbSendMessage
            // 
            this.rtbSendMessage.Location = new System.Drawing.Point(0, 197);
            this.rtbSendMessage.Multiline = false;
            this.rtbSendMessage.Name = "rtbSendMessage";
            this.rtbSendMessage.Size = new System.Drawing.Size(340, 38);
            this.rtbSendMessage.TabIndex = 6;
            this.rtbSendMessage.Text = "";
            this.rtbSendMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbSendMessage_KeyDown);
            // 
            // rtbConversation
            // 
            this.rtbConversation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConversation.Location = new System.Drawing.Point(0, 0);
            this.rtbConversation.Name = "rtbConversation";
            this.rtbConversation.ReadOnly = true;
            this.rtbConversation.Size = new System.Drawing.Size(341, 197);
            this.rtbConversation.TabIndex = 7;
            this.rtbConversation.Text = "";
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 236);
            this.Controls.Add(this.rtbConversation);
            this.Controls.Add(this.rtbSendMessage);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmChat";
            this.Text = "Chat";
            this.Activated += new System.EventHandler(this.FrmChat_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChat_FormClosing);
            this.Load += new System.EventHandler(this.FrmChat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox rtbSendMessage;
        private System.Windows.Forms.RichTextBox rtbConversation;
    }
}