using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model
{
    class Square : Solid, ICalculate, IMove
    {
        private double edgeLengthA;
        private double edgeLengthB;
        private double edgeLengthC;

        public Square(double A, double B, double C)
        {
            this.edgeLengthA = A;
            this.edgeLengthB = B;
            this.edgeLengthC = C;
            this.positionOnAxis = new PositionOnAxis();
        }

        decimal IMove.CalculateDistance(Solid solid)
        {
            return 0;
        }

        decimal ICalculate.CalculateDistance(Solid solid)
        {
            return 0;
        }

        double ICalculate.CalculateVolume()
        {
            return edgeLengthA * edgeLengthB * edgeLengthC;
        }
    }
}
