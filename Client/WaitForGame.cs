using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class WaitForGame : Form
    {
        System.Net.Sockets.TcpClient clientSocket;
        Form parent;
        public WaitForGame(System.Net.Sockets.TcpClient clientSocket_, Form parent_, string room_)
        {
            InitializeComponent();
            clientSocket = clientSocket_;
            parent = parent_;
            roomNameLabel.Text = room_;
        }
    }
}
