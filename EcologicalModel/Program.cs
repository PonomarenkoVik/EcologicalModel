using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EcologicalModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell.Initialize();
            int numberIteration = UI.GetNumberIteration();
            for (int i = 0; i < numberIteration; i++)
            {
                UI.Display(Cell.GetOcean(), i);
                Cell.Step();
            }
        }
    }
}
