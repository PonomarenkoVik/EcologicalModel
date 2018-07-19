using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcologicalModel
{
    class Prey:Cell,IMovable,IReproducable,IProcessable
    {
        public byte TimeToReproduce { get; set; }
        public bool Processed { get; set; }
        protected static byte InitTimeToReproduce ;
       
        public Prey(Coordinate coord, byte timeToReproduce = 4, char prayImage = 'f'):base(coord, prayImage)
        {
            TimeToReproduce = timeToReproduce;
            InitTimeToReproduce = timeToReproduce;
            Processed = false;
        }

       
#region
        public virtual void Process()
        {
            Processed = true;
            Coordinate newCoord = GetEmptyNeighborCoord(OffSet);
            Coordinate initCoord = (Coordinate)OffSet.Clone();
            if (newCoord != null)
            {
  
                if (TimeToReproduce > 0)
                {
                    TimeToReproduce -= 1;
                }

                MoveTo(initCoord, newCoord);

                if (TimeToReproduce == 0)
                {
                    TimeToReproduce = InitTimeToReproduce;
                    Reproduce(initCoord);
                }
            }
        }

        public virtual void MoveTo(Coordinate initCoord, Coordinate newCoord)
        {
            OffSet = (Coordinate)newCoord.Clone();      
            Ocean1[newCoord] = (Cell)Clone();
            Ocean1[initCoord] = null;
        }

        public virtual void Reproduce(Coordinate initCoord)
        {
            Ocean1.NumBornPrey += 1;            
            Ocean1[initCoord] = new Prey(initCoord);
            Ocean1.NumPreys += 1;
        }
#endregion
   
    }
}
