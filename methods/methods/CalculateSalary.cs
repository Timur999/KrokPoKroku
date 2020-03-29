using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class CalculateSalary
    {
        public static void Start()
        {
            (new CalculateSalary()).run();
        }
        void run()
        {
            double dailyRate = ReadDouble("Enter your daily rate:");
            int noOfDays = ReadInt("Enter the numbers of days:");
            WriteFee(CalculateFee(dailyRate, noOfDays));
        }

        private void WriteFee(double v) => Console.WriteLine($"Your fee is: {v * 0.9}");

        private double CalculateFee(double dailyRate, int noOfDays) => dailyRate * noOfDays;

        private int ReadInt(string v)
        {
            string noOfDays = ReadUserValue(v);
            return Int32.Parse(noOfDays);
        }
        private double ReadDouble(string v)
        {
            var dailyRate = ReadUserValue(v);
            return double.Parse(dailyRate);
        }

        private static string ReadUserValue(string v)
        {
            Console.Write(v);
            return Console.ReadLine();
        }      
    }
}
