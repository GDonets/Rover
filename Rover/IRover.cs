using MathNet.Numerics.LinearAlgebra;
using Rover.DataModels;

namespace Rover
{
    public interface IRover
    {
        Direction RoverDirection { get; }
        CoordinatePoint? RoverPosition { get; }

        void Initialize(PlateauSize plateauSize, CoordinatePoint roverPosition, Vector<short> facingDirection);
        RoverMovementResult TryMove();
        bool TryTurn(char direction);
    }
}