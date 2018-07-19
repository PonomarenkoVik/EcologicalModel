using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    class Coordinate:ICloneable
    {
        public Coordinate(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        public byte X { get; set; }
        public byte Y { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
