using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLChat_for_Windows
{
    public partial class FrmSetting : Form
    {
        frmMain main;
        public FrmSetting(frmMain frm)
        {
            InitializeComponent();
            main = frm;
        }

        #region Accpet only Digits
        private void txtLvl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNormalWins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRankedWins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRankedLoses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void btSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.digitStats = txtLvl.Text + "|" + txtNormalWins.Text + "|" +
                txtRankedWins.Text + "|" + txtRankedLoses.Text + "|" + txtRating.Text;
            Properties.Settings.Default.statMsg = txtStatMsg.Text;
            Properties.Settings.Default.Save();

            main.jabberClient1.Presence(jabber.protocol.client.PresenceType.available,
                //"<body><level>9001</level><wins>9001</wins><leaves>0</leaves><rankedWins>218</rankedWins><rankedLosses>55</rankedLosses><rankedRating>2888</rankedRating><<gameStatus>outOfGame</gameStatus></body>",
             "<body><profileIcon>668</profileIcon><level>" + txtLvl.Text + "</level><wins>" + txtNormalWins.Text + "</wins><rankedWins>" + txtRankedWins.Text +
             "</rankedWins><rankedLosses>" + txtRankedLoses.Text + "</rankedLosses><rankedRating>" + txtRating.Text + "</rankedRating><statusMsg>"
         + txtStatMsg.Text + "</statusMsg><tier>PLATINUM</tier></body>",
             null, 0);

            this.Close();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.user_id = "";
            Properties.Settings.Default.password = "";
            Properties.Settings.Default.Save();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            string[] digitStatus = {"","","","",""};
            if (Properties.Settings.Default.digitStats != "")
                digitStatus = Properties.Settings.Default.digitStats.Split('|');

            txtLvl.Text = digitStatus[0];
            txtNormalWins.Text = digitStatus[1];
            txtRankedWins.Text = digitStatus[2];
            txtRankedLoses.Text = digitStatus[3];
            txtRating.Text = digitStatus[4];

            txtStatMsg.Text = Properties.Settings.Default.statMsg;
        }
    }
}