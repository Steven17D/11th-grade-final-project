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
        public RoomSelect(System.Net.Sockets.TcpClient clientSocket_, Form parent_)
        {
            InitializeComponent();
            clientSocket = clientSocket_;
            parent = parent_;
        }

        private void joinB_Click(object sender, EventArgs e)
        {

        }

        private void refreshB_Click(object sender, EventArgs e)
        {

        }

        private void backB_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
