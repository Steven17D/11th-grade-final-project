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
    public partial class RoomCreate : Form
    {
        Form parent;
        System.Net.Sockets.TcpClient clientSocket;
        bool roomCreated;
        public RoomCreate(System.Net.Sockets.TcpClient clientSocket_, Form parent_)
        {
            InitializeComponent();
            parent = parent_;
            clientSocket = clientSocket_;
            msgToUser.Visible = false;
            roomCreated = false;
        }

        private void createRoomB_Click(object sender, EventArgs e)
        {
            string createRoomMsg = "213" + roomName.Text.Length.ToString().PadLeft(2) + roomName.Text +
                numOfPB.Text.ToString().PadLeft(1) + numOfQB.Text.ToString().PadLeft(2) + timeForQB.Text.ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(createRoomMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[4];
            serverStream.Read(inStream, 0, 4);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            if (returndata == "1140")
            {
                Form waitForGameForm = new WaitForGame(clientSocket, parent, roomName.Text, true, int.Parse(numOfQB.Text), int.Parse(timeForQB.Text), int.Parse(numOfPB.Text));
                waitForGameForm.Show();
                roomCreated = true;
                this.Close();
            }
            else
            {
                msgToUser.Visible = true;
            }
        }

        private void backB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoomCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!roomCreated)
                parent.Show();
        }
    }
}
