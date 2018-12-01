using System.Collections.Generic;
using BusinessLogic.Entities;

namespace BusinessLogic
{
    public static class Repository
    {
        private static IVehicleRepository m_vehicles = new VehiclesRepository(new List<Vehicle>()
        {
            new Vehicle() { Id = 1, Coordinates = new List<Coordinate>()},
            new Vehicle() { Id = 2, Coordinates = new List<Coordinate>()},
            new Vehicle() { Id = 3, Coordinates = new List<Coordinate>()},
            new Vehicle() { Id = 4, Coordinates = new List<Coordinate>()},
        });

        public static IVehicleRepository GetVehicles()
        {
            return m_vehicles;
        }
    }
}