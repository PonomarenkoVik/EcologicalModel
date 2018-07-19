using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    class Obstacle:Cell
    {
        public Obstacle(Coordinate coord, char obstImage = '#') : base(coord, obstImage)
        {           
        }
    }
}
