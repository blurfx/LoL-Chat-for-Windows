using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using jabber.client;
using jabber.protocol.client;
using System.Runtime.InteropServices;

namespace LoLChat_for_Windows
{
    public partial class FrmChat : Form
    {
        StringBuilder conversation;


        public FrmChat()
        {
            InitializeComponent();
            conversation = new StringBuilder();
        }


        private string _mailId;

        public string MailId
        {
            get { return _mailId; }
            set { _mailId = value; }
        }

        private JabberClient _jabberClient;

        public JabberClient JabberClint
        {
            get { return _jabberClient; }
            set { _jabberClient = value; }
        }

        private int _frmChatIndex;

        public int FrmChatIndex
        {
            get { return _frmChatIndex; }
            set { _frmChatIndex = value; }
        }

        private bool _receiveFlag;

        public bool ReceiveFlag
        {
            get { return _receiveFlag; }
            set { _receiveFlag = value; }
        }


        private void FrmChat_Load(object sender, EventArgs e)
        {
            _jabberClient.OnMessage += new MessageHandler(_jabberClient_OnMessage);
            rtbSendMessage.Focus();
            
        }

        public void _jabberClient_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            if (!this.ReceiveFlag)
            {
                if (msg.From.Bare == this.MailId)
                {
                    if (msg.Body != "")
                    {
                        string receivedMsg = msg.From.User + " : " + msg.Body + "\n";
                        AppendConversation(receivedMsg);
                        msg.Body = "";
                        

                    }
                }
            }
            
            
        }

        public void AppendConversation(string str)
        {
            conversation.Append(str);
            rtbConversation.Text = conversation.ToString();
            rtbConversation.Focus();
            rtbConversation.SelectionStart = rtbConversation.Text.Length - 1;
            rtbConversation.ScrollToCaret();
            rtbSendMessage.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SendMessage()
        {
            if (rtbSendMessage.Text != "\n" && rtbSendMessage.Text != " ")
            {
                _jabberClient.Message(_mailId, rtbSendMessage.Text);
                string sentMsg = "³ª : " + rtbSendMessage.Text + "\n";
                AppendConversation(sentMsg);
                rtbSendMessage.Text = "";
            }
            
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            conversation = null;
            if (conversation == null)
                conversation = new StringBuilder();
            rtbConversation.Text = "";
        }

        private void rtbSendMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (rtbSendMessage.Text.Replace(" ", "") == "")
                {
                    return;
                }
                SendMessage();
                this.ReceiveFlag = false;
                e.Handled = true;
            }
        }

        //Overriding Form Close button
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg != 0x0010)
            {
                base.WndProc(ref m);
            }
            else
            {
                //Windows has send the WM_CLOSE message to your form.
                //Ignore this message will make the window stay open.
                ClearConversation();
            }
        }

        private void ClearConversation()
        {
            conversation = null;
            if (conversation == null)
                conversation = new StringBuilder();
            rtbConversation.Text = "";
            this.ReceiveFlag = false;
            this.Hide();
        }

        private void FrmChat_Activated(object sender, EventArgs e)
        {
            frmMain.StopFlashingWindow(this);
        }



    }
}