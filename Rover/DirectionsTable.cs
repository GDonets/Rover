using MathNet.Numerics.LinearAlgebra;
using Rover.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public static class DirectionsTable
    {
        public static Vector<short> North => Vector<short>.Build.DenseOfArray(new short[] { 0, 1 });
        public static Vector<short> South => Vector<short>.Build.DenseOfArray(new short[] { 0, -1 });
        public static Vector<short> West => Vector<short>.Build.DenseOfArray(new short[] { -1, 0 });
        public static Vector<short> East => Vector<short>.Build.DenseOfArray(new short[] { 1, 0 });
    }
}
