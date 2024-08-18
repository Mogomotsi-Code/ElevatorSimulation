using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation
{
    public class Building
    {
        public List<Elevator> Elevators { get; private set; }
        public int TotalFloors { get; }

        public Building(int totalFloors, int numberOfElevators, int elevatorCapacity)
        {
            TotalFloors = totalFloors;
            Elevators = new List<Elevator>();

            for (int i = 0; i < numberOfElevators; i++)
            {
                Elevators.Add(new Elevator(elevatorCapacity));
            }
        }
    }
}
