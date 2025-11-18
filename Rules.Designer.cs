namespace ReversiGame
{
    partial class Rules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rules));
            rulesInfo = new RichTextBox();
            SuspendLayout();
            // 
            // rulesInfo
            // 
            rulesInfo.BorderStyle = BorderStyle.FixedSingle;
            rulesInfo.Font = new Font("Segoe UI", 11F);
            rulesInfo.Location = new Point(-2, -3);
            rulesInfo.Name = "rulesInfo";
            rulesInfo.ReadOnly = true;
            rulesInfo.ScrollBars = RichTextBoxScrollBars.Vertical;
            rulesInfo.Size = new Size(342, 420);
            rulesInfo.TabIndex = 0;
            rulesInfo.Text = "";
            // 
            // Rules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 411);
            Controls.Add(rulesInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Rules";
            Text = "Rules";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rulesInfo;
    }
}