namespace SnapAPI
{
    public interface ILocation
    {
        decimal Latitude { get; set; }

        decimal Longitude { get; set; }
    }

    public class Location : ILocation
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}