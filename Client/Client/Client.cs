using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.Net.Sockets;
using NetDLL;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Client : MaterialForm
    {
        public string Name { get; set; }
        public string Password { get; set; }
        private TcpClient mySocket;
        private int port;
        private IPAddress myIp;
        private StreamReader _in;
        private StreamWriter _out;
        private Thread reading;

        public Client()
        {
            port = 15567;
            mySocket = new TcpClient();
            reading = new Thread(Read);
            reading.IsBackground = true;
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
            reading.Start();
        }

        private void Read()
        {
            try
            {
                while (true)
                {
                    string s = null;
                    while ((s = _in.ReadLine()) != null)
                    {
                        Byte[] bytes = ASCIIEncoding.ASCII.GetBytes(s);
                        Packet packet = Packet.ToPacket(bytes);
                        if (packet != null)
                        {
                            if (packet is PacketCurrentNames)
                            {
                                friendListBox.Items.Clear();
                                ((PacketCurrentNames)packet).Names.ForEach(x =>
                                {
                                    friendListBox.Items.Add(x);
                                });
                            }
                            else if (packet is PacketConnected)
                            {
                                Write(new PacketNameRequest(nameTextBox.Text));
                            }
                            else if (packet is PacketSendText)
                            {
                                if (Name == ((PacketSendText)packet).Sender)
                                {
                                    messageRichTextBox.Text += "Du: " + ((PacketSendText)packet).Text + "\n\n";
                                }
                                else
                                {
                                    messageRichTextBox.Text += ((PacketSendText)packet).Sender + ": " + ((PacketSendText)packet).Text + "\n\n";
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Close();
            }
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
                _in = new StreamReader(mySocket.GetStream());
                _out = new StreamWriter(mySocket.GetStream());
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (writeMessageRichTextBox.Text != "")
            {
                Write(new PacketSendUniText(nameTextBox.Text, writeMessageRichTextBox.Text));
            }
        }

        public void Write(Packet packet)
        {
            string str = packet.ToString();
            _out.WriteLine(str);
            _out.Flush();
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
