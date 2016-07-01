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
        int clickedButton;
        int leftTime;
        Thread getQuestionsThread;
        public Game(System.Net.Sockets.TcpClient clientSocket_, Form menu_, bool fromThread_, int questionsNumber_, int questionTimeInSec_)
        {
            InitializeComponent();
            clickedButton = 0;
            menu = menu_;
            fromThread = fromThread_;
            clientSocket = clientSocket_;
            inGame = true;
            questionNumber = 1;
            score = 0;
            questionsNumber = questionsNumber_;
            questionTimeInSec = questionTimeInSec_;
            disableButtons();
            getQuestionsThread = new Thread(() => getQuestions());
            getQuestionsThread.Start();
        }

        private void getQuestions()
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

                if (returndata == "118") //get q&a
                {
                    List<string> info = new List<string>(5);
                    for (int i = 0; i < 5; i++)
                    {
                        serverStream = clientSocket.GetStream();
                        inStream = new byte[3]; //size of info
                        serverStream.Read(inStream, 0, 3);
                        returndata = System.Text.Encoding.ASCII.GetString(inStream);
                        if (int.Parse(returndata) == 0)
                        {
                            MessageBox.Show("Failed to get information from server");
                            return;
                        }

                        serverStream = clientSocket.GetStream();
                        inStream = new byte[int.Parse(returndata)]; 
                        serverStream.Read(inStream, 0, int.Parse(returndata));
                        returndata = System.Text.Encoding.ASCII.GetString(inStream);

                        info.Add(returndata);
                    }
                    Invoke((MethodInvoker)delegate {
                        questionNumberLable.Text = "Question:" + questionNumber + "/" + questionsNumber;
                        scoreLable.Text = "Score: " + score.ToString() + "/" + questionsNumber.ToString();
                        questionLable.Text = info[0];
                        q1.Text = info[1];
                        q2.Text = info[2];
                        q3.Text = info[3];
                        q4.Text = info[4];
                        leftTime = questionTimeInSec;
                        startButtons();
                        resetButtons();
                        questionNumber++;
                        timeLeftLable.Text = leftTime.ToString();
                        ansSent = false;
                    });
                    for (int i = 0; i < questionTimeInSec && !ansSent; i++)
                    {
                        Thread.Sleep(1000);
                        Invoke((MethodInvoker)delegate
                        {
                            leftTime--;
                            timeLeftLable.Text = leftTime.ToString();
                        });
                    }
                    if (!ansSent)
                    {
                        Invoke((MethodInvoker)delegate { disableButtons(); });
                        string ansMsg = "219" + "5" + "5";
                        serverStream = clientSocket.GetStream();
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();
                    }
                    else
                    {
                        Invoke((MethodInvoker)delegate { timeLeftLable.Text = questionTimeInSec.ToString(); });
                    }
                }
                else if (returndata == "120") //correct or not
                {
                    serverStream = clientSocket.GetStream();
                    inStream = new byte[1];
                    serverStream.Read(inStream, 0, 1);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);

                    if (returndata == "1")
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            score++;
                            scoreLable.Text = "Score: " + score.ToString() + "/" + questionsNumber.ToString();
                            greenButton(clickedButton);
                        });
                    }
                    else
                    {
                        Invoke((MethodInvoker)delegate { redButtons(); });
                    }
                    Thread.Sleep(750);
                }
                else if (returndata == "121") //game ended
                {
                    Invoke((MethodInvoker)delegate{ 
                        Form scores = new Scores(clientSocket, menu, this);
                        scores.Show();
                        inGame = false;
                    });
                }
            }
        }

        private void exitB_Click(object sender, EventArgs e)
        {
            Game_FormClosing(null, null);
            this.Close();
        }

        private void q1_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "1" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
            clickedButton = 1;
            disableButtons();
        }

        private void q2_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "2" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
            clickedButton = 2;
            disableButtons();
        }

        private void q3_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "3" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
            clickedButton = 3;
            disableButtons();
        }

        private void q4_Click(object sender, EventArgs e)
        {
            string ansMsg = "219" + "4" + (questionTimeInSec - int.Parse(timeLeftLable.Text)).ToString().PadLeft(2);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(ansMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            ansSent = true;
            clickedButton = 4;
            disableButtons();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            getQuestionsThread.Abort();

            string quitMsg = "222";
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(quitMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            inGame = false;

            menu.Show();
        }

        private void disableButtons()
        {
            q1.Enabled = false;
            q2.Enabled = false;
            q3.Enabled = false;
            q4.Enabled = false;
        }

        private void startButtons()
        {
            q1.Enabled = true;
            q2.Enabled = true;
            q3.Enabled = true;
            q4.Enabled = true;
        }

        private void redButtons()
        {
            q1.BackColor = Color.Red;
            q2.BackColor = Color.Red;
            q3.BackColor = Color.Red;
            q4.BackColor = Color.Red;
        }

        private void resetButtons()
        {
            q1.BackColor = Color.White;
            q2.BackColor = Color.White;
            q3.BackColor = Color.White;
            q4.BackColor = Color.White;
        }

        private void greenButton(int i)
        {
            Button[] buttons = { q1, q2, q3, q4 };
            if(i != 0)
                buttons[i-1].BackColor = Color.Green;
        }
    }
}
