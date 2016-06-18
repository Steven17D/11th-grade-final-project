namespace Client
{
    partial class Game
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
            this.exitB = new System.Windows.Forms.Button();
            this.questionNumberLable = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.q1 = new System.Windows.Forms.Button();
            this.q2 = new System.Windows.Forms.Button();
            this.q3 = new System.Windows.Forms.Button();
            this.q4 = new System.Windows.Forms.Button();
            this.scoreLable = new System.Windows.Forms.Label();
            this.questionLable = new System.Windows.Forms.Label();
            this.timeLeftLable = new System.Windows.Forms.Label();
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
            this.Logo.TabIndex = 15;
            this.Logo.TabStop = false;
            // 
            // exitB
            // 
            this.exitB.BackColor = System.Drawing.Color.Red;
            this.exitB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitB.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitB.Location = new System.Drawing.Point(697, 12);
            this.exitB.Name = "exitB";
            this.exitB.Size = new System.Drawing.Size(75, 35);
            this.exitB.TabIndex = 16;
            this.exitB.Text = "Exit";
            this.exitB.UseVisualStyleBackColor = false;
            this.exitB.Click += new System.EventHandler(this.exitB_Click);
            // 
            // questionNumberLable
            // 
            this.questionNumberLable.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumberLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.questionNumberLable.Location = new System.Drawing.Point(16, 177);
            this.questionNumberLable.Name = "questionNumberLable";
            this.questionNumberLable.Size = new System.Drawing.Size(752, 33);
            this.questionNumberLable.TabIndex = 29;
            this.questionNumberLable.Text = "Question: 0/5";
            this.questionNumberLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameLabel.ForeColor = System.Drawing.Color.Chartreuse;
            this.roomNameLabel.Location = new System.Drawing.Point(16, 137);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(752, 40);
            this.roomNameLabel.TabIndex = 28;
            this.roomNameLabel.Text = "roomName";
            this.roomNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // q1
            // 
            this.q1.Location = new System.Drawing.Point(16, 273);
            this.q1.Name = "q1";
            this.q1.Size = new System.Drawing.Size(752, 41);
            this.q1.TabIndex = 30;
            this.q1.Text = "button2";
            this.q1.UseVisualStyleBackColor = true;
            this.q1.Click += new System.EventHandler(this.q1_Click);
            // 
            // q2
            // 
            this.q2.Location = new System.Drawing.Point(16, 320);
            this.q2.Name = "q2";
            this.q2.Size = new System.Drawing.Size(752, 41);
            this.q2.TabIndex = 31;
            this.q2.Text = "button3";
            this.q2.UseVisualStyleBackColor = true;
            this.q2.Click += new System.EventHandler(this.q2_Click);
            // 
            // q3
            // 
            this.q3.Location = new System.Drawing.Point(16, 367);
            this.q3.Name = "q3";
            this.q3.Size = new System.Drawing.Size(752, 41);
            this.q3.TabIndex = 32;
            this.q3.Text = "button4";
            this.q3.UseVisualStyleBackColor = true;
            this.q3.Click += new System.EventHandler(this.q3_Click);
            // 
            // q4
            // 
            this.q4.Location = new System.Drawing.Point(16, 414);
            this.q4.Name = "q4";
            this.q4.Size = new System.Drawing.Size(752, 41);
            this.q4.TabIndex = 33;
            this.q4.Text = "button5";
            this.q4.UseVisualStyleBackColor = true;
            this.q4.Click += new System.EventHandler(this.q4_Click);
            // 
            // scoreLable
            // 
            this.scoreLable.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.scoreLable.Location = new System.Drawing.Point(16, 510);
            this.scoreLable.Name = "scoreLable";
            this.scoreLable.Size = new System.Drawing.Size(752, 34);
            this.scoreLable.TabIndex = 34;
            this.scoreLable.Text = "Score: 0/4";
            this.scoreLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionLable
            // 
            this.questionLable.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.questionLable.Location = new System.Drawing.Point(16, 220);
            this.questionLable.Name = "questionLable";
            this.questionLable.Size = new System.Drawing.Size(752, 50);
            this.questionLable.TabIndex = 35;
            this.questionLable.Text = "Question?";
            // 
            // timeLeftLable
            // 
            this.timeLeftLable.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeftLable.ForeColor = System.Drawing.Color.OrangeRed;
            this.timeLeftLable.Location = new System.Drawing.Point(16, 462);
            this.timeLeftLable.Name = "timeLeftLable";
            this.timeLeftLable.Size = new System.Drawing.Size(752, 48);
            this.timeLeftLable.TabIndex = 36;
            this.timeLeftLable.Text = "5";
            this.timeLeftLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.timeLeftLable);
            this.Controls.Add(this.questionLable);
            this.Controls.Add(this.scoreLable);
            this.Controls.Add(this.q4);
            this.Controls.Add(this.q3);
            this.Controls.Add(this.q2);
            this.Controls.Add(this.q1);
            this.Controls.Add(this.questionNumberLable);
            this.Controls.Add(this.roomNameLabel);
            this.Controls.Add(this.exitB);
            this.Controls.Add(this.Logo);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button exitB;
        private System.Windows.Forms.Label questionNumberLable;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.Button q1;
        private System.Windows.Forms.Button q2;
        private System.Windows.Forms.Button q3;
        private System.Windows.Forms.Button q4;
        private System.Windows.Forms.Label scoreLable;
        private System.Windows.Forms.Label questionLable;
        private System.Windows.Forms.Label timeLeftLable;
    }
}