using MathNet.Numerics.LinearAlgebra;
using Rover.DataModels;
using System;

namespace Rover.Commands
{
    public class InitializationCommand : ICommand
    {
        private IRover _rover;
        private (PlateauSize PlateauSize, CoordinatePoint InitialCoordinates, Vector<short> Facing) _initParams;

        public InitializationCommand(IRover rover, PlateauSize plateauSize, string message)
        {
            _rover = rover;
            ParseInitializationMessage(plateauSize, message);
        }

        public CommandResultDto Result { get; private set; }

        public void Execute()
        {
            _rover.Initialize(_initParams.PlateauSize, _initParams.InitialCoordinates, _initParams.Facing);
            Result = new CommandResultDto(CommandResult.Success, string.Empty);
        }

        private void ParseInitializationMessage(string message)
        {
            PlateauSize plateauSize;
            CoordinatePoint coordinates;
            Vector<short> direction = null;

            var roverParams = message.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (uint.TryParse(plateauSizeSubsections[0], out uint byLatitude)
                && uint.TryParse(plateauSizeSubsections[1], out uint byLongtitude))
            {

                plateauSize = new PlateauSize(byLatitude, byLongtitude);
            }
            else
            {
                throw new ArgumentException("Plateau size message is incorrectly formed!");
            }

            if (long.TryParse(roverParams[0], out long roverLatitude)
                && long.TryParse(roverParams[1], out long roverLongtitude))
            {
                coordinates = new CoordinatePoint
                {
                    Latitude = roverLatitude,
                    Longtitude = roverLongtitude,
                };
            }
            else
            {
                throw new ArgumentException("Rover initial coordinates message is incorrectly formed!");
            }

            if (Enum.TryParse(roverParams[2], out Direction dir))
            {
                switch (dir)
                {
                    case Direction.N:
                        direction = DirectionsTable.North;
                        break;
                    case Direction.S:
                        direction = DirectionsTable.South;
                        break;
                    case Direction.W:
                        direction = DirectionsTable.West;
                        break;
                    case Direction.E:
                        direction = DirectionsTable.East;
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Rover direction message is incorrectly formed!");
            }

            _initParams = (plateauSize, coordinates, direction);
        }
    }
}
