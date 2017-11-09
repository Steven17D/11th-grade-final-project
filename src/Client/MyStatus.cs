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
    public partial class MyStatus : Form
    {
        Form parent;
        public MyStatus(System.Net.Sockets.TcpClient clientSocket_, Form parent_)
        {
            InitializeComponent();
            parent = parent_;
            string myStatusMsg = "225";
            NetworkStream serverStream = clientSocket_.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(myStatusMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[3 + 4]; //3 bytes of msg code and 4 bytes of number of games
            serverStream.Read(inStream, 0, 7);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            // 126   0000   000000  000000  0000
            // code  games  right   wrong   avg
            int numOfgames = int.Parse(returndata.Substring(3, 4));
            if (numOfgames != 0)
            {
                inStream = new byte[6 + 6 + 4];
                serverStream.Read(inStream, 0, 16);
                returndata = System.Text.Encoding.ASCII.GetString(inStream);

                numOfGames.Text += numOfgames;
                numOfRightAns.Text += int.Parse(returndata.Substring(0,6)).ToString();
                numOfWrongAns.Text += int.Parse(returndata.Substring(6, 6)).ToString();
                AvgTimeForAns.Text += float.Parse(returndata.Substring(12, 2) + "." + returndata.Substring(14,2)).ToString();
            }
            else
            {
                numOfGames.Text += "0";
                numOfRightAns.Text += "0";
                numOfWrongAns.Text += "0";
                AvgTimeForAns.Text += "0";
            }
        }

        private void backB_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void MyStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
