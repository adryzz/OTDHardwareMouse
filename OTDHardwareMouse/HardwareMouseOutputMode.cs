using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Platform.Pointer;
using System;

namespace OTDHardwareMouse
{
    [PluginName("Hardware mouse Relative Mode")]
    public class HardwareMouseOutputMode : RelativeOutputMode
    {
        public override IRelativePointer Pointer { get => pointer; set => pointer = value; }

        IRelativePointer pointer = new HardwarePointer();
    }
}
