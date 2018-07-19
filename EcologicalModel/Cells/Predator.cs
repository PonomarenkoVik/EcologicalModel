using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    class Predator:Prey
    {
        public Predator(Coordinate coord, char predImage = 'S', byte timeToFeed = 12):base(coord, prayImage:predImage)
        {
            _timeToFeed = timeToFeed;
            _initTimeToFeed = timeToFeed;
        }

        public override void Process()
        {
            Processed = true;
            if (_timeToFeed == 0)
            {
                Ocean1[OffSet] = null;
                Ocean1.NumPredators -= 1;
            }
            else
            {

                Coordinate foodCoord = GetPreyNeighborCoord(OffSet);
                Coordinate initCoord = (Coordinate)OffSet.Clone();
                if (foodCoord != null)
                {
                    Ocean1.NumEaten += 1;
                    _timeToFeed = _initTimeToFeed;
                    MoveTo(initCoord, foodCoord);
                    Ocean1.NumPreys -= 1;
                    if (TimeToReproduce == 0)
                    {
                        Reproduce(initCoord);
                    }
                }
                else
                {
                    Coordinate newCoord = GetEmptyNeighborCoord(OffSet);
                    _timeToFeed -= 1;
                    if (newCoord != null)
                    {
                        TimeToReproduce -= 1;
                        MoveTo(initCoord, newCoord);
                        if (TimeToReproduce == 0)
                        {
                            Reproduce(initCoord);
                        }
                    }
                }          
            }
        }
        public override void Reproduce(Coordinate initCoord)
        {
            Ocean1.NumBornPredators += 1;
            TimeToReproduce = InitTimeToReproduce;
            Ocean1[initCoord] = new Predator(initCoord);
            Ocean1.NumPredators += 1;
        }

        private static byte _initTimeToFeed;
        private byte _timeToFeed;
    }
}
