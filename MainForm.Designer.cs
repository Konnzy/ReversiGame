namespace ReversiGame
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            RulesButton = new Button();
            titleLabel = new Label();
            EasyButton = new Button();
            NormalButton = new Button();
            HardButton = new Button();
            PlayButton = new Button();
            WhiteLabel = new Label();
            SelectDifLabel = new Label();
            BlackLabel = new Label();
            playBoard = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)playBoard).BeginInit();
            SuspendLayout();
            // 
            // RulesButton
            // 
            RulesButton.BackColor = Color.DarkSeaGreen;
            RulesButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RulesButton.Location = new Point(684, 78);
            RulesButton.Name = "RulesButton";
            RulesButton.Size = new Size(220, 55);
            RulesButton.TabIndex = 0;
            RulesButton.Text = "Rules";
            RulesButton.UseVisualStyleBackColor = false;
            RulesButton.Click += RulesButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(684, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(222, 45);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Reversi Game";
            // 
            // EasyButton
            // 
            EasyButton.BackColor = Color.PaleGreen;
            EasyButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EasyButton.Location = new Point(684, 260);
            EasyButton.Name = "EasyButton";
            EasyButton.Size = new Size(220, 55);
            EasyButton.TabIndex = 3;
            EasyButton.Text = "Easy";
            EasyButton.UseVisualStyleBackColor = false;
            EasyButton.Click += SelectedDifficulty;
            // 
            // NormalButton
            // 
            NormalButton.BackColor = Color.LightGoldenrodYellow;
            NormalButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NormalButton.Location = new Point(684, 321);
            NormalButton.Name = "NormalButton";
            NormalButton.Size = new Size(220, 55);
            NormalButton.TabIndex = 4;
            NormalButton.Text = "Normal";
            NormalButton.UseVisualStyleBackColor = false;
            NormalButton.Click += SelectedDifficulty;
            // 
            // HardButton
            // 
            HardButton.BackColor = Color.LightCoral;
            HardButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HardButton.Location = new Point(684, 382);
            HardButton.Name = "HardButton";
            HardButton.Size = new Size(220, 55);
            HardButton.TabIndex = 5;
            HardButton.Text = "Hard";
            HardButton.UseVisualStyleBackColor = false;
            HardButton.Click += SelectedDifficulty;
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.LightGray;
            PlayButton.Enabled = false;
            PlayButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayButton.ForeColor = Color.DarkGray;
            PlayButton.Location = new Point(686, 505);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(220, 55);
            PlayButton.TabIndex = 6;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.Click += PlayButton_Click;
            // 
            // WhiteLabel
            // 
            WhiteLabel.AutoSize = true;
            WhiteLabel.Font = new Font("Segoe UI", 22F);
            WhiteLabel.Location = new Point(620, 149);
            WhiteLabel.Name = "WhiteLabel";
            WhiteLabel.Size = new Size(127, 41);
            WhiteLabel.TabIndex = 7;
            WhiteLabel.Text = "White: 2";
            // 
            // SelectDifLabel
            // 
            SelectDifLabel.AutoSize = true;
            SelectDifLabel.Font = new Font("Segoe UI", 22F);
            SelectDifLabel.Location = new Point(617, 197);
            SelectDifLabel.Name = "SelectDifLabel";
            SelectDifLabel.Size = new Size(228, 41);
            SelectDifLabel.TabIndex = 8;
            SelectDifLabel.Text = "Select Difficulty:";
            // 
            // BlackLabel
            // 
            BlackLabel.AutoSize = true;
            BlackLabel.Font = new Font("Segoe UI", 22F);
            BlackLabel.Location = new Point(850, 149);
            BlackLabel.Name = "BlackLabel";
            BlackLabel.Size = new Size(117, 41);
            BlackLabel.TabIndex = 9;
            BlackLabel.Text = "Black: 2";
            // 
            // playBoard
            // 
            playBoard.BackColor = Color.LightCyan;
            playBoard.Location = new Point(40, 30);
            playBoard.Name = "playBoard";
            playBoard.Size = new Size(520, 520);
            playBoard.TabIndex = 10;
            playBoard.TabStop = false;
            playBoard.MouseClick += playBoard_MouseClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1024, 601);
            Controls.Add(playBoard);
            Controls.Add(BlackLabel);
            Controls.Add(SelectDifLabel);
            Controls.Add(WhiteLabel);
            Controls.Add(PlayButton);
            Controls.Add(HardButton);
            Controls.Add(NormalButton);
            Controls.Add(EasyButton);
            Controls.Add(titleLabel);
            Controls.Add(RulesButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Reversi";
            ((System.ComponentModel.ISupportInitialize)playBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button RulesButton;
        private Label titleLabel;
        private Button EasyButton;
        private Button NormalButton;
        private Button HardButton;
        private Button PlayButton;
        private Label WhiteLabel;
        private Label SelectDifLabel;
        private Label BlackLabel;
        private PictureBox playBoard;
    }
}
