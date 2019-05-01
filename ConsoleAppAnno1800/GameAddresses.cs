namespace Anno1800MemoryReader
{
    public enum GameAddressMode {NORMAL, LATEGAME }
    class GameAddresses
    {
        //public const long BaseOffset = 0x04EF47D8; //before april 25 patch

        private static GameAddressMode mode = GameAddressMode.NORMAL;

        public static GameAddressMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                if (mode == GameAddressMode.LATEGAME)
                {
                    FarmerOffsets = new int[] { 64, 8, 4 };
                    WorkerOffsets = new int[] { 64, 8, 12 };
                    ArtisanOffsets = new int[] { 64, 8, 20 };
                    EngineerOffsets = new int[] { 64, 8, 28 };
                    InvestorOffsets = new int[] { 64, 8, 36 };

                    JornaleroOffsets = new int[] { 64, 8, 44 };
                    ObreroOffsets = new int[] { 64, 8, 52 };
                }
                else //Early game has different offsets
                {
                    FarmerOffsets = new int[] { 64, 8, 4 };
                    WorkerOffsets = new int[] { 64, 8, 12 };
                    ArtisanOffsets = new int[] { 64, 8, 20 };
                    EngineerOffsets = new int[] { 64, 8, 28 };
                    InvestorOffsets = new int[] { 64, 8, 52 };

                    JornaleroOffsets = new int[] { 64, 8, 36 };
                    ObreroOffsets = new int[] { 64, 8, 44 };
                }
            }

        }


        public const long BaseOffset = 0x04EF7778;



        public static int[] FarmerOffsets = { 64, 8, 4 };
        public static int[] WorkerOffsets = { 64, 8, 12 };
        public static int[] ArtisanOffsets = { 64, 8, 20 };
        public static int[] EngineerOffsets = { 64, 8, 28 };
        public static int[] InvestorOffsets = { 64, 8, 52 };

        public static int[] JornaleroOffsets = { 64, 8, 36 };
        public static int[] ObreroOffsets = { 64, 8, 44 };

        
    }
}