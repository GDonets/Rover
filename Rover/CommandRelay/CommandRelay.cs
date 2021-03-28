using Rover.Commands;
using Rover.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.CommandRelay
{
    public class CommandRelay
    {
        private IRover[] _rovers;

        public CommandRelay(IRover[] rovers)
        {
            _rovers = rovers;
        }

        public void InitializeRovers(string initMessage) 
        {
            var sections = initMessage.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var plateauSizeSubsections = sections[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            PlateauSize plateauSize;

            if (uint.TryParse(plateauSizeSubsections[0], out uint byLatitude)
                && uint.TryParse(plateauSizeSubsections[1], out uint byLongtitude))
            {
                plateauSize = new PlateauSize(byLatitude, byLongtitude);
            }
            else
            {
                throw new ArgumentException("Plateau size message is incorrectly formed!");
            }

            if (Math.DivRem(sections.Length - 1, 2, out int roversCount) < 0)
            {
                if (roversCount != _rovers.Length) throw new ArgumentException("Incorrectly formed init command: rovers count does not match!");
            }
            else
            {
                throw new ArgumentException("Incorrectly formed init command: cannot count the rovers");
            }


            var roverCounter = 0;

            for (int i = 1; i < sections.Length; i+=2) 
            {
                var rover = _rovers[roverCounter];
                
                // TODO: Command handlers
            }
        }
    }
}
