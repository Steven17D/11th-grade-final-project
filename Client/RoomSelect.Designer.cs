namespace Client
{
    partial class RoomSelect
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
            this.backB = new System.Windows.Forms.Button();
            this.joinB = new System.Windows.Forms.Button();
            this.refreshB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roomList = new System.Windows.Forms.ListBox();
            this.roomPlayersLable = new System.Windows.Forms.Label();
            this.roomPlayers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = global::Client.Properties.Resources.Trivia;
            this.Logo.Location = new System.Drawing.Point(19, 20);
            this.Logo.Margin = new System.Windows.Forms.Padding(7);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(749, 114);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 13;
            this.Logo.TabStop = false;
            // 
            // backB
            // 
            this.backB.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backB.Location = new System.Drawing.Point(700, 510);
            this.backB.Margin = new System.Windows.Forms.Padding(4);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(68, 38);
            this.backB.TabIndex = 20;
            this.backB.Text = "⤴Back";
            this.backB.UseVisualStyleBackColor = true;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // joinB
            // 
            this.joinB.Location = new System.Drawing.Point(186, 510);
            this.joinB.Margin = new System.Windows.Forms.Padding(4);
            this.joinB.Name = "joinB";
            this.joinB.Size = new System.Drawing.Size(203, 38);
            this.joinB.TabIndex = 21;
            this.joinB.Text = "Join";
            this.joinB.UseVisualStyleBackColor = true;
            this.joinB.Click += new System.EventHandler(this.joinB_Click);
            // 
            // refreshB
            // 
            this.refreshB.Location = new System.Drawing.Point(397, 512);
            this.refreshB.Margin = new System.Windows.Forms.Padding(4);
            this.refreshB.Name = "refreshB";
            this.refreshB.Size = new System.Drawing.Size(203, 37);
            this.refreshB.TabIndex = 22;
            this.refreshB.Text = "Refresh";
            this.refreshB.UseVisualStyleBackColor = true;
            this.refreshB.Click += new System.EventHandler(this.refreshB_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(19, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(749, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "Rooms list:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomList
            // 
            this.roomList.FormattingEnabled = true;
            this.roomList.ItemHeight = 19;
            this.roomList.Location = new System.Drawing.Point(186, 180);
            this.roomList.Name = "roomList";
            this.roomList.Size = new System.Drawing.Size(414, 118);
            this.roomList.TabIndex = 24;
            this.roomList.SelectedValueChanged += new System.EventHandler(this.roomList_SelectedValueChanged);
            // 
            // roomPlayersLable
            // 
            this.roomPlayersLable.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomPlayersLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.roomPlayersLable.Location = new System.Drawing.Point(19, 304);
            this.roomPlayersLable.Name = "roomPlayersLable";
            this.roomPlayersLable.Size = new System.Drawing.Size(749, 32);
            this.roomPlayersLable.TabIndex = 23;
            this.roomPlayersLable.Text = "Selected room players:";
            this.roomPlayersLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomPlayers
            // 
            this.roomPlayers.FormattingEnabled = true;
            this.roomPlayers.ItemHeight = 19;
            this.roomPlayers.Location = new System.Drawing.Point(186, 339);
            this.roomPlayers.Name = "roomPlayers";
            this.roomPlayers.Size = new System.Drawing.Size(414, 137);
            this.roomPlayers.TabIndex = 24;
            // 
            // RoomSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.roomPlayers);
            this.Controls.Add(this.roomList);
            this.Controls.Add(this.roomPlayersLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshB);
            this.Controls.Add(this.joinB);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.Logo);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RoomSelect";
            this.Text = "RoomSelect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomSelect_FormClosing);
            this.Load += new System.EventHandler(this.RoomSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.Button joinB;
        private System.Windows.Forms.Button refreshB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox roomList;
        private System.Windows.Forms.Label roomPlayersLable;
        private System.Windows.Forms.ListBox roomPlayers;

    }
}