using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public List<Coordinate> Coordinates { get; set; }
    }
}
