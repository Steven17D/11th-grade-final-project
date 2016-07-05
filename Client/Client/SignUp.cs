using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class SignUp : Form
    {
        System.Net.Sockets.TcpClient clientSocket;
        Form parent;
        public SignUp(System.Net.Sockets.TcpClient clientSocket_, Form parent_)
        {
            InitializeComponent();
            clientSocket = clientSocket_;
            parent = parent_;
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text.Length == 0 || emailBox.Text.Length == 0 || passwordBox.Text.Length == 0)
            {
                MsgToUser.Text = "Please fill all fields";
                MsgToUser.Visible = true;
                return;
            }
            string signUpMsg = "203" +
                userNameBox.Text.Length.ToString().PadLeft(2, '0') + userNameBox.Text +
                passwordBox.Text.Length.ToString().PadLeft(2, '0') + passwordBox.Text +
                emailBox.Text.Length.ToString().PadLeft(2, '0') + emailBox.Text;
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(signUpMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[4];
            serverStream.Read(inStream, 0, 4);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            //msg(returndata);

            switch (returndata.Substring(0, 4))
            {
                case "1040":
                    //Success
                    this.Close();
                    parent.Show();
                    break;
                case "1041":
                    //Password is illegal
                    MsgToUser.Text = "Password is illegal";
                    MsgToUser.Visible = true;
                    break;
                case "1042":
                    //Username is already exists
                    MsgToUser.Text = "Username is already exists";
                    MsgToUser.Visible = true;
                    break;
                case "1043":
                    //Username is illegal
                    MsgToUser.Text = "Username is illegal";
                    MsgToUser.Visible = true;
                    break;
                case "1044":
                    //Other
                    MsgToUser.Text = "Unknown Error";
                    MsgToUser.Visible = true;
                    break;
                default:
                    msg("Got wrong code: " + returndata);
                    break;
            }
        }
        public void msg(string mesg) { MessageBox.Show(mesg); }

        private void backB_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
