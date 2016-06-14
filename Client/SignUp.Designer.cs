namespace Client
{
    partial class SignUp
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
            this.emailBox = new System.Windows.Forms.TextBox();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.UserNameLable = new System.Windows.Forms.Label();
            this.SignIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EmailLable = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.MsgToUser = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(116, 162);
            this.emailBox.Margin = new System.Windows.Forms.Padding(5);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(238, 23);
            this.emailBox.TabIndex = 17;
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(115, 93);
            this.userNameBox.Margin = new System.Windows.Forms.Padding(5);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(238, 23);
            this.userNameBox.TabIndex = 16;
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.PasswordLable.Location = new System.Drawing.Point(26, 127);
            this.PasswordLable.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(80, 23);
            this.PasswordLable.TabIndex = 15;
            this.PasswordLable.Text = "Password";
            // 
            // UserNameLable
            // 
            this.UserNameLable.AutoSize = true;
            this.UserNameLable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.UserNameLable.Location = new System.Drawing.Point(14, 93);
            this.UserNameLable.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.UserNameLable.Name = "UserNameLable";
            this.UserNameLable.Size = new System.Drawing.Size(92, 23);
            this.UserNameLable.TabIndex = 14;
            this.UserNameLable.Text = "User name";
            // 
            // SignIn
            // 
            this.SignIn.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIn.Location = new System.Drawing.Point(115, 197);
            this.SignIn.Margin = new System.Windows.Forms.Padding(5);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(239, 66);
            this.SignIn.TabIndex = 13;
            this.SignIn.Text = "Sign up";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources.Trivia;
            this.pictureBox1.Location = new System.Drawing.Point(14, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // EmailLable
            // 
            this.EmailLable.AutoSize = true;
            this.EmailLable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLable.ForeColor = System.Drawing.Color.Chartreuse;
            this.EmailLable.Location = new System.Drawing.Point(57, 162);
            this.EmailLable.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EmailLable.Name = "EmailLable";
            this.EmailLable.Size = new System.Drawing.Size(49, 23);
            this.EmailLable.TabIndex = 15;
            this.EmailLable.Text = "Email";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(115, 127);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(5);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(238, 23);
            this.passwordBox.TabIndex = 17;
            // 
            // MsgToUser
            // 
            this.MsgToUser.AutoSize = true;
            this.MsgToUser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgToUser.ForeColor = System.Drawing.Color.Red;
            this.MsgToUser.Location = new System.Drawing.Point(10, 274);
            this.MsgToUser.Name = "MsgToUser";
            this.MsgToUser.Size = new System.Drawing.Size(0, 23);
            this.MsgToUser.TabIndex = 18;
            this.MsgToUser.Visible = false;
            // 
            // backB
            // 
            this.backB.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backB.Location = new System.Drawing.Point(278, 271);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(75, 26);
            this.backB.TabIndex = 19;
            this.backB.Text = "⤴Back";
            this.backB.UseVisualStyleBackColor = true;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(383, 306);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.MsgToUser);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.EmailLable);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.UserNameLable);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignUp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.Label UserNameLable;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label EmailLable;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label MsgToUser;
        private System.Windows.Forms.Button backB;

    }
}