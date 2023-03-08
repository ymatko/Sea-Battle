﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SeaBattle.View
{
    public partial class Game : Form
    {
        public Game(bool isServer, string ip = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;

            if (isServer)
            {
                label2.Text = "isServer";
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
                FreezeBoardO();
            }
            else
            {
                label2.Text = "isHost";
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    FreezeBoardO();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
                FreezeBoardO();
            }
        }
        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            FreezeBoardO();
            ReceiveMove();
            UnfreezeBoardO();
        }

        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        List<string> ships = new List<string>();
        int i = 0;
        #region Freeze&Unfrees board
        private void FreezeBoardY()
        {
            Btn1Y.Enabled = false;
            Btn2Y.Enabled = false;
            Btn3Y.Enabled = false;
            Btn4Y.Enabled = false;
            Btn5Y.Enabled = false;
            Btn6Y.Enabled = false;
            Btn7Y.Enabled = false;
            Btn8Y.Enabled = false;
            Btn9Y.Enabled = false;
            Btn10Y.Enabled = false;
            Btn11Y.Enabled = false;
            Btn12Y.Enabled = false;
            Btn13Y.Enabled = false;
            Btn14Y.Enabled = false;
            Btn15Y.Enabled = false;
            Btn16Y.Enabled = false;
            Btn17Y.Enabled = false;
            Btn18Y.Enabled = false;
            Btn19Y.Enabled = false;
            Btn20Y.Enabled = false;
            Btn21Y.Enabled = false;
            Btn22Y.Enabled = false;
            Btn23Y.Enabled = false;
            Btn24Y.Enabled = false;
            Btn25Y.Enabled = false;
        }
        private void FreezeBoardO()
        {
            Btn1O.Enabled = false;
            Btn2O.Enabled = false;
            Btn3O.Enabled = false;
            Btn4O.Enabled = false;
            Btn5O.Enabled = false;
            Btn6O.Enabled = false;
            Btn7O.Enabled = false;
            Btn8O.Enabled = false;
            Btn9O.Enabled = false;
            Btn10O.Enabled = false;
            Btn11O.Enabled = false;
            Btn12O.Enabled = false;
            Btn13O.Enabled = false;
            Btn14O.Enabled = false;
            Btn15O.Enabled = false;
            Btn16O.Enabled = false;
            Btn17O.Enabled = false;
            Btn18O.Enabled = false;
            Btn19O.Enabled = false;
            Btn20O.Enabled = false;
            Btn21O.Enabled = false;
            Btn22O.Enabled = false;
            Btn23O.Enabled = false;
            Btn24O.Enabled = false;
            Btn25O.Enabled = false;
        }
        private void UnfreezeBoardY()
        {
            if (Btn1Y.Text == "")
                Btn1Y.Enabled = true;
            if (Btn2Y.Text == "")
                Btn2Y.Enabled = true;
            if (Btn3Y.Text == "")
                Btn3Y.Enabled = true;
            if (Btn4Y.Text == "")
                Btn4Y.Enabled = true;
            if (Btn5Y.Text == "")
                Btn5Y.Enabled = true;
            if (Btn6Y.Text == "")
                Btn6Y.Enabled = true;
            if (Btn7Y.Text == "")
                Btn7Y.Enabled = true;
            if (Btn8Y.Text == "")
                Btn8Y.Enabled = true;
            if (Btn9Y.Text == "")
                Btn9Y.Enabled = true;
            if (Btn10Y.Text == "")
                Btn10Y.Enabled = true;
            if (Btn11Y.Text == "")
                Btn11Y.Enabled = true;
            if (Btn12Y.Text == "")
                Btn12Y.Enabled = true;
            if (Btn13Y.Text == "")
                Btn13Y.Enabled = true;
            if (Btn14Y.Text == "")
                Btn14Y.Enabled = true;
            if (Btn15Y.Text == "")
                Btn15Y.Enabled = true;
            if (Btn16Y.Text == "")
                Btn16Y.Enabled = true;
            if (Btn17Y.Text == "")
                Btn17Y.Enabled = true;
            if (Btn18Y.Text == "")
                Btn18Y.Enabled = true;
            if (Btn19Y.Text == "")
                Btn19Y.Enabled = true;
            if (Btn20Y.Text == "")
                Btn20Y.Enabled = true;
            if (Btn21Y.Text == "")
                Btn21Y.Enabled = true;
            if (Btn22Y.Text == "")
                Btn22Y.Enabled = true;
            if (Btn23Y.Text == "")
                Btn23Y.Enabled = true;
            if (Btn24Y.Text == "")
                Btn24Y.Enabled = true;
            if (Btn25Y.Text == "")
                Btn25Y.Enabled = true;
        }
        private void UnfreezeBoardO()
        {
            if (Btn1O.Text == "")
                Btn1O.Enabled = true;
            if (Btn2O.Text == "")
                Btn2O.Enabled = true;
            if (Btn3O.Text == "")
                Btn3O.Enabled = true;
            if (Btn4O.Text == "")
                Btn4O.Enabled = true;
            if (Btn5O.Text == "")
                Btn5O.Enabled = true;
            if (Btn6O.Text == "")
                Btn6O.Enabled = true;
            if (Btn7O.Text == "")
                Btn7O.Enabled = true;
            if (Btn8O.Text == "")
                Btn8O.Enabled = true;
            if (Btn9O.Text == "")
                Btn9O.Enabled = true;
            if (Btn10O.Text == "")
                Btn10O.Enabled = true;
            if (Btn11O.Text == "")
                Btn11O.Enabled = true;
            if (Btn12O.Text == "")
                Btn12O.Enabled = true;
            if (Btn13O.Text == "")
                Btn13O.Enabled = true;
            if (Btn14O.Text == "")
                Btn14O.Enabled = true;
            if (Btn15O.Text == "")
                Btn15O.Enabled = true;
            if (Btn16O.Text == "")
                Btn16O.Enabled = true;
            if (Btn17O.Text == "")
                Btn17O.Enabled = true;
            if (Btn18O.Text == "")
                Btn18O.Enabled = true;
            if (Btn19O.Text == "")
                Btn19O.Enabled = true;
            if (Btn20O.Text == "")
                Btn20O.Enabled = true;
            if (Btn21O.Text == "")
                Btn21O.Enabled = true;
            if (Btn22O.Text == "")
                Btn22O.Enabled = true;
            if (Btn23O.Text == "")
                Btn23O.Enabled = true;
            if (Btn24O.Text == "")
                Btn24O.Enabled = true;
            if (Btn25O.Text == "")
                Btn25O.Enabled = true;
        }
        #endregion

        private void CreateShip (Button button)
        {
            button.BackColor = Color.RoyalBlue;
            button.Enabled = false;
            ships.Add(button.Name);
        }

        private void StartGame(Button button)
        {
            if (i == 5)
            {
                FreezeBoardY();
                UnfreezeBoardO();
            }
            CreateShip(button);
            i++;
            label1.Text = string.Join(" ", ships); //delete
        }
        private void ReceiveMove()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1)
            {
                if (ships.Contains(Btn1Y.Text))
                {
                    Btn1Y.BackColor = Color.Yellow; //delete
                    label3.Text = "You hit"; //delete
                }
                else
                {
                    label3.Text = "Miss"; //delete
                }
            }
            if (buffer[0] == 2)
            {
                if (ships.Contains(Btn2Y.Text))
                {
                    Btn2Y.BackColor = Color.Yellow; //delete
                    label3.Text = "You hit"; //delete
                }
                else
                {
                    label3.Text = "Miss"; //delete
                }
            }
            if (buffer[0] == 3)
            {
                if (ships.Contains(Btn3Y.Text))
                {
                    Btn3Y.BackColor = Color.Yellow; //delete
                    label3.Text = "You hit"; //delete
                }
                else
                {
                    label3.Text = "Miss"; //delete
                }
            }
            if (buffer[0] == 4)
            {
                if (ships.Contains(Btn4Y.Text))
                {
                    Btn4Y.BackColor = Color.Yellow; //delete
                    label3.Text = "You hit"; //delete
                }
                else
                {
                    label3.Text = "Miss"; //delete
                }
            }
            if (buffer[0] == 5)
            {
                if (ships.Contains(Btn5Y.Text))
                {
                    Btn5Y.BackColor = Color.Yellow; //delete
                    label3.Text = "You hit"; //delete
                }
                else
                {
                    label3.Text = "Miss"; //delete
                }
            }
            if (buffer[0] == 6)
                Btn6Y.BackColor = Color.Red;
            if (buffer[0] == 7)
                Btn7Y.BackColor = Color.Red;
            if (buffer[0] == 8)
                Btn8Y.BackColor = Color.Red;
            if (buffer[0] == 9)
                Btn9Y.BackColor = Color.Red;
            if (buffer[0] == 10)
                Btn10Y.BackColor = Color.Red;
            if (buffer[0] == 11)
                Btn11Y.BackColor = Color.Red;
            if (buffer[0] == 12)
                Btn12Y.BackColor = Color.Red;
            if (buffer[0] == 13)
                Btn13Y.BackColor = Color.Red;
            if (buffer[0] == 14)
                Btn14Y.BackColor = Color.Red;
            if (buffer[0] == 15)
                Btn15Y.BackColor = Color.Red;
            if (buffer[0] == 16)
                Btn16Y.BackColor = Color.Red;
            if (buffer[0] == 17)
                Btn17Y.BackColor = Color.Red;
            if (buffer[0] == 18)
                Btn18Y.BackColor = Color.Red;
            if (buffer[0] == 19)
                Btn19Y.BackColor = Color.Red;
            if (buffer[0] == 20)
                Btn20Y.BackColor = Color.Red;
            if (buffer[0] == 21)
                Btn21Y.BackColor = Color.Red;
            if (buffer[0] == 22)
                Btn22Y.BackColor = Color.Red;
            if (buffer[0] == 23)
                Btn23Y.BackColor = Color.Red;
            if (buffer[0] == 24)
                Btn24Y.BackColor = Color.Red;
            if (buffer[0] == 25)
                Btn25Y.BackColor = Color.Red;
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }

        #region button
        private void Btn1Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn1Y);
        }

        private void Btn2Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn2Y);
        }

        private void Btn3Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn3Y);
        }

        private void Btn4Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn4Y);
        }

        private void Btn5Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn5Y);
        }

        private void Btn6Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn6Y);
        }

        private void Btn7Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn7Y);
        }

        private void Btn8Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn8Y);
        }

        private void Btn9Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn9Y);
        }

        private void Btn10Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn10Y);
        }

        private void Btn11Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn11Y);
        }

        private void Btn12Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn12Y);
        }

        private void Btn13Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn13Y);
        }

        private void Btn14Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn14Y);
        }

        private void Btn15Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn15Y);
        }

        private void Btn16Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn16Y);
        }

        private void Btn17Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn17Y);
        }

        private void Btn18Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn18Y);
        }

        private void Btn19Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn19Y);
        }

        private void Btn20Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn20Y);
        }

        private void Btn21Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn21Y);
        }

        private void Btn22Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn22Y);
        }

        private void Btn23Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn23Y);
        }

        private void Btn24Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn24Y);
        }

        private void Btn25Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn25Y);
        }

        private void Btn1O_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn2O_Click(object sender, EventArgs e)
        {
            byte[] num = { 2 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn3O_Click(object sender, EventArgs e)
        {
            byte[] num = { 3 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn4O_Click(object sender, EventArgs e)
        {
            byte[] num = { 4 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn5O_Click(object sender, EventArgs e)
        {
            byte[] num = { 5 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn6O_Click(object sender, EventArgs e)
        {
            byte[] num = { 6 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn7O_Click(object sender, EventArgs e)
        {
            byte[] num = { 7 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn8O_Click(object sender, EventArgs e)
        {
            byte[] num = { 8 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn9O_Click(object sender, EventArgs e)
        {
            byte[] num = { 9 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn10O_Click(object sender, EventArgs e)
        {
            byte[] num = { 10 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn11O_Click(object sender, EventArgs e)
        {
            byte[] num = { 11 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn12O_Click(object sender, EventArgs e)
        {
            byte[] num = { 12 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn13O_Click(object sender, EventArgs e)
        {
            byte[] num = { 13 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn14O_Click(object sender, EventArgs e)
        {
            byte[] num = { 14 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn15O_Click(object sender, EventArgs e)
        {
            byte[] num = { 15 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn16O_Click(object sender, EventArgs e)
        {
            byte[] num = { 16 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn17O_Click(object sender, EventArgs e)
        {
            byte[] num = { 17 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn18O_Click(object sender, EventArgs e)
        {
            byte[] num = { 18 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn19O_Click(object sender, EventArgs e)
        {
            byte[] num = { 19 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn20O_Click(object sender, EventArgs e)
        {
            byte[] num = { 20 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn21O_Click(object sender, EventArgs e)
        {
            byte[] num = { 21 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn22O_Click(object sender, EventArgs e)
        {
            byte[] num = { 22 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn23O_Click(object sender, EventArgs e)
        {
            byte[] num = { 23 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn24O_Click(object sender, EventArgs e)
        {
            byte[] num = { 24 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void Btn25O_Click(object sender, EventArgs e)
        {
            byte[] num = { 25 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
        }
        #endregion
    }

}
