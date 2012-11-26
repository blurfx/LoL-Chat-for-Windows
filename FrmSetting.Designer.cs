namespace LoLChat_for_Windows
{
    partial class FrmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.btReset = new System.Windows.Forms.Button();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.txtStatMsg = new System.Windows.Forms.TextBox();
            this.lblStatMsg = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtRankedLoses = new System.Windows.Forms.TextBox();
            this.txtRankedWins = new System.Windows.Forms.TextBox();
            this.lblRankedLoses = new System.Windows.Forms.Label();
            this.lblRankedWins = new System.Windows.Forms.Label();
            this.txtNormalWins = new System.Windows.Forms.TextBox();
            this.lblNormalWins = new System.Windows.Forms.Label();
            this.txtLvl = new System.Windows.Forms.TextBox();
            this.lblLvl = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(6, 7);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(268, 30);
            this.btReset.TabIndex = 0;
            this.btReset.Text = "자동 로그인 설정 해제";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.txtStatMsg);
            this.gbStatus.Controls.Add(this.lblStatMsg);
            this.gbStatus.Controls.Add(this.txtRating);
            this.gbStatus.Controls.Add(this.lblRating);
            this.gbStatus.Controls.Add(this.txtRankedLoses);
            this.gbStatus.Controls.Add(this.txtRankedWins);
            this.gbStatus.Controls.Add(this.lblRankedLoses);
            this.gbStatus.Controls.Add(this.lblRankedWins);
            this.gbStatus.Controls.Add(this.txtNormalWins);
            this.gbStatus.Controls.Add(this.lblNormalWins);
            this.gbStatus.Controls.Add(this.txtLvl);
            this.gbStatus.Controls.Add(this.lblLvl);
            this.gbStatus.Location = new System.Drawing.Point(6, 43);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(268, 171);
            this.gbStatus.TabIndex = 1;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "상태 메시지";
            // 
            // txtStatMsg
            // 
            this.txtStatMsg.Location = new System.Drawing.Point(115, 141);
            this.txtStatMsg.Name = "txtStatMsg";
            this.txtStatMsg.Size = new System.Drawing.Size(146, 21);
            this.txtStatMsg.TabIndex = 11;
            // 
            // lblStatMsg
            // 
            this.lblStatMsg.AutoSize = true;
            this.lblStatMsg.Location = new System.Drawing.Point(32, 145);
            this.lblStatMsg.Name = "lblStatMsg";
            this.lblStatMsg.Size = new System.Drawing.Size(77, 12);
            this.lblStatMsg.TabIndex = 10;
            this.lblStatMsg.Text = "상태 메시지 :";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(115, 117);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(146, 21);
            this.txtRating.TabIndex = 9;
            this.txtRating.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRating_KeyPress);
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(60, 120);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(49, 12);
            this.lblRating.TabIndex = 8;
            this.lblRating.Text = "레이팅 :";
            // 
            // txtRankedLoses
            // 
            this.txtRankedLoses.Location = new System.Drawing.Point(115, 93);
            this.txtRankedLoses.Name = "txtRankedLoses";
            this.txtRankedLoses.Size = new System.Drawing.Size(146, 21);
            this.txtRankedLoses.TabIndex = 7;
            this.txtRankedLoses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRankedLoses_KeyPress);
            // 
            // txtRankedWins
            // 
            this.txtRankedWins.Location = new System.Drawing.Point(115, 68);
            this.txtRankedWins.Name = "txtRankedWins";
            this.txtRankedWins.Size = new System.Drawing.Size(146, 21);
            this.txtRankedWins.TabIndex = 6;
            this.txtRankedWins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRankedWins_KeyPress);
            // 
            // lblRankedLoses
            // 
            this.lblRankedLoses.AutoSize = true;
            this.lblRankedLoses.Location = new System.Drawing.Point(15, 97);
            this.lblRankedLoses.Name = "lblRankedLoses";
            this.lblRankedLoses.Size = new System.Drawing.Size(93, 12);
            this.lblRankedLoses.TabIndex = 5;
            this.lblRankedLoses.Text = "랭크 게임 패배 :";
            // 
            // lblRankedWins
            // 
            this.lblRankedWins.AutoSize = true;
            this.lblRankedWins.Location = new System.Drawing.Point(15, 72);
            this.lblRankedWins.Name = "lblRankedWins";
            this.lblRankedWins.Size = new System.Drawing.Size(93, 12);
            this.lblRankedWins.TabIndex = 4;
            this.lblRankedWins.Text = "랭크 게임 승리 :";
            // 
            // txtNormalWins
            // 
            this.txtNormalWins.Location = new System.Drawing.Point(115, 44);
            this.txtNormalWins.Name = "txtNormalWins";
            this.txtNormalWins.Size = new System.Drawing.Size(146, 21);
            this.txtNormalWins.TabIndex = 3;
            this.txtNormalWins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNormalWins_KeyPress);
            // 
            // lblNormalWins
            // 
            this.lblNormalWins.AutoSize = true;
            this.lblNormalWins.Location = new System.Drawing.Point(16, 48);
            this.lblNormalWins.Name = "lblNormalWins";
            this.lblNormalWins.Size = new System.Drawing.Size(93, 12);
            this.lblNormalWins.TabIndex = 2;
            this.lblNormalWins.Text = "일반 게임 승리 :";
            // 
            // txtLvl
            // 
            this.txtLvl.Location = new System.Drawing.Point(115, 20);
            this.txtLvl.Name = "txtLvl";
            this.txtLvl.Size = new System.Drawing.Size(146, 21);
            this.txtLvl.TabIndex = 1;
            this.txtLvl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLvl_KeyPress);
            // 
            // lblLvl
            // 
            this.lblLvl.AutoSize = true;
            this.lblLvl.Location = new System.Drawing.Point(71, 24);
            this.lblLvl.Name = "lblLvl";
            this.lblLvl.Size = new System.Drawing.Size(37, 12);
            this.lblLvl.TabIndex = 0;
            this.lblLvl.Text = "레벨 :";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(165, 218);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(108, 27);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "저장";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 246);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.btReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.TextBox txtRankedWins;
        private System.Windows.Forms.Label lblRankedLoses;
        private System.Windows.Forms.Label lblRankedWins;
        private System.Windows.Forms.TextBox txtNormalWins;
        private System.Windows.Forms.Label lblNormalWins;
        private System.Windows.Forms.TextBox txtLvl;
        private System.Windows.Forms.Label lblLvl;
        private System.Windows.Forms.TextBox txtStatMsg;
        private System.Windows.Forms.Label lblStatMsg;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRankedLoses;
        private System.Windows.Forms.Button btSave;
    }
}