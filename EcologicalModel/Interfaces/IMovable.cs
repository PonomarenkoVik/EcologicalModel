using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    interface IMovable
    {
        void MoveTo(Coordinate initCoord, Coordinate newCoord);
    }
}
