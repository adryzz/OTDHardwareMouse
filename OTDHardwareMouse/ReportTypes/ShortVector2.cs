using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OTDHardwareMouse.ReportTypes
{
    public struct ShortVector2
    {
        public short X, Y;

        public static ShortVector2 FromVector2(Vector2 vector)
        {
            return new ShortVector2
            {
                X = Convert.ToInt16(vector.X),
                Y = Convert.ToInt16(vector.Y)
            };
        }
    }
}
