namespace Client
{
    partial class WaitForGame
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
            this.Logo = new System.Windows.Forms.PictureBox();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.startGame = new System.Windows.Forms.Button();
            this.leaveCloseB = new System.Windows.Forms.Button();
            this.roomProperties = new System.Windows.Forms.Label();
            this.roomPlayers = new System.Windows.Forms.ListBox();
            this.particapants = new System.Windows.Forms.Label();
            this.msgToUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = global::Client.Properties.Resources.Trivia;
            this.Logo.Location = new System.Drawing.Point(16, 16);
            this.Logo.Margin = new System.Windows.Forms.Padding(7);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(752, 114);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 14;
            this.Logo.TabStop = false;
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameLabel.ForeColor = System.Drawing.Color.Chartreuse;
            this.roomNameLabel.Location = new System.Drawing.Point(16, 137);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(752, 40);
            this.roomNameLabel.TabIndex = 24;
            this.roomNameLabel.Text = "roomName";
            this.roomNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startGame
            // 
            this.startGame.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGame.Location = new System.Drawing.Point(397, 510);
            this.startGame.Margin = new System.Windows.Forms.Padding(4);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(203, 37);
            this.startGame.TabIndex = 26;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // leaveCloseB
            // 
            this.leaveCloseB.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveCloseB.Location = new System.Drawing.Point(186, 510);
            this.leaveCloseB.Margin = new System.Windows.Forms.Padding(4);
            this.leaveCloseB.Name = "leaveCloseB";
            this.leaveCloseB.Size = new System.Drawing.Size(203, 38);
            this.leaveCloseB.TabIndex = 25;
            this.leaveCloseB.Text = "Leave / Close";
            this.leaveCloseB.UseVisualStyleBackColor = true;
            this.leaveCloseB.Click += new System.EventHandler(this.leaveCloseB_Click);
            // 
            // roomProperties
            // 
            this.roomProperties.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomProperties.ForeColor = System.Drawing.Color.Chartreuse;
            this.roomProperties.Location = new System.Drawing.Point(16, 177);
            this.roomProperties.Name = "roomProperties";
            this.roomProperties.Size = new System.Drawing.Size(752, 33);
            this.roomProperties.TabIndex = 27;
            this.roomProperties.Text = "roomProperties";
            this.roomProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomPlayers
            // 
            this.roomPlayers.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomPlayers.FormattingEnabled = true;
            this.roomPlayers.ItemHeight = 30;
            this.roomPlayers.Location = new System.Drawing.Point(186, 270);
            this.roomPlayers.Name = "roomPlayers";
            this.roomPlayers.Size = new System.Drawing.Size(414, 154);
            this.roomPlayers.TabIndex = 28;
            // 
            // particapants
            // 
            this.particapants.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.particapants.ForeColor = System.Drawing.Color.Chartreuse;
            this.particapants.Location = new System.Drawing.Point(16, 228);
            this.particapants.Name = "particapants";
            this.particapants.Size = new System.Drawing.Size(752, 39);
            this.particapants.TabIndex = 29;
            this.particapants.Text = "Current participants are:";
            this.particapants.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // msgToUser
            // 
            this.msgToUser.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgToUser.ForeColor = System.Drawing.Color.Red;
            this.msgToUser.Location = new System.Drawing.Point(186, 464);
            this.msgToUser.Name = "msgToUser";
            this.msgToUser.Size = new System.Drawing.Size(414, 42);
            this.msgToUser.TabIndex = 30;
            this.msgToUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WaitForGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.msgToUser);
            this.Controls.Add(this.particapants);
            this.Controls.Add(this.roomPlayers);
            this.Controls.Add(this.roomProperties);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.leaveCloseB);
            this.Controls.Add(this.roomNameLabel);
            this.Controls.Add(this.Logo);
            this.Name = "WaitForGame";
            this.Text = "WaitForGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitForGame_FormClosing);
            this.Load += new System.EventHandler(this.WaitForGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button leaveCloseB;
        private System.Windows.Forms.Label roomProperties;
        private System.Windows.Forms.ListBox roomPlayers;
        private System.Windows.Forms.Label particapants;
        private System.Windows.Forms.Label msgToUser;
    }
}