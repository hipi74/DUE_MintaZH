
namespace WindowsFormsApp3
{
    public class Termek
    {
        public string Megnevezes { get; set; }

        public int Egysegar { get; set; }

        public decimal Mennyiseg { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1} {2})",
                Megnevezes, Egysegar, Mennyiseg);
        }

    }
}
