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
        public Boat(int unitSize, bool isSinkable) : base(unitSize) 
        { 
            IsSinkable = isSinkable;
        }
    }
}
