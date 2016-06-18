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
    public partial class BestScores : Form
    {
        Form parent;
        public BestScores(System.Net.Sockets.TcpClient clientSocket_, Form parent_)
        {
            InitializeComponent();
            parent = parent_;

            List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label> { user1, user2, user3 };

            string bestScoreMsg = "223";
            NetworkStream serverStream = clientSocket_.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(bestScoreMsg);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[3]; //3 bytes of msg code
            serverStream.Read(inStream, 0, 3);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            if (returndata == "124")
            {
                for (int i = 0; i < 3; i++)
                {
                    inStream = new byte[2]; //2 bytes of name size
                    serverStream.Read(inStream, 0, 2);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);

                    inStream = new byte[int.Parse(returndata) + 6]; //name and 6 bytes of score
                    serverStream.Read(inStream, 0, int.Parse(returndata) + 6);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    labels[i].Text = returndata.Substring(0, returndata.Length - 6) + " - " + int.Parse(returndata.Substring(returndata.Length - 6));
                }
            }
        }

        private void backB_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void BestScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
