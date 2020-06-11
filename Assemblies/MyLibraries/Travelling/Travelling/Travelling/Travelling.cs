using System;

namespace Travelling
{
    // klasa nie może nazywać się jak przestrzeń nazw. Kompilator nie bedzie wstanie rozpoznać czy jest to namespace czy klasa.
    // Musi być publiczna
    public class Travel
    {
        public void TravelOnFoot()
        {
            Console.WriteLine("Travel on foot");
        }
    }
}
