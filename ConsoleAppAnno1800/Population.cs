namespace Anno1800MemoryReader
{
    public class Population
    {
        public int Farmers;
        public int Workers;
        public int Artisans;
        public int Engineers;
        public int Investors;

        public int Jornaleros;
        public int Obreros;

        public override string ToString()
        {
            return "Farmers: " + this.Farmers.ToString() +
                    ", Workers: " + this.Workers.ToString() +
                    ", Artisans: " + this.Artisans.ToString() +
                    ", Engineers: " + this.Engineers.ToString() +
                    ", Investors: " + this.Investors.ToString() +
                    ", Jornaleros: " + this.Jornaleros.ToString() +
                    ", Obreros: " + this.Obreros.ToString();
        }
    }
}