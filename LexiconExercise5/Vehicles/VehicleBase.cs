﻿using LexiconExercise5.Interfaces;

namespace LexiconExercise5.Vehicles
{
    //TODO move this out
    enum VehicleType
    {
        Airplane,
        Boat,
        Bus,
        Car,
        Motorcycle
    }
    public abstract class VehicleBase : IVehicleBase
    {
        //TODO may be readonly?
        //TODO unitsize is always 1. At this moment it will be 1 until i extend it.
        public int UnitSize { get; private set; } = 1;
        public string RegistrationNr { get; private set; }

        public VehicleBase(string registrationNr, int unitSize) 
        { 
            UnitSize = unitSize;
            if (registrationNr.Length < 1 || registrationNr.Length > 6)
                throw new ArgumentException("Registration number needs to be between 1 and 6 characters long.");

            RegistrationNr = registrationNr;
        }

        public override string ToString()
        { 
            return this.GetType().Name + " Reg=" + this.RegistrationNr;
        }

        public abstract string Details();

    }
}