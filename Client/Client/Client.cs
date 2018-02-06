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
        public string Name { get; set; }
        public string Password { get; set; }
        private IPEndPoint myEndPoint;
        private Socket mySocket;
        private int port;
        private IPAddress myIp;

        public Client()
        {
            port = 15567;
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ipAdressTextBox.Text)|| string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Bitte IP Adresse oder Name einfügen!","Fehler",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Name = nameTextBox.Text;
            ConnectToServer();
        }
        private void ConnectToServer()
        {
            try
            {
                mySocket.Connect(new IPEndPoint(IPAddress.Parse(ipAdressTextBox.Text), 15567));

            }
            catch (Exception)
            {
                MessageBox.Show("Verbindung fehlgeschlagen.");
                Close();
            }
            if (mySocket.Connected)
            {
                MessageBox.Show("Erfolgreich verbunden.");
                mySocket.Close();
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {

        }

        private void ipAdressTextBox_Click(object sender, EventArgs e)
        {
            ipAdressTextBox.Text = string.Empty;
        }

        private void nameTextBox_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = string.Empty;
        }


    }
}
