using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    internal class Boat : Vehicle
    {
        public bool IsSinkable { get; private set; }
        public Boat(string regNr, bool isSinkable) : base(regNr, 1) 
        {
            //UnitSize = 3;
            IsSinkable = isSinkable;
        }

        public override string Details()
        {
            return base.ToString() + $" Sinkable={IsSinkable}";
        }
    }
}
