using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTDHardwareMouse.ReportTypes
{
    class KeyboardReport : IHardwareReport
    {
        public const int MAX_KEYS = 4;

        public HardwareKey[] Keys = new HardwareKey[MAX_KEYS];
    }
}
