using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    interface IProcessable
    {
        void Process();
        bool Processed { get; set; }
    }
}
