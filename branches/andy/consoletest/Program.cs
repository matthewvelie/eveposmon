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
            Towers.LoadFromFile(@"..\..\..\data\invControlTowers.xml.gz");
            Towers.Tower tower = Towers.GetTowerByTypeId(12235);
            Console.WriteLine(tower.Description);
        }
    }
}
