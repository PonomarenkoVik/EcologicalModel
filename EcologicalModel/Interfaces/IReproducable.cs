using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    interface IReproducable
    {
        byte TimeToReproduce { get; set; }
        void Reproduce(Coordinate initCoord);
    }
}
