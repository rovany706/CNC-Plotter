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
        private bool isConnected = false;
        private string[] gcode;
        private bool streaming = false;
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
            x = 0;
            y = 0;
        }

        private void buttonPrintFile_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (OpenFile(ref path) == DialogResult.OK)
            {
                gcode = File.ReadAllLines(path);
                if (MessageBox.Show("Начать печать?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    i = 0;
                    streaming = true;
                    printFile();
                }
            }
        }

        private DialogResult OpenFile(ref string path)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Открыть файл";
            openDialog.Filter = "Файл GCode (.gcode)|*.gcode";
            DialogResult result = openDialog.ShowDialog();
            path = openDialog.FileName;
            return result;
        }

        private void tbAction_KeyDown(object sender, KeyEventArgs e)
        {
            if (isConnected)
            {
                if (e.KeyCode == Keys.Left && x < 40)
                    x++;
                else if (e.KeyCode == Keys.Right && x > 0)
                    x--;
                else if (e.KeyCode == Keys.Up && y < 50)
                    y++;
                else if (e.KeyCode == Keys.Down && y > 0)
                    y--;
                serialPort1.Write("G1 X" + x + ".000" + "Y" + y + ".000 Z0.000\n");
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
                    string path = string.Empty;
                    if (OpenFile(ref path) == DialogResult.OK)
                    {
                        gcode = File.ReadAllLines(path);
                        if (MessageBox.Show("Начать печать?", "Подтверждение", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            i = 0;
                            streaming = true;
                            printFile();
                        }
                    }
                }

                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
                {
                    x = 0;
                    y = 0;
                    serialPort1.Write("G1 X" + x + ".000" + "Y" + y + ".000 Z0.000\n");
                }
            }
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {

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
