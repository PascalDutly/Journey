using System;
using System.Runtime.CompilerServices;

namespace M266A_Dutly
{
    public class RandomEventAbandonedWagon
    {
        public static void PrintText()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your bored eyes look around this empty desert, when suddenly you see a wagon. There seems to be no one left. " +
                              "Maybe there could be some loot.");
            
            Console.ResetColor();
            Result();
        }
        //This gives you a random number of food and oxfood
        public static void Result()
        {
            Resources resources = new Resources();
            Random rnd = new Random();
            int a = rnd.Next(1, 8);
            int b = rnd.Next(1, 6);
            resources.Food += a;
            resources.Oxfood += b;

            Console.WriteLine("You found {0} food and {1} oxfood.", a, b);
        }
        
        //This code would've drawn a wagon. The end result however looked like nothing so i scrapped the idea. The concept only works with simple drawings.
        //IMPORTANT: If it can't find the right file try changing the path or comment this method out. It's not important anyways
        //This code doesn't work properly! I'm gonna leave it there but commented out.
        /*public static void DrawAbandonedWagon()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\AbandonedWagon.txt");
            Console.Write(text);
            Console.WriteLine();
        }*/
    }
}