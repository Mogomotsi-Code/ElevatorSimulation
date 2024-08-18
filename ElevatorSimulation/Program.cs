using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var building = new Building(totalFloors: 10, numberOfElevators: 3, elevatorCapacity: 10);
            var controller = new ElevatorController(building);

            while (true)
            {
                Console.WriteLine("Enter floor number to request an elevator (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit") break;

                if (int.TryParse(input, out int floor))
                {
                    Console.WriteLine("Enter number of passengers:");
                    if (int.TryParse(Console.ReadLine(), out int passengers))
                    {
                        var request = new Request(floor, passengers);
                        controller.DispatchElevator(request);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of passengers.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid floor number.");
                }
            }
        }
    }
}
