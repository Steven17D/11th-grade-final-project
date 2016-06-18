namespace Client
{
    partial class BestScores
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
            this.backB = new System.Windows.Forms.Button();
            this.user3 = new System.Windows.Forms.Label();
            this.user2 = new System.Windows.Forms.Label();
            this.user1 = new System.Windows.Forms.Label();
            this.bestSco = new System.Windows.Forms.Label();
            this.TriviaLogoTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TriviaLogoTop)).BeginInit();
            this.SuspendLayout();
            // 
            // backB
            // 
            this.backB.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backB.Location = new System.Drawing.Point(692, 517);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(79, 31);
            this.backB.TabIndex = 33;
            this.backB.Text = "⤴Back";
            this.backB.UseVisualStyleBackColor = true;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // user3
            // 
            this.user3.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user3.ForeColor = System.Drawing.Color.Chartreuse;
            this.user3.Location = new System.Drawing.Point(13, 349);
            this.user3.Name = "user3";
            this.user3.Size = new System.Drawing.Size(758, 46);
            this.user3.TabIndex = 29;
            this.user3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // user2
            // 
            this.user2.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user2.ForeColor = System.Drawing.Color.Chartreuse;
            this.user2.Location = new System.Drawing.Point(13, 303);
            this.user2.Name = "user2";
            this.user2.Size = new System.Drawing.Size(758, 46);
            this.user2.TabIndex = 30;
            this.user2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // user1
            // 
            this.user1.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user1.ForeColor = System.Drawing.Color.Chartreuse;
            this.user1.Location = new System.Drawing.Point(13, 257);
            this.user1.Name = "user1";
            this.user1.Size = new System.Drawing.Size(758, 46);
            this.user1.TabIndex = 31;
            this.user1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bestSco
            // 
            this.bestSco.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestSco.ForeColor = System.Drawing.Color.Chartreuse;
            this.bestSco.Location = new System.Drawing.Point(13, 138);
            this.bestSco.Name = "bestSco";
            this.bestSco.Size = new System.Drawing.Size(758, 91);
            this.bestSco.TabIndex = 32;
            this.bestSco.Text = "Best Scores:";
            this.bestSco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TriviaLogoTop
            // 
            this.TriviaLogoTop.Image = global::Client.Properties.Resources.Trivia;
            this.TriviaLogoTop.Location = new System.Drawing.Point(13, 12);
            this.TriviaLogoTop.Margin = new System.Windows.Forms.Padding(4);
            this.TriviaLogoTop.Name = "TriviaLogoTop";
            this.TriviaLogoTop.Size = new System.Drawing.Size(758, 122);
            this.TriviaLogoTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TriviaLogoTop.TabIndex = 27;
            this.TriviaLogoTop.TabStop = false;
            // 
            // BestScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.user3);
            this.Controls.Add(this.user2);
            this.Controls.Add(this.user1);
            this.Controls.Add(this.bestSco);
            this.Controls.Add(this.TriviaLogoTop);
            this.Name = "BestScores";
            this.Text = "BestScores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BestScores_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TriviaLogoTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.Label user3;
        private System.Windows.Forms.Label user2;
        private System.Windows.Forms.Label user1;
        private System.Windows.Forms.Label bestSco;
        private System.Windows.Forms.PictureBox TriviaLogoTop;

    }
}