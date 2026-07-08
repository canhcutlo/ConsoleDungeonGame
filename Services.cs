using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    static class GameHelper
    {
        private static Random random = new Random();

        //Method crithit
        public static int CalculateDamage(int baseDamage, out bool isCrit)
        {
            int chance = random.Next(1, 101);
            if (chance <= 20) // 20% chance for critical hit
            {
                isCrit = true;
                return baseDamage * 2; // Double damage for critical hit
            }
            else
            {
                isCrit = false;
                return baseDamage;
            }
        }

        //Method to print colour crithit
        public static void PrintColor(String message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
