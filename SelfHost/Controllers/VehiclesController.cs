using System.Web.Http;
using BusinessLogic;
using BusinessLogic.Entities;
using SelfHost.Contracts;
using SelfHost.Models;

namespace SelfHost.Controllers
{
    public class VehiclesController : ApiController
    {

        [Route("api/vehicles/getLocation")]
        public IHttpActionResult GetVehicleLocation(int id)
        {
            var vehiclesRepository = Repository.GetVehicles();
            var location = vehiclesRepository.GetVehicleLocation(id);
            if (location != null)
            {
                return Ok(new LocationModel()
                {
                    Lattitude = (double)location.Latitude,
                    Longitude = (double)location.Longitude
                });
            }
            else
            {
                return BadRequest("Vehicle not exists or has no coordinates.");
            }
        }

        [Route("api/vehicles/updateVehicleLocation")]
        [HttpPost]
        public IHttpActionResult UpdateVehicleLocation(UpdateVehicleLocationRequest addeVehicleLocationRequest)
        {
            var vehiclesRepository = Repository.GetVehicles();
            vehiclesRepository.UpdateLocation(addeVehicleLocationRequest.VehicleId, new Coordinate()
            {
                Longitude = (decimal)addeVehicleLocationRequest.Location.Longitude,
                Latitude = (decimal)addeVehicleLocationRequest.Location.Lattitude,
            });
        
            return Ok();
        }
    }
}
