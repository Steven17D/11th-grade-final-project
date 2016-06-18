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
using System.Threading;

namespace Client
{
    public partial class WaitForGame : Form
    {
        System.Net.Sockets.TcpClient clientSocket;
        Form menu;
        bool waitingForStart;
        bool isAdmin;
        bool gameStarted;
        int questionsNumber , questionTimeInSec;
        public WaitForGame(System.Net.Sockets.TcpClient clientSocket_, Form menu_, string roomName_, bool isAdmin_,int questionsNumber_ ,int questionTimeInSec_)
        {
            InitializeComponent();
            waitingForStart = true;
            gameStarted = false;
            clientSocket = clientSocket_;
            menu = menu_;
            questionsNumber = questionsNumber_;
            questionTimeInSec = questionTimeInSec_;
            roomNameLabel.Text = "You are connected to room " + roomName_;
            roomProperties.Text = "Number of questions: " + questionsNumber + " | " + "Time per question: " + questionTimeInSec;
            isAdmin = isAdmin_;
            leaveCloseB.Text = "Leave Room";
            leaveCloseB.Left += leaveCloseB.Width / 2 + 5;
            startGame.Hide();

            NetworkStream serverStream = clientSocket.GetStream();
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

            Thread listUpdater = new Thread(() => listUpdate(clientSocket));
            listUpdater.Start();
        }

        public WaitForGame(System.Net.Sockets.TcpClient clientSocket_, Form menu_, string roomName_, bool isAdmin_, int questionsNumber_, int questionTimeInSec_, int maxNumOfPlayers)
        {
            InitializeComponent();
            waitingForStart = true;
            gameStarted = false;
            clientSocket = clientSocket_;
            menu = menu_;
            questionsNumber = questionsNumber_;
            questionTimeInSec = questionTimeInSec_;
            roomNameLabel.Text = "You are connected to room " + roomName_;
            roomProperties.Text = "Max number of players: " + maxNumOfPlayers + " | " + "Number of questions: " + questionsNumber + " | " + "Time per question: " + questionTimeInSec;
            isAdmin = isAdmin_;
            leaveCloseB.Text = "Close Room";

            Thread listUpdater = new Thread(() => listUpdate(clientSocket));
            listUpdater.Start();
        }

        private void listUpdate(System.Net.Sockets.TcpClient _clientSocket)
        {
            while (waitingForStart)
            {
                NetworkStream serverStream = clientSocket.GetStream();
                if (!waitingForStart) { break; }
                
                byte[] inStream = new byte[3]; //msg code
                serverStream.Read(inStream, 0, 3);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);

                string returnUser;
                if (returndata == "108")
                {
                    inStream = new byte[1]; //number of users
                    serverStream.Read(inStream, 0, 1);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    Invoke((MethodInvoker)delegate { roomPlayers.Items.Clear(); }); 
                    for (int i = 0; i < int.Parse(returndata); i++) //loop for number of users
                    {
                        string user;

                        inStream = new byte[2]; //2 bytes for size of room name
                        serverStream.Read(inStream, 0, 2);
                        returnUser = System.Text.Encoding.ASCII.GetString(inStream); //user name size

                        inStream = new byte[int.Parse(returnUser)]; //size of room name
                        serverStream.Read(inStream, 0, int.Parse(returnUser));
                        returnUser = System.Text.Encoding.ASCII.GetString(inStream);
                        user = returnUser;

                        Invoke((MethodInvoker)delegate { roomPlayers.Items.Add(user); });
                    }
                }
                else if (returndata == "116" && !isAdmin) //admin closed the room
                {
                    Invoke((MethodInvoker)delegate { 
                        msgToUser.Text = "The admin closed the room press OK to continue";
                        leaveCloseB.Text = "OK";
                        waitingForStart = false;
                    });
                }
                else if (returndata == "118")
                {

                    Invoke((MethodInvoker)delegate
                    {
                        gameStarted = true;
                        Form GameForm = new Game(clientSocket, menu, true, questionsNumber, questionTimeInSec);
                        GameForm.Show();
                        this.Close();
                    });
                }
            }
        }

        private void WaitForGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAdmin)
            {
                string joinMsg = "215";
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(joinMsg);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
            else
            {
                string joinMsg = "211";
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(joinMsg);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
            waitingForStart = false;
            if(!gameStarted)
                menu.Show();
        }

        private void leaveCloseB_Click(object sender, EventArgs e)
        {
            if (leaveCloseB.Text == "Leave Room") //guest case
            {
                string joinMsg = "211";
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(joinMsg);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                waitingForStart = false;
                
                this.Close();
            }
            else if (leaveCloseB.Text == "Close Room")
            {
                string joinMsg = "215";
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(joinMsg);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                waitingForStart = false;

                this.Close();
            }
            else if (leaveCloseB.Text == "OK")
            {
                this.Close();
            }
        }

        private void WaitForGame_Load(object sender, EventArgs e)
        {
            
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            gameStarted = true;
            Form GameForm = new Game(clientSocket, menu, false, questionsNumber, questionTimeInSec);
            GameForm.Show();
            this.Close();
        }
    }
}
