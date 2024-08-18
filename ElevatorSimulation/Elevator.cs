using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSimulation
{
    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public int PassengerCount { get; private set; }
        public int MaxCapacity { get; }
        public bool IsMoving { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public Elevator(int maxCapacity)
        {
            CurrentFloor = 0; // Start at ground floor
            MaxCapacity = maxCapacity;
            PassengerCount = 0;
            IsMoving = false;
            CurrentDirection = Direction.Stopped;
        }

        public void MoveToFloor(int targetFloor)
        {
            if (targetFloor > CurrentFloor)
            {
                CurrentDirection = Direction.Up;
            }
            else if (targetFloor < CurrentFloor)
            {
                CurrentDirection = Direction.Down;
            }
            else
            {
                CurrentDirection = Direction.Stopped;
                return;
            }

            IsMoving = true;
            // Simulate movement
            Console.WriteLine("Elevator moving.....");
            Thread.Sleep( Math.Abs(CurrentFloor - targetFloor) * 1000); 
            CurrentFloor = targetFloor;
            IsMoving = false;
            CurrentDirection = Direction.Stopped;
        }

        public void LoadPassengers(int count)
        {
            if (PassengerCount + count <= MaxCapacity)
            {
                PassengerCount += count;
            }
            else
            {
                throw new InvalidOperationException("Exceeded maximum passenger capacity.");
            }
        }

        public void UnloadPassengers(int count)
        {
            if (PassengerCount >= count)
            {
                PassengerCount -= count;
            }
            else
            {
                throw new InvalidOperationException("Not enough passengers to unload.");
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Stopped
    }

}
