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
        public Bus(string regNr, bool hasToilet) : base(regNr, 1) 
        { 
            HasToilet = hasToilet;
        }

        public override string Details()
        {
            return base.ToString() + $" Has toilet={HasToilet}";
        }
    }
}
