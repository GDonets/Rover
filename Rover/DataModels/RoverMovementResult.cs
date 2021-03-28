using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.DataModels
{
    public enum RoverMovementResult
    {
        None = 0,
        Success = 1,
        OutOfOperationsArea = 2,
        CollidesWithOthers = 3
    }
}
