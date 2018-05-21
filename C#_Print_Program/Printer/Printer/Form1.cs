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
using System.IO;

namespace Printer
{
    public partial class Form1 : Form
    {
        private int x = 0, y = 0, i = 0;
        private bool isConnected = false, streaming = false, isPenUp = false;
        private string[] gcode;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbPorts.DataSource = Adapter.UpdatePorts();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(cbPorts.Items.Count != 0)
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
                    tbAction.Enabled = true;
                    tbCommand.Enabled = true;
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    buttonSend.Enabled = true;
                    toolStripMenuItemOpenFile.Enabled = true;
                    timerRefreshPorts.Enabled = false;
                    tbLog.Clear();
                }
                catch
                {
                    MessageBox.Show("Error while opening port" + serialPort1.PortName, "Error");
                }
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            isConnected = false;
            tbAction.Enabled = false;
            tbCommand.Enabled = false;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonSend.Enabled = false;
            toolStripMenuItemOpenFile.Enabled = false;
            timerRefreshPorts.Enabled = true;
            toolStripConnectionStatus.Text = "Disconnected";
            x = 0;
            y = 0;
        }

        private void tbAction_KeyDown(object sender, KeyEventArgs e)
        {
            if (isConnected)
            {
                if (e.KeyCode == Keys.Right && x < 40)
                    x++;
                else if (e.KeyCode == Keys.Left && x > 0)
                    x--;
                else if (e.KeyCode == Keys.Up && y < 50)
                    y++;
                else if (e.KeyCode == Keys.Down && y > 0)
                    y--;
                serialPort1.WriteLine("G1 X" + x + ".000" + "Y" + y + ".000 Z0.000");
                if (e.KeyCode == Keys.Space)
                {
                    if (isPenUp)
                    {
                        isPenUp = false;
                        serialPort1.WriteLine("D");
                    }
                    else
                    {
                        isPenUp = true;
                        serialPort1.WriteLine("U");
                    }
                }
                tbAction.Clear();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(tbCommand.Text);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isConnected)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
                {
                    if (Adapter.OpenFile(out string path) == DialogResult.OK)
                    {
                        gcode = File.ReadAllLines(path);
                        if (MessageBox.Show("Начать печать?", "Подтверждение", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            i = 0;
                            streaming = true;
                            buttonsStop.Enabled = true;
                            printFile();
                        }
                    }
                }

                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
                {
                    x = 0;
                    y = 0;
                    serialPort1.WriteLine("G1 X" + x + ".000" + "Y" + y + ".000 Z0.000");
                }
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void timerRefreshPorts_Tick(object sender, EventArgs e)
        {
            cbPorts.SelectedIndex = -1;
            cbPorts.DataSource = Adapter.UpdatePorts();
        }

        private void buttonsStop_Click(object sender, EventArgs e)
        {
            streaming = false;
            x = 0;
            y = 0;
            serialPort1.WriteLine("U");
            serialPort1.WriteLine("G1 X" + x + ".000" + "Y" + y + ".000 Z0.000");
            buttonsStop.Enabled = false;
            MessageBox.Show("Печать прервана!");
        }

        private void toolStripMenuItemOpenFile_Click(object sender, EventArgs e)
        {
            if (Adapter.OpenFile(out string path) == DialogResult.OK)
            {
                gcode = File.ReadAllLines(path);
                if (MessageBox.Show("Начать печать?", "Подтверждение", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    i = 0;
                    streaming = true;
                    buttonsStop.Enabled = true;
                    printFile();
                }
            }
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serialPort1.WriteLine(tbCommand.Text.Trim().ToUpper());
                tbCommand.Clear();
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string r = serialPort1.ReadLine();
            tbLog.AppendText(r + '\n');
            if (r.StartsWith("ok"))
                printFile();
            if (r.StartsWith("error"))
                printFile();
        }

        private void printFile()
        {
            if (!streaming)
                return;
            while (true)
            {
                if (i == gcode.Length)
                {
                    streaming = false;
                    buttonsStop.Enabled = false;
                    MessageBox.Show("Печать завершена!");
                    return;
                }
                if (gcode[i].Trim().Length == 0)
                {
                    i++;
                }
                else break;
            }
            serialPort1.WriteLine(gcode[i]);
            i++;
        }
    }
}
