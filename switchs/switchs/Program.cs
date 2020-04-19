using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switchs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetValue(1.5f));
            Flowers narcissus = Flowers.Narcissus;
            Console.WriteLine(GetFlowerPrice(narcissus));

            Console.ReadKey();
        }

        static string GetValue(float x)
        {
            switch (x)
            {
                case 1:
                    return "Jeden";
                case 1.5f:
                    return "Półtora";
                case 2:
                    return "Dwa";
                case 3:
                    return "Trzy";
                case 4:
                    return "Cztery";
                default:
                    return "";
            }
        }

        static double GetFlowerPrice(Flowers flower)
        {
            switch (flower)
            {
                case Flowers.Aloes:
                    return 8.99;
                case Flowers.Narcissus:
                    return 19.50;
                case Flowers.Rose:
                    return 4.19;
                case Flowers.Tulip:
                    return 6.09;
                default:
                    return double.MinValue;
            }
        }

        static string GetFullMonthName(DateTime dt)
        {
            switch (dt.Month) //dt.Month is intiger
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                default:
                    return string.Empty;
            }
        }

        static string GetFullName(Person person)
        {
            string fullName = "";
         
            // Wartosci w switchu muszą byc typu prostego. int char string enum. W ksiązce mowia, ze float i double nie. Wyrzej jest przykład z Float i działa.
            switch (person.Name)
            {
                case "Ola":
                case "Ala":
                case "Olka":
                    fullName = "Aleksandra";
                    break;
            }

            return fullName;
        }
        
        static string CheckPersonSex(Type t)
        {
            const string typeName = "Men"; //wartosc const stała
            string menName = "Men"; // wartości zmiennych sa wyznaczona w trakcie działania programu. Nie zadziała w instrukcji switch.
            string menNameFromMethod = typeof(Men).FullName.ToString();
            Type men = typeof(Men);
            string sex = "";


            switch (t.FullName)
            {
                //Poprawne.
                //case'sy mogą być tylko wartościami const. Literaly i zmienne const, a wartosci w switchu zmienne typu prostego
                case typeName:
                    sex = "Men"; 
                    break;
                case "Women":
                    sex = "Women";
                    break;
                //Niepoprawne.
                //Wartosci 'Men' sie powtarza i zmienne nie są const.
                //case "Men":
                //    break;
                //case menName:
                //    break;
                //case menNameFromMethod:
                //    break;
            }

            return sex;
        }

        enum Flowers
        {
            Rose,
            Tulip,
            Aloes,
            Narcissus
        }

        class Person 
        {
            public string Name;
        }


        class Men : Person
        {

        }

        class Woman : Person
        {

        }
    }
}
