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
using System.Timers;

namespace Client
{
    public partial class Game : Form
    {
        System.Net.Sockets.TcpClient clientSocket;
        Form menu;
        bool inGame;
        bool fromThread;
        int questionNumber, score;
        int questionsNumber ,questionTimeInSec;
        bool ansSent;
        System.Timers.Timer aTimer;
        public Game(System.Net.Sockets.TcpClient clientSocket_, Form menu_, bool fromThread_, int questionsNumber_, int questionTimeInSec_)
        {
            InitializeComponent();
            //aTimer = new System.Timers.Timer(1000 * questionTimeInSec_);
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            menu = menu_;
            fromThread = fromThread_;
            clientSocket = clientSocket_;
            inGame = true;
            questionNumber = 0;
            score = 0;
            questionsNumber = questionsNumber_;
            questionTimeInSec = questionTimeInSec_;
            Thread getQuestionsThread = new Thread(() => getQuestions(clientSocket));
            getQuestionsThread.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)delegate { timeLeftLable.Text = e.SignalTime.ToString(); });
        }

        private void getQuestions(System.Net.Sockets.TcpClient _clientSocket)
        {
            string returndata;
            NetworkStream serverStream;
            byte[] inStream;
            while (inGame)
            {
                if (fromThread){ returndata = "118"; fromThread = false; } else
                {
                    serverStream = clientSocket.GetStream();
                    inStream = new byte[3]; //msg code
                    serverStream.Read(inStream, 0, 3);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);
                }

                if (returndata == "118")
                {
                    List<string> info = new List<string>(5);
                    for (int i = 0; i < 5; i++)
                    {
                        serverStream = clientSocket.GetStream();
                        inStream = new byte[3]; //size of info
                        serverStream.Read(inStream, 0, 3);
                        returndata = System.Text.Encoding.ASCII.GetString(inStream);

                        serverStream = clientSocket.GetStream();
                        inStream = new byte[int.Parse(returndata)]; //msg code
                        serverStream.Read(inStream, 0, int.Parse(returndata));
                        returndata = System.Text.Encoding.ASCII.GetString(inStream);

                        info.Add(returndata);
                    }
                    questionLable.Text = info[0];
                    q1.Text = info[1];
                    q2.Text = info[2];
                    q3.Text = info[3];
                    q4.Text = info[4];
                    aTimer.Enabled = true;
                    Thread.Sleep(questionTimeInSec * 1000);
                    //if (timeLeftLable.Text == "0" && !ansSent)
                    //{
                    //    string ansMsg = "219" + "5" + "5";
                    //    serverStream = clientSocket.GetStream();
                    //    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
                    //    serverStream.Write(outStream, 0, outStream.Length);
                    //    serverStream.Flush();
                    //}
                }
                else if (returndata == "120")
                {
                    serverStream = clientSocket.GetStream();
                    inStream = new byte[1];
                    serverStream.Read(inStream, 0, 1);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);

                    if (returndata == "1")
                    {
                        score++;
                        scoreLable.Text = "Score: " + score + "/" + questionsNumber;
                    }
                }
            }
        }

        private void exitB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void q1_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "5" + "5".PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
        }

        private void q2_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "2" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
        }

        private void q3_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "3" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
        }

        private void q4_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "4" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            string quitMsg = "222";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(quitMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            aTimer.Enabled = false;
            inGame = false;

            menu.Show();
        }
    }
}
