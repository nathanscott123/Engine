using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Systems
{
    public class Debugger
    {
        public Debugger(Game game)
        {
           
            Console.Title = game.GetTitle();

        }

        public static void NewLine()
        {
            Console.WriteLine(" ");
        }
        public static void Print(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ENGINE: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
        }
      
    }
}
