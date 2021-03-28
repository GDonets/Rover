using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.DataModels
{
    public struct PlateauSize
    {
        public PlateauSize(uint byLatitude, uint byLongtitude)
        {
            ByLatitude = byLatitude;
            ByLongtitude = byLongtitude;
        }

        public readonly uint ByLatitude;
        public readonly uint ByLongtitude;
    }
}
