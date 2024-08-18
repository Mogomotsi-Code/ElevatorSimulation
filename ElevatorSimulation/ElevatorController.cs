using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation
{
    public class ElevatorController
    {
        private readonly Building _building;

        public ElevatorController(Building building)
        {
            _building = building;
        }

        public void DispatchElevator(Request request)
        {
            Elevator bestElevator = null;
            int minimumDistance = int.MaxValue;

            foreach (var elevator in _building.Elevators)
            {
                if (elevator.PassengerCount + request.Passengers <= elevator.MaxCapacity)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - request.Floor);

                    if (distance < minimumDistance)
                    {
                        bestElevator = elevator;
                        minimumDistance = distance;
                    }
                }
            }

            if (bestElevator != null)
            {
                bestElevator.MoveToFloor(request.Floor);
                bestElevator.LoadPassengers(request.Passengers);
                Console.WriteLine($"Elevator moved to floor {request.Floor} and picked up {request.Passengers} passengers.");
            }
            else
            {
                Console.WriteLine("No elevator available to handle the request.");
            }
        }
    }

}
