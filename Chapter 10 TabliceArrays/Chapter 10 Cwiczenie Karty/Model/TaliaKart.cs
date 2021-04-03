using System;

namespace Chapter_10_Cwiczenie_Karty.Model
{
    class TaliaKart
    {
        public Karta[] karty;
        private Random random;
        private int index;

        public TaliaKart()
        {
            this.karty = UtworzTallie();
            this.random = new Random();
            this.index = 0;
        }

        private Karta[] UtworzTallie()
        {
            int j = 0;
            Kolor kolorKarty = Kolor.Caro;
            string[] nazwyKarty = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Walet", "Dama", "Krol", "As" };
            Karta[] tallia = new Karta[52];
            for (int i = 0; i < 52; i++)
            {
                if (j > 12)
                {
                    j = 0;
                    kolorKarty++;
                }

                tallia[i] = new Karta(kolorKarty, nazwyKarty[j]);
                j++;
            }

            return tallia;
        }

        public Karta[,] RozdajKarty()
        {
            Karta[,] rozdaneKarty = new Karta[4, 13];

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    rozdaneKarty[j, i] = PobierzKarte();
                }
            }

            return rozdaneKarty;
        }

        private Karta PobierzKarte()
        {
            this.index = this.random.Next() % 52;

            while(karty[index].nazwa == null)
            {
                this.index = this.random.Next() % 52;
            }

            Karta karta = karty[index];
            UsunKarte(this.index);
            return karta;
        }

        private void UsunKarte(int index)
        {
            karty[index] = new Karta();
        }
    }
}
