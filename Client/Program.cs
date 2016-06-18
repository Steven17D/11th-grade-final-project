using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                clientSocket.Connect("127.0.0.1", 8820); //connect to localhost
                //clientSocket.Connect("10.200.201.74", 8820); 
                Application.Run(new Menu(clientSocket));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Run(new ConnectionFailed());
            }

        }
    }
}
