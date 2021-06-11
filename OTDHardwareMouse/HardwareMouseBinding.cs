using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTDHardwareMouse
{
    [PluginName("Hardware mouse binding")]
    class HardwareMouseBinding : IBinding
    {
        public void Press(IDeviceReport report)
        {
            throw new NotImplementedException();
        }

        public void Release(IDeviceReport report)
        {
            throw new NotImplementedException();
        }
    }
}
