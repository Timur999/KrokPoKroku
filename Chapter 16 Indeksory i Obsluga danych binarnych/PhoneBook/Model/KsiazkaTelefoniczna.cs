using System;

namespace PhoneBook.Model
{
    struct KsiazkaTelefoniczna
    {
        public Osoba[] Osoby;
        public NumerTelefonu[] Numery;

        public Osoba this[NumerTelefonu numerTelefonu]
        {
            get
            {
                int index = Array.IndexOf(Numery, numerTelefonu); // NumerTelefonu i Osoba jest structura dlatego takie wyszukanie jest poprawne.
                if(index != -1)
                {
                    return Osoby[index];
                }

                return new Osoba();
            }
        }

        public NumerTelefonu this[Osoba osoba]
        {
            get
            {
                int index = Array.IndexOf(Osoby, osoba);
                if(index != -1)
                {
                    return Numery[index];
                }

                return new NumerTelefonu();
            }
        }
    }

    struct Osoba
    {
        public string Imie { get; set; }
        public Osoba(string imie) => Imie = imie;
    }

    struct NumerTelefonu
    {
        public int Numer { get; set; }
        public NumerTelefonu(int num) => Numer = num;

        public override string ToString()
        {
            return $"Numeros {this.Numer}";
        }
    }
}
