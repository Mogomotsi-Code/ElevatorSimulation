using NUnit.Framework;
using System;

namespace ElevatorSimulation.Tests
{

    [TestFixture]
    public class ElevatorTests
    {
        [Test]
        public void TestElevatorInitialization()
        {
            var elevator = new Elevator(5);
            Assert.AreEqual(0, elevator.CurrentFloor);
            Assert.AreEqual(5, elevator.MaxCapacity);
            Assert.AreEqual(0, elevator.PassengerCount);
            Assert.AreEqual(false, elevator.IsMoving);
        }

        [Test]
        public void TestElevatorLoadPassengers()
        {
            var elevator = new Elevator(5);
            elevator.LoadPassengers(3);
            Assert.AreEqual(3, elevator.PassengerCount);            
            Assert.Throws<InvalidOperationException>(() => elevator.LoadPassengers(10));
        }

        [Test]
        public void TestElevatorMoveToFloor()
        {
            var elevator = new Elevator(5);
            elevator.MoveToFloor(1);
            Assert.AreEqual(1, elevator.CurrentFloor);
            elevator.MoveToFloor(5);
            Assert.AreEqual(5, elevator.CurrentFloor);
        }

        [Test]
        public void TestElevatorUnloadPassengerss()
        {
            var elevator = new Elevator(5);
            elevator.LoadPassengers(3);
            elevator.UnloadPassengers(1);
            Assert.AreEqual(2, elevator.PassengerCount);            
            Assert.Throws<InvalidOperationException>(() => elevator.UnloadPassengers(5));
        }
    }

}