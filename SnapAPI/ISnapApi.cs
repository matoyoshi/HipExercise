using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnapAPI
{
    public interface ISnapApi
    {
        ILocation GetLocation(IEnumerable<ILocation> locations);
    }
}
