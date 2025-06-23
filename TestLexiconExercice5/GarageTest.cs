using LexiconExercise5;
using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;
using System.Diagnostics.Metrics;
namespace TestLexiconExercice5
{
    public class GarageTest
    {
        //TODO Fix this
        [Theory]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        public void New_Garage_Test(int capacity, int expected)
        {
            IGarage<VehicleBase> g = new Garage<VehicleBase>(capacity);
            Assert.Equal(g.Count, expected);
        }

        [Fact]
       public void New_Garage_WhenNegative()
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Garage<VehicleBase>(-1));
        }

        [Fact]
        public void Park_Garage_WhenNull()
        {
            IGarage<VehicleBase> g = new Garage<VehicleBase>(10);
            

           Assert.Throws<ArgumentNullException>(() => g.Park(null));
        }

        [Fact]
        public void Depart_Garage_WhenNull()
        {
            IGarage<VehicleBase> g = new Garage<VehicleBase>(10);
            
           Assert.Throws<ArgumentNullException>(() => g.Depart(null));
        }
    }
}
