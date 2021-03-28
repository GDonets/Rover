using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;
using Rover.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public class Rover : IRover
    {
        private PlateauSize _plateauSize;

        private readonly ISensorArrayService _sensorService;

        public CoordinatePoint? RoverPosition { get; private set; }

        private Vector<short> _roverDirection;
        public Direction RoverDirection => _roverDirection switch
        {
            Vector<short> d when d.Equals(DirectionsTable.North) => Direction.N,
            Vector<short> d when d.Equals(DirectionsTable.South) => Direction.S,
            Vector<short> d when d.Equals(DirectionsTable.West) => Direction.W,
            Vector<short> d when d.Equals(DirectionsTable.East) => Direction.E,
            _ => Direction.Unknown,
        };

        public Rover(ISensorArrayService sensorService)
        {
            _sensorService = sensorService;
        }

        public void Initialize(PlateauSize plateauSize, CoordinatePoint roverPosition, Vector<short> facingDirection)
        {
            _plateauSize = plateauSize;
            RoverPosition = roverPosition;
            _roverDirection = facingDirection;
        }

        public bool TryTurn(char direction)
        {
            switch (direction)
            {
                case 'L':
                    _roverDirection = DirectionTransformations.TurnLeft * _roverDirection;
                    return true;
                case 'R':
                    _roverDirection = DirectionTransformations.TurnRight * _roverDirection;
                    return true;
                default:
                    return false;
            }
        }

        public RoverMovementResult TryMove()
        {
            if (RoverPosition == null)
            {
                throw new InvalidOperationException("Rover is not initialized. Rover coordinates are unknown.");
            }

            var currentPosition = RoverPosition.Value;
            var plannedPosition = new CoordinatePoint
            {
                Latitude = currentPosition.Latitude + _roverDirection[0],
                Longtitude = currentPosition.Longtitude + _roverDirection[1],
            };

            if (_sensorService.ObstacleDetected())
            {
                return RoverMovementResult.CollidesWithOthers;
            }

            if (!IsWithinPlateauBorders(plannedPosition))
            {
                return RoverMovementResult.OutOfOperationsArea;
            };

            RoverPosition = plannedPosition;

            return RoverMovementResult.Success;
        }

        private bool IsWithinPlateauBorders(CoordinatePoint position)
        {
            return position.Latitude > 0
                && position.Latitude <= _plateauSize.ByLatitude
                && position.Longtitude > 0
                && position.Longtitude <= _plateauSize.ByLongtitude;
        }
    }
}
