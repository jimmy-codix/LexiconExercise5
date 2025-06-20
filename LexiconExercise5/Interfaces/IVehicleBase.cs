namespace LexiconExercise5.Interfaces
{
    public interface IVehicleBase
    {
        string RegistrationNr { get; }
        int UnitSize { get; }

        string Details();
        string ToString();
    }
}