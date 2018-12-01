using System.Collections.Generic;
using System.Linq;

namespace SnapAPI
{
    class DummySnap : ISnapApi
    {
        public ILocation GetLocation(IEnumerable<ILocation> locations)
        {
            if (locations.Any())
            {
                return locations.Last();
            }
            return null;
            
        }
    }
}