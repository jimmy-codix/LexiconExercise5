using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    internal class Bus : Vehicle
    {
        public bool HasToilet { get; private set; }
        public Bus(int unitSize, bool hasToilet) : base(unitSize) 
        { 
            HasToilet = hasToilet;
        }
    }
}
