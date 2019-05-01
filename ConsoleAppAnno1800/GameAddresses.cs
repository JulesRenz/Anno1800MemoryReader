namespace Anno1800MemoryReader
{
    class GameAddresses
    {
        //public const long BaseOffset = 0x04EF47D8;
        public const long BaseOffset = 0x04EF7778;

        public static readonly int[] FarmerOffsets = { 64, 8, 4 };
        public static readonly int[] WorkerOffsets = { 64, 8, 12 };
        public static readonly int[] ArtisanOffsets = { 64, 8, 20 };
        public static readonly int[] EngineerOffsets = { 64, 8, 28 };
        public static readonly int[] InvestorOffsets = { 64, 8, 52 };

        public static readonly int[] JornaleroOffsets = { 64, 8, 36 };
        public static readonly int[] ObreroOffsets = { 64, 8, 44 };
        
    }
}