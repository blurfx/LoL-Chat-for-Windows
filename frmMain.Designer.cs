namespace LoLChat_for_Windows
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.jabberClient1 = new jabber.client.JabberClient(this.components);
            this.fRoster = new muzzle.RosterTree();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.panLogin = new System.Windows.Forms.Panel();
            this.chkRemId = new System.Windows.Forms.CheckBox();
            this.lblVer = new System.Windows.Forms.Label();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.lblPW = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.panLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // jabberClient1
            // 
            this.jabberClient1.AutoReconnect = 30F;
            this.jabberClient1.AutoStartCompression = true;
            this.jabberClient1.AutoStartTLS = true;
            this.jabberClient1.InvokeControl = this;
            this.jabberClient1.KeepAlive = 10F;
            this.jabberClient1.LocalCertificate = null;
            this.jabberClient1.NetworkHost = "chat.kr.lol.riotgames.com";
            this.jabberClient1.Password = "";
            this.jabberClient1.Port = 5223;
            this.jabberClient1.Resource = "RivenOPdevBird";
            this.jabberClient1.Server = "pvp.net";
            this.jabberClient1.SSL = true;
            this.jabberClient1.User = "";
            this.jabberClient1.OnMessage += new jabber.client.MessageHandler(this.jabberClient1_OnMessage);
            this.jabberClient1.OnAuthError += new jabber.protocol.ProtocolHandler(this.jabberClient1_OnAuthError);
            this.jabberClient1.OnInvalidCertificate += new System.Net.Security.RemoteCertificateValidationCallback(this.jabberClient1_OnInvalidCertificate);
            // 
            // fRoster
            // 
            this.fRoster.AllowDrop = true;
            this.fRoster.Client = this.jabberClient1;
            this.fRoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fRoster.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.fRoster.ImageIndex = 1;
            this.fRoster.ImageList = this.il;
            this.fRoster.Location = new System.Drawing.Point(0, 0);
            this.fRoster.Name = "fRoster";
            this.fRoster.PresenceManager = null;
            this.fRoster.RosterManager = null;
            this.fRoster.SelectedImageIndex = 0;
            this.fRoster.ShowLines = false;
            this.fRoster.ShowRootLines = false;
            this.fRoster.Size = new System.Drawing.Size(347, 105);
            this.fRoster.Sorted = true;
            this.fRoster.StatusColor = System.Drawing.Color.Teal;
            this.fRoster.TabIndex = 0;
            this.fRoster.TabStop = false;
            this.fRoster.DoubleClick += new System.EventHandler(this.rosterTree1_DoubleClick);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "nav_plain_gray_16.ico");
            this.il.Images.SetKeyName(1, "blank.ico");
            this.il.Images.SetKeyName(2, "nav_plain_yellow_16.ico");
            this.il.Images.SetKeyName(3, "blank.ico");
            this.il.Images.SetKeyName(4, "nav_plain_red_16.ico");
            this.il.Images.SetKeyName(5, "nav_plain_green_16.ico");
            this.il.Images.SetKeyName(6, "navigate_down_16.ico");
            this.il.Images.SetKeyName(7, "navigate_left_16.ico");
            this.il.Images.SetKeyName(8, "blank.ico");
            // 
            // panLogin
            // 
            this.panLogin.BackColor = System.Drawing.Color.White;
            this.panLogin.Controls.Add(this.chkRemId);
            this.panLogin.Controls.Add(this.lblVer);
            this.panLogin.Controls.Add(this.txtPW);
            this.panLogin.Controls.Add(this.lblPW);
            this.panLogin.Controls.Add(this.btLogin);
            this.panLogin.Controls.Add(this.txtID);
            this.panLogin.Controls.Add(this.lblID);
            this.panLogin.Location = new System.Drawing.Point(0, 0);
            this.panLogin.Name = "panLogin";
            this.panLogin.Size = new System.Drawing.Size(347, 107);
            this.panLogin.TabIndex = 1;
            // 
            // chkRemId
            // 
            this.chkRemId.AutoSize = true;
            this.chkRemId.Location = new System.Drawing.Point(149, 85);
            this.chkRemId.Name = "chkRemId";
            this.chkRemId.Size = new System.Drawing.Size(88, 16);
            this.chkRemId.TabIndex = 5;
            this.chkRemId.Text = "자동 로그인";
            this.chkRemId.UseVisualStyleBackColor = true;
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(270, 90);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(75, 12);
            this.lblVer.TabIndex = 4;
            this.lblVer.Text = "Version 0.1b";
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(53, 60);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '●';
            this.txtPW.Size = new System.Drawing.Size(184, 21);
            this.txtPW.TabIndex = 2;
            this.txtPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPW_KeyDown);
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.Location = new System.Drawing.Point(16, 63);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(31, 12);
            this.lblPW.TabIndex = 3;
            this.lblPW.Text = "PW :";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(245, 27);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(77, 54);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "로그인";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(46, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(191, 21);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(16, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 12);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID : ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 105);
            this.Controls.Add(this.panLogin);
            this.Controls.Add(this.fRoster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoL Chat ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panLogin.ResumeLayout(false);
            this.panLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private muzzle.RosterTree fRoster;
        private jabber.client.JabberClient jabberClient1;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Panel panLogin;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.CheckBox chkRemId;
    }
}

