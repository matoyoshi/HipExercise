namespace SnapAPI
{
    public class SnapFactory
    {
        public static ISnapApi Create()
        {
            return new DummySnap();
        }
    }
}