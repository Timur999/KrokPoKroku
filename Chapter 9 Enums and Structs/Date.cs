using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_9_Enums_and_Structs
{
    enum Month
    {
        January = 1, Styczen = January, February, Luty = February, July = 7, Lipiec = July
    }
    class Date
    {
        private int year;
        private Month month;
        private int day;

        public Date(int ccyy, Month mm, int dd)
        {
            this.year = ccyy - 1900;
            this.month = mm - 1;
            this.day = dd - 1;
        }

        public override string ToString()
        {
            string date = $"{this.day + 1} of {this.month + 1} {this.year + 1900}";
            return date;
        }
    }
}
