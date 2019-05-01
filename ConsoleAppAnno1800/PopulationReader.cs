using System;
using System.Diagnostics;

namespace Anno1800MemoryReader
{
    class PopulationReader
    {
        public static Population ReadPopulation(String processName)
        {
            var population = new Population();

            if (processName.EndsWith(".exe"))
            {
                processName = processName.Remove(processName.Length - 4);
            }

            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
                throw new Exception($"Could not find process with name: {processName}");
            var process = processes[0];

            var baseAddress = MemoryHelper.ReadAddress(process, (long)process.MainModule.BaseAddress + GameAddresses.BaseOffset);

            population.Farmers = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.FarmerOffsets);
            population.Workers = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.WorkerOffsets);
            population.Artisans = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.ArtisanOffsets);
            population.Engineers = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.EngineerOffsets);
            population.Investors = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.InvestorOffsets);

            if(population.Investors > 0 && GameAddresses.Mode == GameAddressMode.NORMAL)
            {
                GameAddresses.Mode = GameAddressMode.LATEGAME;
                population.Investors = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.InvestorOffsets);
            }

            population.Jornaleros = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.JornaleroOffsets);
            population.Obreros = MemoryHelper.ReadIntFromNestedPointer(process, baseAddress, GameAddresses.ObreroOffsets);

            

            return population;
        }
    }
}