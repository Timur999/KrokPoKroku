
namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model
{
    struct PozycjaNaOsi
    {
        public int positionOnAxisX { get; set; }
        public int positionOnAxisY { get; set; }
        public int positionOnAxisZ { get; set; }

        public PozycjaNaOsi(int pozycjaX, int pozycjaY, int pozycjaZ)
        {
            positionOnAxisX = pozycjaX;
            positionOnAxisY = pozycjaY;
            positionOnAxisZ = pozycjaZ;
        }
    }
}
