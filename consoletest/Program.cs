using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using eveposmon.StaticData;

namespace consoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Moons.LoadFromFile(@"..\..\..\data\moonData.xml.gz");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
