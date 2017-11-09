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
    public partial class Scores : Form
    {
        Form menu, game;
        TcpClient clientSocket;
        public Scores(System.Net.Sockets.TcpClient clientSocket_, Form menu_, Form game_)
        {
            InitializeComponent();
            game = game_;
            menu = menu_;
            clientSocket = clientSocket_;

            NetworkStream serverStream = clientSocket.GetStream();
            byte[] inStream = new byte[1];
            serverStream.Read(inStream, 0, 1); //number of users
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            int numOfUsers = int.Parse(returndata);

            this.Height = 100 + 40 * numOfUsers;

            for (int i = 0; i < numOfUsers; i++)
            {
                serverStream = clientSocket.GetStream();
                inStream = new byte[2]; //size of username
                serverStream.Read(inStream, 0, 2);
                returndata = System.Text.Encoding.ASCII.GetString(inStream);

                serverStream = clientSocket.GetStream();
                inStream = new byte[int.Parse(returndata)]; //username
                serverStream.Read(inStream, 0, int.Parse(returndata));
                returndata = System.Text.Encoding.ASCII.GetString(inStream);

                Label dynamicLable = new Label();
                dynamicLable.BackColor = System.Drawing.Color.Transparent;
                dynamicLable.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dynamicLable.ForeColor = System.Drawing.Color.Chartreuse;
                dynamicLable.Location = new System.Drawing.Point(12, 10 + i * 40);
                dynamicLable.Name = "label1";
                dynamicLable.Size = new System.Drawing.Size(360, 30);
                dynamicLable.TabIndex = 17;
                dynamicLable.Text = "username: " + returndata;
                dynamicLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                serverStream = clientSocket.GetStream();
                inStream = new byte[2]; //score
                serverStream.Read(inStream, 0, 2);
                returndata = System.Text.Encoding.ASCII.GetString(inStream);

                dynamicLable.Text += "  Score: " + int.Parse(returndata).ToString();

                this.Controls.Add(dynamicLable);
            }

            Button button = new Button();
            button.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.Location = new System.Drawing.Point(13, 40 * numOfUsers + 20);
            button.Name = "button";
            button.Size = new System.Drawing.Size(350, 30);
            button.TabIndex = 18;
            button.Text = "OK";
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(button);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Close();
            menu.Show();
            this.Close();
        }
    }
}
