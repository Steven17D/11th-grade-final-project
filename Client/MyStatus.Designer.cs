namespace Client
{
    partial class MyStatus
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
            this.TriviaLogoTop = new System.Windows.Forms.PictureBox();
            this.myPer = new System.Windows.Forms.Label();
            this.numOfGames = new System.Windows.Forms.Label();
            this.numOfRightAns = new System.Windows.Forms.Label();
            this.numOfWrongAns = new System.Windows.Forms.Label();
            this.AvgTimeForAns = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TriviaLogoTop)).BeginInit();
            this.SuspendLayout();
            // 
            // TriviaLogoTop
            // 
            this.TriviaLogoTop.Image = global::Client.Properties.Resources.Trivia;
            this.TriviaLogoTop.Location = new System.Drawing.Point(13, 13);
            this.TriviaLogoTop.Margin = new System.Windows.Forms.Padding(4);
            this.TriviaLogoTop.Name = "TriviaLogoTop";
            this.TriviaLogoTop.Size = new System.Drawing.Size(758, 122);
            this.TriviaLogoTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TriviaLogoTop.TabIndex = 7;
            this.TriviaLogoTop.TabStop = false;
            // 
            // myPer
            // 
            this.myPer.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myPer.ForeColor = System.Drawing.Color.Chartreuse;
            this.myPer.Location = new System.Drawing.Point(13, 139);
            this.myPer.Name = "myPer";
            this.myPer.Size = new System.Drawing.Size(758, 91);
            this.myPer.TabIndex = 25;
            this.myPer.Text = "My performances:";
            this.myPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOfGames
            // 
            this.numOfGames.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfGames.ForeColor = System.Drawing.Color.Chartreuse;
            this.numOfGames.Location = new System.Drawing.Point(13, 258);
            this.numOfGames.Name = "numOfGames";
            this.numOfGames.Size = new System.Drawing.Size(758, 46);
            this.numOfGames.TabIndex = 25;
            this.numOfGames.Text = "Number of Games - ";
            this.numOfGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOfRightAns
            // 
            this.numOfRightAns.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfRightAns.ForeColor = System.Drawing.Color.Chartreuse;
            this.numOfRightAns.Location = new System.Drawing.Point(13, 304);
            this.numOfRightAns.Name = "numOfRightAns";
            this.numOfRightAns.Size = new System.Drawing.Size(758, 46);
            this.numOfRightAns.TabIndex = 25;
            this.numOfRightAns.Text = "Number of Right Answers - ";
            this.numOfRightAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOfWrongAns
            // 
            this.numOfWrongAns.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfWrongAns.ForeColor = System.Drawing.Color.Chartreuse;
            this.numOfWrongAns.Location = new System.Drawing.Point(13, 350);
            this.numOfWrongAns.Name = "numOfWrongAns";
            this.numOfWrongAns.Size = new System.Drawing.Size(758, 46);
            this.numOfWrongAns.TabIndex = 25;
            this.numOfWrongAns.Text = "Number of Wrong Answers - ";
            this.numOfWrongAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvgTimeForAns
            // 
            this.AvgTimeForAns.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgTimeForAns.ForeColor = System.Drawing.Color.Chartreuse;
            this.AvgTimeForAns.Location = new System.Drawing.Point(13, 396);
            this.AvgTimeForAns.Name = "AvgTimeForAns";
            this.AvgTimeForAns.Size = new System.Drawing.Size(758, 46);
            this.AvgTimeForAns.TabIndex = 25;
            this.AvgTimeForAns.Text = "Average Time for Answer - ";
            this.AvgTimeForAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backB
            // 
            this.backB.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backB.Location = new System.Drawing.Point(692, 518);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(79, 31);
            this.backB.TabIndex = 26;
            this.backB.Text = "⤴Back";
            this.backB.UseVisualStyleBackColor = true;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // MyStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.AvgTimeForAns);
            this.Controls.Add(this.numOfWrongAns);
            this.Controls.Add(this.numOfRightAns);
            this.Controls.Add(this.numOfGames);
            this.Controls.Add(this.myPer);
            this.Controls.Add(this.TriviaLogoTop);
            this.Name = "MyStatus";
            this.Text = "MyStatus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyStatus_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TriviaLogoTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TriviaLogoTop;
        private System.Windows.Forms.Label myPer;
        private System.Windows.Forms.Label numOfGames;
        private System.Windows.Forms.Label numOfRightAns;
        private System.Windows.Forms.Label numOfWrongAns;
        private System.Windows.Forms.Label AvgTimeForAns;
        private System.Windows.Forms.Button backB;
    }
}