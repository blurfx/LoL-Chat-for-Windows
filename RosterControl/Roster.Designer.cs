namespace LoLChat_for_Windows
{
    partial class Roster
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Roster
            // 
            this.Size = new System.Drawing.Size(334, 485);
            this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Roster_AfterSelect);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
