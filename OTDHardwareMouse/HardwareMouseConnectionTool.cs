using OpenTabletDriver.Plugin;
using OTDHardwareMouse.ReportTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using OpenTabletDriver.Plugin.Attributes;

namespace OTDHardwareMouse
{
    [PluginName("Hardware Mouse connection")]
    class HardwareMouseConnectionTool : ITool
    {
        public static bool Connected { get; private set; } = false;

        [Property("Port"), ToolTip("The serial port that will be used.")]
        public string PortName { get => portName; set => portName = value; }

        static string portName
        {
            get;
            //TODO: re-initialize port on set
            set;
        }

        [Property("Baud rate"), Unit("bps"), ToolTip("The speed of the connection.\nIf unsure, keep at the default."), DefaultPropertyValue(115200)]
        public int BaudRate { get => baudRate; set => baudRate = value; }

        static int baudRate = 115200;

        [Property("List ports in the console"), DefaultPropertyValue(true)]
        public bool ListPortsInConsole { get; set; }

        static SerialPort port;

        public void Dispose()
        {
            port.Dispose();
        }

        public bool Initialize()
        {
            try
            {
                if (ListPortsInConsole)
                {
                    string[] ports = SerialPort.GetPortNames();

                    if (ports.Length > 0)
                    {
                        string message = "Available ports: ";
                        for (int i = 0; i < ports.Length; i++)
                        {
                            message += ports[i] + ", ";
                        }
                        Log.Write("Plugin", message.Remove(message.Length - 3));
                    }
                    else
                    {
                        Log.Write("Plugin", "No available serial ports found.");
                    }
                }

                port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
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

                byte[] X = BitConverter.GetBytes(mouse.Delta.X);
                byte[] Y = BitConverter.GetBytes(mouse.Delta.Y);

                X.CopyTo(packet, 1); //add delta values
                Y.CopyTo(packet, 3);

                byte[] buttons = new byte[MouseReport.MAX_BUTTONS];
                for(int i = 0; i < MouseReport.MAX_BUTTONS; i++)
                {
                    buttons[i] = (byte)mouse.Buttons[i];
                }

                buttons.CopyTo(packet, 5);//add buttons
            }
            else if (report is KeyboardReport keyboard)
            {
                packet[0] = 0x02; //keyboard report

                byte[] keys = new byte[KeyboardReport.MAX_KEYS];
                for (int i = 0; i < KeyboardReport.MAX_KEYS; i++)
                {
                    keys[i] = (byte)keyboard.Keys[i];
                }

                keys.CopyTo(packet, 1);//add keys
            }

            port.Write(packet, 0, packet.Length);
        }
    }
}
