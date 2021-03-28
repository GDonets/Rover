using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public static class DirectionsTable
    {
        public static readonly Vector<short> North = Vector<short>.Build.DenseOfArray(new short[] { 0, 1 });
        public static readonly Vector<short> South = Vector<short>.Build.DenseOfArray(new short[] { 0, -1 });
        public static readonly Vector<short> West = Vector<short>.Build.DenseOfArray(new short[] { -1, 0 });
        public static readonly Vector<short> East = Vector<short>.Build.DenseOfArray(new short[] { 1, 0 });
    }
}
