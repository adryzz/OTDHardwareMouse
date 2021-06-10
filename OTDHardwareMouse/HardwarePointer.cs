using OpenTabletDriver.Plugin.Platform.Pointer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OTDHardwareMouse.ReportTypes;

namespace OTDHardwareMouse
{
    class HardwarePointer : IRelativePointer
    {
        public void Translate(Vector2 delta)
        {
            if (HardwareMouseConnectionTool.Connected)
            {
                MouseReport report = new MouseReport
                {
                    Delta = ShortVector2.FromVector2(delta) 
                };
                HardwareMouseConnectionTool.SendReport(report);
            }
        }
    }
}
