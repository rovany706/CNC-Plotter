using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    class Adapter
    {
        public static string[] UpdatePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }
        public static DialogResult OpenFile(out string path)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Открыть файл";
            openDialog.Filter = "Файл GCode (.gcode)|*.gcode";
            DialogResult result = openDialog.ShowDialog();
            path = openDialog.FileName;
            return result;
        }
    }
}
