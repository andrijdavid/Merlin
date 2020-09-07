using System;
using Merlin.Game;
using Raylib_cs;

namespace Merlin
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Remorseless winter", 1000, 800);
            container.Run();
            
        }
    }
}
