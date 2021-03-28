using Rover.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public interface ISensorArrayService
    {
        public bool ObstacleDetected();
    }
}
