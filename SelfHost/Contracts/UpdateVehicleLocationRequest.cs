using SelfHost.Models;

namespace SelfHost.Contracts
{
    public class UpdateVehicleLocationRequest
    {
        public int VehicleId { get; set; }

        public LocationModel Location { get; set; }
    }
}