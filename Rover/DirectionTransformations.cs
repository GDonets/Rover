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
    public static class DirectionTransformations
    {
        public static readonly Matrix<short> TurnLeft = Matrix<short>.Build.DenseOfArray(new short[,] { { 0, 1 }, { -1, 0 } });
        public static readonly Matrix<short> TurnRight = Matrix<short>.Build.DenseOfArray(new short[,] { { 0, -1 }, { 1, 0 } });
    }
}
