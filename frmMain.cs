using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jabber.client;
using System.Collections;
using jabber.protocol.iq;
using System.Runtime.InteropServices;

namespace LoLChat_for_Windows
{
    public partial class frmMain : Form
    {
        RosterManager rm;
        PresenceManager pm;
        FrmChat[] frmChat = new FrmChat[300];
        int chatCount = -1;
        Hashtable chatIndex = new Hashtable();

        FrmSetting frmSetting;
        #region Window Flashing API Stuff

        private const UInt32 FLASHW_STOP = 0; //Stop flashing. The system restores the window to its original state.
        private const UInt32 FLASHW_CAPTION = 1; //Flash the window caption.
        private const UInt32 FLASHW_TRAY = 2; //Flash the taskbar button.
        private const UInt32 FLASHW_ALL = 3; //Flash both the window caption and taskbar button.
        private const UInt32 FLASHW_TIMER = 4; //Flash continuously, until the FLASHW_STOP flag is set.
        private const UInt32 FLASHW_TIMERNOFG = 12; //Flash continuously until the window comes to the foreground.

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public UInt32 cbSize; //The size of the structure in bytes.
            public IntPtr hwnd; //A Handle to the Window to be Flashed. The window can be either opened or minimized.
            public UInt32 dwFlags; //The Flash Status.
            public UInt32 uCount; // number of times to flash the window
            public UInt32 dwTimeout; //The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
        }

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        
        public static void FlashWindow(Form win, UInt32 count = UInt32.MaxValue)
        {
            //Don't flash if the window is active
            if (win.Focus()) return;


            FLASHWINFO info = new FLASHWINFO
            {
                hwnd = win.Handle,
                dwFlags = FLASHW_TRAY | FLASHW_TIMERNOFG,
                uCount = count,
                dwTimeout = 0
            };

            info.cbSize = Convert.ToUInt32(Marshal.SizeOf(info));
            FlashWindowEx(ref info);
        }

        public static void StopFlashingWindow(Form win)
        {

            FLASHWINFO info = new FLASHWINFO();
            info.hwnd = win.Handle;
            info.cbSize = Convert.ToUInt32(Marshal.SizeOf(info));
            info.dwFlags = FLASHW_STOP;
            info.uCount = UInt32.MaxValue;
            info.dwTimeout = 0;

            FlashWindowEx(ref info);
        }

        #endregion
        
        public frmMain()
        {
            InitializeComponent();
        }


        private void jabberClient1_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            try
            {
                frmChat[(int)chatIndex[msg.From.Bare]].ReceiveFlag = true;
                string receivedMsg = frmChat[(int)chatIndex[msg.From.Bare]].Text + " : " + msg.Body + "\n";
                frmChat[(int)chatIndex[msg.From.Bare]].AppendConversation(receivedMsg);
                frmChat[(int)chatIndex[msg.From.Bare]].Show();

                FlashWindow(frmChat[(int)chatIndex[msg.From.Bare]]);

            }
            catch { }
        }

        void rm_OnRosterBegin(object sender)
        {
            this.Height = 505;

            frmChat = new FrmChat[300];
            chatIndex = new Hashtable();
            fRoster.BeginUpdate();
        }

        void rm_OnRosterEnd(object sender)
        {
            string[] digitStatus = {"","","","",""};
            fRoster.EndUpdate();

            if (Properties.Settings.Default.digitStats != "")
                digitStatus = Properties.Settings.Default.digitStats.Split('|');
            
            jabberClient1.Presence(jabber.protocol.client.PresenceType.available,
                //"<body><level>9001</level><wins>9001</wins><leaves>0</leaves><rankedWins>218</rankedWins><rankedLosses>55</rankedLosses><rankedRating>2888</rankedRating><<gameStatus>outOfGame</gameStatus></body>",
                "<body><profileIcon>668</profileIcon><level>" + digitStatus[0] + "</level><wins>" + digitStatus[1] + "</wins><leaves>0</leaves><queueType>RANKED_SOLO_5x5</queueType><rankedWins>" + digitStatus[2] + 
                "</rankedWins><rankedLosses>" + digitStatus[3] + "</rankedLosses><rankedRating>" + digitStatus[4] + "</rankedRating><statusMsg>"
            + Properties.Settings.Default.statMsg + "</statusMsg><gameStatus>outOfGame</gameStatus><tier>PLATINUM</tier></body>",
                null, 0);

            fRoster.ExpandAll();
            fRoster.Nodes[0].EnsureVisible();

            if (chkRemId.Checked)
            {
                Properties.Settings.Default.user_id = txtID.Text;
                Properties.Settings.Default.password = txtPW.Text;
                Properties.Settings.Default.lastServ = cbServer.SelectedIndex;
                Properties.Settings.Default.Save();
            }

            tray.Text = "Connected : " + cbServer.Text + " Server";
            tray.Visible = true;

        }

        void rm_OnRosterItem(object sender, Item ri)
        {
            try
            {
                chatIndex.Add(ri.JID.Bare, ++chatCount);
                InitializeFrmChat(ri.JID.Bare, ri.Nickname);
            }
            catch { }
        }

        private void InitializeFrmChat(string targetId, string nickName)
        {
            frmChat[chatCount] = new FrmChat();
            frmChat[chatCount].MailId = targetId;
            frmChat[chatCount].JabberClint = jabberClient1;
            if (nickName != null)
                frmChat[chatCount].Text = nickName;
            else
                frmChat[chatCount].Text = (targetId.Split('@'))[0];
            frmChat[chatCount].JabberClint.OnMessage += new MessageHandler(frmChat[chatCount]._jabberClient_OnMessage);

        }

        private void rosterTree1_DoubleClick(object sender, EventArgs e)
        {
            muzzle.RosterTree.ItemNode n = fRoster.SelectedNode as muzzle.RosterTree.ItemNode;
            if (n == null)
                return;

            frmChat[(int)chatIndex[n.JID.Bare]].Show();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtPW.Text == "") return;
            jabberClient1.User = txtID.Text;
            jabberClient1.Password = "AIR_" + txtPW.Text;

            jabberClient1.NetworkHost = "chat." + retChatServer(cbServer.SelectedIndex) +".lol.riotgames.com";
            jabberClient1.Connect();

            panLogin.Visible = false;
            

            rm = new RosterManager();
            rm.Stream = jabberClient1;
            rm.AutoSubscribe = true;
            rm.AutoAllow = jabber.client.AutoSubscriptionHanding.AllowAll;
            rm.OnRosterBegin += new bedrock.ObjectHandler(rm_OnRosterBegin);
            rm.OnRosterEnd += new bedrock.ObjectHandler(rm_OnRosterEnd);
            rm.OnRosterItem += new RosterItemHandler(rm_OnRosterItem);

            pm = new PresenceManager();
            pm.Stream = jabberClient1;

            fRoster.RosterManager = rm;
            fRoster.PresenceManager = pm;
        }

        private bool jabberClient1_OnInvalidCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private string retChatServer(int parm)
        {
            switch (parm)
            {
                case 0:
                    return "kr";
                case 1:
                    return "na1";
                case 2:
                    return "eu";
                case 3:
                    return "eun1";
                case 4:
                    return "br";
                case 5:
                    return "tr";
                default:
                    return "";
            }

        }
        private void jabberClient1_OnAuthError(object sender, System.Xml.XmlElement rp)
        {

                MessageBox.Show("ID 또는 비밀번호가 틀렸습니다!");

                txtID.Text = "";
                txtPW.Text = "";
                panLogin.Visible = true;
                this.Height = 144;
                txtID.Focus();
            
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btLogin_Click(this,e);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbServer.SelectedIndex = 0;
            if (Properties.Settings.Default.user_id != "" && Properties.Settings.Default.password != "")
            {
                txtID.Text = Properties.Settings.Default.user_id;
                txtPW.Text = Properties.Settings.Default.password;
                cbServer.SelectedIndex = Properties.Settings.Default.lastServ;
                btLogin_Click(sender, e);
            }
        }

        #region ContextMenu Item Action
        private void tsmSetting_Click(object sender, EventArgs e)
        {
            frmSetting = new FrmSetting(this);
            frmSetting.Show();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

    }
}
