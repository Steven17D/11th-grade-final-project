namespace Client
{
    partial class Form1
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
            this.loginB = new System.Windows.Forms.Button();
            this.registerB = new System.Windows.Forms.Button();
            this.usernameIn = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.emailIn = new System.Windows.Forms.TextBox();
            this.passwordIn = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginB
            // 
            this.loginB.Location = new System.Drawing.Point(116, 106);
            this.loginB.Name = "loginB";
            this.loginB.Size = new System.Drawing.Size(75, 23);
            this.loginB.TabIndex = 0;
            this.loginB.Text = "Login";
            this.loginB.UseVisualStyleBackColor = true;
            this.loginB.Click += new System.EventHandler(this.loginB_Click);
            // 
            // registerB
            // 
            this.registerB.Location = new System.Drawing.Point(197, 106);
            this.registerB.Name = "registerB";
            this.registerB.Size = new System.Drawing.Size(75, 23);
            this.registerB.TabIndex = 1;
            this.registerB.Text = "Register";
            this.registerB.UseVisualStyleBackColor = true;
            // 
            // usernameIn
            // 
            this.usernameIn.Location = new System.Drawing.Point(74, 15);
            this.usernameIn.Name = "usernameIn";
            this.usernameIn.Size = new System.Drawing.Size(198, 20);
            this.usernameIn.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(12, 18);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(58, 13);
            this.Username.TabIndex = 3;
            this.Username.Text = "Username:";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(12, 48);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(56, 13);
            this.password.TabIndex = 4;
            this.password.Text = "Password:";
            // 
            // emailIn
            // 
            this.emailIn.Location = new System.Drawing.Point(74, 75);
            this.emailIn.Name = "emailIn";
            this.emailIn.Size = new System.Drawing.Size(198, 20);
            this.emailIn.TabIndex = 2;
            // 
            // passwordIn
            // 
            this.passwordIn.Location = new System.Drawing.Point(74, 45);
            this.passwordIn.Name = "passwordIn";
            this.passwordIn.Size = new System.Drawing.Size(198, 20);
            this.passwordIn.TabIndex = 2;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(12, 78);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(35, 13);
            this.email.TabIndex = 5;
            this.email.Text = "Email:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.email);
            this.Controls.Add(this.password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.passwordIn);
            this.Controls.Add(this.emailIn);
            this.Controls.Add(this.usernameIn);
            this.Controls.Add(this.registerB);
            this.Controls.Add(this.loginB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginB;
        private System.Windows.Forms.Button registerB;
        private System.Windows.Forms.TextBox usernameIn;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox emailIn;
        private System.Windows.Forms.TextBox passwordIn;
        private System.Windows.Forms.Label email;
    }
}

