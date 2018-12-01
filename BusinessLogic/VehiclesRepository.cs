using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using SnapAPI;

namespace BusinessLogic
{
    class VehiclesRepository : IVehicleRepository
    {
        private readonly Dictionary<int, Vehicle> m_vehicles;

        private readonly ISnapApi m_snapApi; 
        public VehiclesRepository(List<Vehicle> initData)
        {
            m_vehicles = initData.ToDictionary(t => t.Id);

            m_snapApi = SnapFactory.Create();
        }

        public void UpdateLocation(int vehicleId, Coordinate coordinate)
        {
            Vehicle v;
            if (m_vehicles.TryGetValue(vehicleId, out v))
            {
                 v.Coordinates.Add(coordinate);
            }
        }

        public Coordinate GetVehicleLocation(int vehicleId)
        {
            if (m_vehicles.TryGetValue(vehicleId, out var v))
            {
                //use the dummy snapApi. convert BL data to required data by snapAPI (could be rest, dll, etc).
                var location = m_snapApi.GetLocation(v.Coordinates.
                    Select(c => new Location() {Latitude = c.Latitude, Longitude = c.Longitude}));
                if (location != null)
                {
                    //back to BL Data.
                    return new Coordinate() { Latitude = location.Latitude, Longitude = location.Longitude };
                }
            }

            return null;
        }
    }
}
