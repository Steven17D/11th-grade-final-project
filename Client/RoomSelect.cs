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
    public partial class RoomSelect : Form
    {
        System.Net.Sockets.TcpClient clientSocket;
        Form parent;
        bool joinedToRoom;
        public RoomSelect(System.Net.Sockets.TcpClient clientSocket_, Form parent_)
        {
            InitializeComponent();
            clientSocket = clientSocket_;
            parent = parent_;
            joinedToRoom = false;
        }

        private void joinB_Click(object sender, EventArgs e)
        {
            string selectedRoomId = roomList.SelectedItem.ToString().Substring(9, 4);
            string joinMsg = "209" + selectedRoomId;
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(joinMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[4];
            serverStream.Read(inStream, 0, 4);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            switch (returndata)
            {
                case "1100":
                    //success
                    joinedToRoom = true;
                    this.Close();
                    inStream = new byte[4]; //2 byte of questionsNumber and 2 byte of questionTimeInSec
                    serverStream.Read(inStream, 0, 4);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    Form waitForGameForm = new WaitForGame(clientSocket, parent,
                        roomList.SelectedItem.ToString().Substring(27), false,
                        int.Parse(returndata.Substring(0, 2)), int.Parse(returndata.Substring(2,2)));
                    waitForGameForm.Show();
                    break;
                case "1101":
                    // failed - room is full
                    msgToUser.Text = "failed - room is full";
                    break;
                case "1102":
                    //failed - room not exist or other reason
                    msgToUser.Text = "failed - room not exist or other reason";
                    break;
                default:
                    //unknown
                    msgToUser.Text = "Unknown code";
                    break;
            }
        }

        private void refreshB_Click(object sender, EventArgs e)
        {
            roomList.Items.Clear();
            
            string getRoomsMsg = "205";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(getRoomsMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[3 + 4]; //3 bytes for code and 4 bytes for number of rooms
            serverStream.Read(inStream, 0, 7);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            string returnRoom;
            if (returndata.Substring(0, 3) == "106")
            {
                for (int i = 0; i < int.Parse(returndata.Substring(3, 4)); i++)
                {
                    string roomDis;

                    inStream = new byte[4 + 2]; //4 bytes for room id and 2 bytes for size of room name
                    serverStream.Read(inStream, 0, 6);
                    returnRoom = System.Text.Encoding.ASCII.GetString(inStream);
                    roomDis = "Room id: " + returnRoom.Substring(0, 4);

                    inStream = new byte[int.Parse(returnRoom.Substring(4, 2))]; //size of room name
                    serverStream.Read(inStream, 0, int.Parse(returnRoom.Substring(4, 2)));
                    returnRoom = System.Text.Encoding.ASCII.GetString(inStream);
                    roomDis += " | Room name: " + returnRoom;

                    roomList.Items.Add(roomDis);
                }
            }

            roomPlayers.Items.Clear();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void RoomSelect_Load(object sender, EventArgs e)
        {
            string getRoomsMsg = "205";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(getRoomsMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[3 + 4]; //3 bytes for code and 4 bytes for number of rooms
            serverStream.Read(inStream, 0, 7);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            string returnRoom;
            if (returndata.Substring(0, 3) == "106")
            {
                for (int i = 0; i < int.Parse(returndata.Substring(3, 4)); i++)
                {
                    string roomDis;
                    
                    inStream = new byte[4 + 2]; //4 bytes for room id and 2 bytes for size of room name
                    serverStream.Read(inStream, 0, 6);
                    returnRoom = System.Text.Encoding.ASCII.GetString(inStream);
                    roomDis = "Room id: " + returnRoom.Substring(0, 4);

                    inStream = new byte[int.Parse(returnRoom.Substring(4,2))]; //size of room name
                    serverStream.Read(inStream, 0, int.Parse(returnRoom.Substring(4, 2)));
                    returnRoom = System.Text.Encoding.ASCII.GetString(inStream);
                    roomDis += " | Room name: " + returnRoom;

                    roomList.Items.Add(roomDis);
                }
            }
        }

        private void RoomSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!joinedToRoom)
                parent.Show();
        }

        private void roomList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (roomList.SelectedItem == null) { return; } //if selected empty Item
            roomPlayers.Items.Clear();
            string selectedRoomId = roomList.SelectedItem.ToString().Substring(9, 4);
            string getPlayersMsg = "207" + selectedRoomId;
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(getPlayersMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[3 + 1]; //3 bytes for code and 1 byte for number of users
            serverStream.Read(inStream, 0, 4);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            string returnUser;
            if (returndata.Substring(0, 3) == "108")
            {
                for (int i = 0; i < int.Parse(returndata.Substring(3, 1)); i++) //loop for number of users
                {
                    string user;

                    inStream = new byte[2]; //2 bytes for size of room name
                    serverStream.Read(inStream, 0, 2);
                    returnUser = System.Text.Encoding.ASCII.GetString(inStream); //user name size

                    inStream = new byte[int.Parse(returnUser)]; //size of room name
                    serverStream.Read(inStream, 0, int.Parse(returnUser));
                    returnUser = System.Text.Encoding.ASCII.GetString(inStream);
                    user = returnUser;

                    roomPlayers.Items.Add(user);
                }
            }
        }
    }
}
