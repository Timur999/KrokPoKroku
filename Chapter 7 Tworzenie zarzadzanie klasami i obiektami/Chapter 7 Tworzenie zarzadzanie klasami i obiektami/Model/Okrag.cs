using System;
namespace Classies.Model
{
    class Okrag
    {
        private float promien = 0f;

        // Konstruktor domyślny
        public Okrag(){ }

        // Konstruktor przeciążony. Kolejność konstruktorów zależy od developera.
        public Okrag(float _promien)
        {
            promien = _promien;
        }

        public double ObliczObwod()
        {
            return promien * 3.14f;
        }
    }
}
