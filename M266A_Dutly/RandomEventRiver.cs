using System;
using System.Runtime.InteropServices;

namespace M266A_Dutly
{
    public class RandomEventRiver
    {
        //This prints the Text in Cyam
        public void PrintText()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("There's a river and there's no way around it.");
            Console.ResetColor();
            this.PrintMenu();
            this.CheckEntry(Convert.ToInt32(Console.ReadLine()));
            
        }
        //This only prints the menu
        private void PrintMenu()
        {
            Console.WriteLine("Press [1] to find a bridge");
            Console.WriteLine("Press [2] to just cross it");
        }
        //This checks what you chose
        private void CheckEntry(int entry)
        {
            switch (entry)
            {
                case 1:
                    this.Option1();
                    break;
                case 2:
                    this.Option2();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
        //This increases your journey by 5 but you can safely cross the river
        private void Option1()
        {
            America.Difficulty += 5;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "You actually found a bridge. However the search took you so long that you didn't manage to reach you goal of 10km.");
            Console.ResetColor();
        }
        //50/50 chance that an ox will die
        private void Option2()
        {
            Console.WriteLine("It is very dangerous to go through here.");

            Random rnd = new Random();
            int chance = rnd.Next(1, 3);

            switch (chance)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(
                        "Through a miracle everybody survived this dangerous journey. But was this really a risk worth taking?");
                    Console.ResetColor();
                    break;
                case 2:
                    Oxen oxen = new Oxen();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("That was a bad idea. One of your oxen couldn't take it anymore");
                    oxen.OxDies();
                    Console.ResetColor();
                    break;
            }
        }
    }
}