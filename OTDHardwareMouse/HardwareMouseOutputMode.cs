using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Platform.Pointer;
using System;

namespace OTDHardwareMouse
{
    public class HardwareMouseOutputMode : RelativeOutputMode
    {
        public override IRelativePointer Pointer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
