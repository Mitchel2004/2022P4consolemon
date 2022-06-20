using System;
using System.IO;
using ConsoleMonsters.Loaders;
using ConsoleMonsters.Tools;

namespace ConsoleMon
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMonFactory factory = new ConsoleMonFactory();
            factory.Load();

            ConsoleMon a = factory.Make("EnterMon");
            ConsoleMon b = factory.Make("NewLineMon");

            ConsoleMonArena arena = new ConsoleMonArena();
            arena.DoBattle(a, b);
        }
    }
}
