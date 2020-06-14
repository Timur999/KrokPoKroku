
namespace Classies.Model
{
    class Circle
    {
        // Aby uzywać zmiennych satycznych lub metod nie trzeba tworzyć instancji danej klasy.
        public static int CircleAmount;

        // const również jest polem statycznym. Polami const mogą być wyłącznie zmienne niereferencyjne t.j. (liczbowe(int, float, ..), string, typy wyliczeniowe (enum)) 
        public const double PI = 3.1415;

        public Circle()
        {
            CircleAmount++;
        }

        // o zmiennych statycznych można powiedzieć, że są to metody klas. O polach statycznych mowimy poprosty pole/zmienna statycznych.
        public static int GetCircleAmount()
        {
            return CircleAmount;
        }
    }
}
