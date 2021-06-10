using OpenTabletDriver.Plugin;
using OTDHardwareMouse.ReportTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace OTDHardwareMouse
{
    class HardwareMouseConnectionTool : ITool
    {
        public static bool Connected { get; private set; } = false;

        public string PortName => portName;

        static string portName
        {
            get;
            //TODO: re-initialize port on set
            set;
        }

        static SerialPort port;

        public void Dispose()
        {
            port.Dispose();
        }

        public bool Initialize()
        {
            try
            {
                port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
                port.Open();
                Connected = true;
                return true;
            }
            catch
            {
                port = null;
            }

            return false;
        }

        public static void SendReport(IHardwareReport report)
        {
            byte[] packet = new byte[8];
            if (report is MouseReport mouse)
            {
                packet[0] = 0x01; //mouse report
            }
            else if (report is KeyboardReport keyboard)
            {
                packet[0] = 0x02; //keyboard report
            }

            port.Write(packet, 0, packet.Length);
        }
    }
}
