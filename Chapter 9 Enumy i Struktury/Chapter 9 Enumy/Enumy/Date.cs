using System;
namespace Chapter_9_Enums_and_Structs
{
    enum Month
    {
        January = 1, Styczen = January, February, Luty = February, July = 7, Lipiec = July
    }
    struct Date
    {
        private int year;
        private Month month;
        private int day;

        public Date(int ccyy, Month mm, int dd)
        {
            this.year = ccyy;
            this.month = mm;
            this.day = dd;
        }

        public override string ToString()
        {
            string date = $"{this.day} of {this.month} {this.year}";
            return date;
        }
    }
}
