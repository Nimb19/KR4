using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MatrixLibrary.Models;

namespace Interface
{
    public class DGVsParameters
    {
        public double[,] A { get; set; }

        public double[,] R { get; set; }

        public double[] Q { get; set; }

        public DGVsParameters(double[,] a, double[,] r, double[] q)
        {
            A = a;
            R = r;
            Q = q;
        }

        public DGVsParameters() { }
    }
}
