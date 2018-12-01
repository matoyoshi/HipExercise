using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using SnapAPI;

namespace BusinessLogic
{
    public interface IVehicleRepository
    {
        void UpdateLocation(int vehicleId, Coordinate coordinate);
        Coordinate GetVehicleLocation(int vehicleId);
    }
}
