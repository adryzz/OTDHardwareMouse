using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTDHardwareMouse.ReportTypes
{
    class MouseReport : IHardwareReport
    {
        public ShortVector2 Delta;

        public const int MAX_BUTTONS = 3;

        public HardwareKey[] Buttons = new HardwareKey[MAX_BUTTONS];
    }
}
