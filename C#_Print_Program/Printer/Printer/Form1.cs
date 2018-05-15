using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Printer
{
    public partial class Form1 : Form
    {
        private int x = 0, y = 0;
        private bool isConnected = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cbPorts.DataSource = ports;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = cbPorts.SelectedItem.ToString();
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.ReadTimeout = 1000;
            serialPort1.WriteTimeout = 1000;

            try
            {
                serialPort1.Open();
                isConnected = true;
                toolStripConnectionStatus.Text = "Connected";
                timer1.Enabled = true;
                tbAction.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error while opening port" + serialPort1.PortName, "Error");
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            isConnected = false;
            tbAction.Enabled = false;
            toolStripConnectionStatus.Text = "Disconnected";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.BytesToRead > 0)
            {
                string r = serialPort1.ReadLine();
                tbLog.AppendText(r + '\n');
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (isConnected)
            {
                if (e.KeyCode == Keys.Left && x < 40)
                    x++;
                else if (e.KeyCode == Keys.Right && x > 0)
                    x--;
                else if (e.KeyCode == Keys.Up && y < 40)
                    y++;
                else if (e.KeyCode == Keys.Down && y > 0)
                    y--;
                serialPort1.Write("G1 X" + x + ".000" + "Y" + y + ".000 Z0.000\n");
            }
        }
    }
}
