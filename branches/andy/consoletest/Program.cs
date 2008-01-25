using System;
using System.Collections.Generic;
using System.Text;

using eveposmon.StaticData;

namespace consoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            TowerResources.LoadFromFile(@"..\..\..\data\controlTowerResources.xml.gz");
        }
    }
}
