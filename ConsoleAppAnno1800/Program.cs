using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Anno1800MemoryReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string process = "Anno1800.exe";
            Population pop = PopulationReader.ReadPopulation(process);

            GithubCalculatorFirefox calc = new GithubCalculatorFirefox();

            while(true)
            {
                pop = PopulationReader.ReadPopulation(process);
                Console.WriteLine(pop.ToString());
                calc.Calculate(pop);

                Thread.Sleep(10000);
            }


        }
    }
}
