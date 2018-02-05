using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.Net.Sockets;
using NetDLL;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : MaterialForm
    {
        private Client client;
        private bool logged;

        public Client()
        {
            TcpClient clients = new TcpClient();
            logged = false;
            try
            {
                IPAddress address;
            }
            catch
            {

            }
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a name!");
                return;
            }
            logged = true;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(!logged)
            {
                MessageBox.Show("You have to log in!", "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
