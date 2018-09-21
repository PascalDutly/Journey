using System;
using System.Runtime.Remoting.Channels;

namespace M266A_Dutly
{
    public class RandomEventStarvingPerson
    {
        //This method prints a text
        public void PrintText()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "In the distance you see something. You can't believe it. it's another lost soul in this endless desert. He's skinny to the bones and he needs help immediately");
            Console.ResetColor();

            this.PrintMenu();
            this.CheckEntry(Convert.ToInt32(Console.ReadLine()));
        }
        //You can choose what to do
        public void PrintMenu()
        {
            Console.WriteLine("Press [1] to give him 1 Medicine and 5 Food");
            Console.WriteLine("Press [2] to ignore him");
            Console.WriteLine("Press [3] to put him out of his misery (Shoot him)");
        }
        //Depending on what you choose you get a different outcome
        public void CheckEntry(int entry)
        {
            switch (entry)
            {
                case 1:
                    Option1();
                    break;
                case 2:
                    Option2();
                    break;
                case 3:
                    Option3();
                    break;
            }
        }
        //Your Food gets taken away but you have a new member
        public void Option1()
        {
            Resources resources = new Resources();

            this.CheckIfEnoughItems(1, 5);

            
        }
        //Nothing really happens
        public void Option2()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("It could be a bandit so you decide not to go near him");
            Console.ResetColor();
        }
        //You get a little money
        private void Option3()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Resources resources = new Resources();
            Random rnd = new Random();
            Console.WriteLine("It's probably best to just put him down.");
            int loot = rnd.Next(3, 11);

            resources.Money += loot;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You got {0} Dollars, but was it really worth it?", loot);
            Console.ResetColor();
        }
        //Checks if you have enough items
        private void CheckIfEnoughItems(int medicineRequired, int foodRequired)
        {
            Resources resources = new Resources();
            if (medicineRequired > resources.Medicine || foodRequired > resources.Food)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You don't have enough items");
                Console.ResetColor();
                this.PrintText();
            }
            else
            {
                resources.Medicine -= medicineRequired;
                resources.Food -= foodRequired;
                People.PersonCount++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(
                    "He is grateful for your kindness. He asks if he could help you on your journey. You can't leave him in the desert so you take him with you.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Now {0} People are part of your party", People.PersonCount);
                Console.ResetColor();
            }
        }
    }
}