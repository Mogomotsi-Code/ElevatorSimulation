using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Tests
{
    [TestFixture]
    public class ElevatorControllerTests
    {
        [Test]
        public void TestElevatorInitialization()
        {
            var building = new Building(totalFloors: 10, numberOfElevators: 3, elevatorCapacity: 10);
            var controller = new ElevatorController(building);
            var request = new Request(2, 3);
            controller.DispatchElevator(request);
            Assert.AreEqual(true, building.Elevators.Any(elevator => elevator.CurrentFloor.Equals(2)));
        }
    }
}
