namespace Final
{
    partial class MissileCommand1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissileCommand1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripReset = new System.Windows.Forms.ToolStripButton();
            this.nextLevel = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.hiScoreButt = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.homeButton = new System.Windows.Forms.Button();
            this.enterName = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.announcment = new System.Windows.Forms.Label();
            this.saveName = new System.Windows.Forms.Button();
            this.scoresList = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Cyan;
            this.label1.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "MISSILES:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label2.Font = new System.Drawing.Font("Consolas", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(139, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 64);
            this.label2.TabIndex = 1;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.Color.Black;
            this.Score.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.Score.ForeColor = System.Drawing.Color.Red;
            this.Score.Location = new System.Drawing.Point(150, 14);
            this.Score.Name = "Score";
            this.Score.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Score.Size = new System.Drawing.Size(25, 28);
            this.Score.TabIndex = 2;
            this.Score.Text = "0";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.BackColor = System.Drawing.Color.Black;
            this.Level.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.Level.ForeColor = System.Drawing.Color.Red;
            this.Level.Location = new System.Drawing.Point(447, 14);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(90, 28);
            this.Level.TabIndex = 3;
            this.Level.Text = "LEVEL:";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Black;
            this.Start.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.Lime;
            this.Start.Location = new System.Drawing.Point(180, 230);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(250, 50);
            this.Start.TabIndex = 4;
            this.Start.Text = "START";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Consolas", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStart,
            this.toolStripPause,
            this.toolStripReset});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(9, 9);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(124, 43);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripStart
            // 
            this.toolStripStart.AutoSize = false;
            this.toolStripStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStart.Image")));
            this.toolStripStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStart.Name = "toolStripStart";
            this.toolStripStart.Size = new System.Drawing.Size(40, 40);
            this.toolStripStart.Text = "Start";
            this.toolStripStart.Click += new System.EventHandler(this.toolStripStart_Click);
            // 
            // toolStripPause
            // 
            this.toolStripPause.AutoSize = false;
            this.toolStripPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPause.Enabled = false;
            this.toolStripPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPause.Image")));
            this.toolStripPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPause.Name = "toolStripPause";
            this.toolStripPause.Size = new System.Drawing.Size(40, 40);
            this.toolStripPause.Text = "Pause";
            this.toolStripPause.ToolTipText = "Pause";
            this.toolStripPause.Click += new System.EventHandler(this.toolStripPause_Click);
            // 
            // toolStripReset
            // 
            this.toolStripReset.AutoSize = false;
            this.toolStripReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripReset.Enabled = false;
            this.toolStripReset.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripReset.Image")));
            this.toolStripReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReset.Name = "toolStripReset";
            this.toolStripReset.Size = new System.Drawing.Size(43, 40);
            this.toolStripReset.Text = "Reset";
            this.toolStripReset.Click += new System.EventHandler(this.toolStripReset_Click);
            // 
            // nextLevel
            // 
            this.nextLevel.BackColor = System.Drawing.Color.Black;
            this.nextLevel.Enabled = false;
            this.nextLevel.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLevel.ForeColor = System.Drawing.Color.Lime;
            this.nextLevel.Location = new System.Drawing.Point(180, 230);
            this.nextLevel.Name = "nextLevel";
            this.nextLevel.Size = new System.Drawing.Size(250, 50);
            this.nextLevel.TabIndex = 6;
            this.nextLevel.Text = "NEXT LEVEL";
            this.nextLevel.UseVisualStyleBackColor = false;
            this.nextLevel.Visible = false;
            this.nextLevel.Click += new System.EventHandler(this.nextLevel_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Black;
            this.settingsButton.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.Lime;
            this.settingsButton.Location = new System.Drawing.Point(180, 286);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(250, 50);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.Text = "SETTINGS";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // hiScoreButt
            // 
            this.hiScoreButt.BackColor = System.Drawing.Color.Black;
            this.hiScoreButt.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiScoreButt.ForeColor = System.Drawing.Color.Lime;
            this.hiScoreButt.Location = new System.Drawing.Point(180, 342);
            this.hiScoreButt.Name = "hiScoreButt";
            this.hiScoreButt.Size = new System.Drawing.Size(250, 50);
            this.hiScoreButt.TabIndex = 8;
            this.hiScoreButt.Text = "HIGHSCORES";
            this.hiScoreButt.UseVisualStyleBackColor = false;
            this.hiScoreButt.Click += new System.EventHandler(this.hiScoreButt_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Red;
            this.titleLabel.Location = new System.Drawing.Point(143, 151);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(322, 41);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "MISSILE DEFENDER";
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.gameOverLabel.Location = new System.Drawing.Point(206, 151);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(189, 41);
            this.gameOverLabel.TabIndex = 10;
            this.gameOverLabel.Text = "GAME OVER";
            this.gameOverLabel.Visible = false;
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.Black;
            this.homeButton.Enabled = false;
            this.homeButton.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.Lime;
            this.homeButton.Location = new System.Drawing.Point(180, 398);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(250, 50);
            this.homeButton.TabIndex = 11;
            this.homeButton.Text = "BACK";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Visible = false;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // enterName
            // 
            this.enterName.BackColor = System.Drawing.Color.Black;
            this.enterName.Enabled = false;
            this.enterName.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterName.ForeColor = System.Drawing.Color.Red;
            this.enterName.Location = new System.Drawing.Point(277, 286);
            this.enterName.MaxLength = 10;
            this.enterName.Name = "enterName";
            this.enterName.Size = new System.Drawing.Size(152, 36);
            this.enterName.TabIndex = 12;
            this.enterName.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.Red;
            this.nameLabel.Location = new System.Drawing.Point(182, 288);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(77, 28);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "NAME:";
            this.nameLabel.Visible = false;
            // 
            // announcment
            // 
            this.announcment.AutoSize = true;
            this.announcment.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.announcment.ForeColor = System.Drawing.Color.Red;
            this.announcment.Location = new System.Drawing.Point(162, 219);
            this.announcment.Name = "announcment";
            this.announcment.Size = new System.Drawing.Size(285, 28);
            this.announcment.TabIndex = 14;
            this.announcment.Text = "~~~ NEW HI-SCORE! ~~~";
            this.announcment.Visible = false;
            // 
            // saveName
            // 
            this.saveName.BackColor = System.Drawing.Color.Black;
            this.saveName.Enabled = false;
            this.saveName.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveName.ForeColor = System.Drawing.Color.Lime;
            this.saveName.Location = new System.Drawing.Point(180, 342);
            this.saveName.Name = "saveName";
            this.saveName.Size = new System.Drawing.Size(250, 50);
            this.saveName.TabIndex = 15;
            this.saveName.Text = "SAVE";
            this.saveName.UseVisualStyleBackColor = false;
            this.saveName.Visible = false;
            this.saveName.Click += new System.EventHandler(this.saveName_Click);
            // 
            // scoresList
            // 
            this.scoresList.AutoSize = true;
            this.scoresList.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoresList.ForeColor = System.Drawing.Color.Red;
            this.scoresList.Location = new System.Drawing.Point(189, 192);
            this.scoresList.Name = "scoresList";
            this.scoresList.Size = new System.Drawing.Size(0, 32);
            this.scoresList.TabIndex = 16;
            this.scoresList.Visible = false;
            // 
            // MissileCommand1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(601, 606);
            this.Controls.Add(this.scoresList);
            this.Controls.Add(this.saveName);
            this.Controls.Add(this.announcment);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.enterName);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.hiScoreButt);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.nextLevel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MissileCommand1";
            this.Text = "Two Tower Missile Defender";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MissileCommand1_Paint_1);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.shootMissile);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripPause;
        private System.Windows.Forms.ToolStripButton toolStripReset;
        private System.Windows.Forms.ToolStripButton toolStripStart;
        private System.Windows.Forms.Button nextLevel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button hiScoreButt;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.TextBox enterName;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label announcment;
        private System.Windows.Forms.Button saveName;
        private System.Windows.Forms.Label scoresList;
    }
}

