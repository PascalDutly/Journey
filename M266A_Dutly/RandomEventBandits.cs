using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace M266A_Dutly // UNFINISHED
{
    public class RandomEventBandits
    {
        public void PrintText()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "It's calm, too calm. A bunch of men on horses ride towards you. This isn't a joke anymore. These people want your money");
            Console.WriteLine("What do you want to do?");
            Console.ResetColor();

            PrintMenu();
            CheckEntry(Convert.ToInt32(Console.ReadLine()));
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Press [1] to shoot with your revolver");
            Console.WriteLine("Press [2] to start a duel");
            Console.WriteLine("Press [3] to give your loot");
        }

        public void CheckEntry(int entry)
        {
            switch (entry)
            {
                case 1:
                    this.Option1();
                    break;
                case 2:
                    this.Option2();
                    break;
                case 3:
                    this.Option3();
                    break;
            }
        }

        public void Option1()
        {
            Console.WriteLine("You take out your revolver and shoot.");
            Random rnd = new Random();
            int outcome = rnd.Next(1, 3);
            switch (outcome)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(
                        "They didn't expect you to be so courageous. They flee in fear. What a bunch of amateurs");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(
                        "It was silly to think that this would have an effect. One of them shoots back and hits one of your people. Nothing can save him now.");
                    Console.ResetColor();
                    People.PersonDies();
                    break;
                default:
                    Console.WriteLine("This message should not appear");
                    break;
            }
        }

        public void Option2()
        {
            Resources resources = new Resources();
            Console.WriteLine(
                "You take all your courage together and ask for a duel, Wild West style. If you win, they leave you alone. However if you lose...");
            Random rnd = new Random();
            int outcome = rnd.Next(1, 3);

            Console.WriteLine("You and your opponent stand across from each other. The time seems to stand still.");
            
            switch (outcome)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You draw first and hit him. He's dead. The other bandits are quite impressed by your skill. They leave you and your people alone now");
                    Console.WriteLine("They ride away but didn't notice that one of their bags fell on the ground. When they're a safe distance away you look into it.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int a = rnd.Next(1, 7);
                    int b = rnd.Next(5, 60);
                    resources.Food += a;
                    resources.Money += b;
                    Console.WriteLine("In the bag is {0} Food and {1} Dollars", a, b);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("He draws first and kills you but your courage is rewarded. They have so much respect that they decide not to rob you");
                    People.PersonDies();
                    break;
            }
            Console.ResetColor();
        }

        public void Option3()
        {
            Resources resources = new Resources();
            Random rnd = new Random();
            Console.WriteLine("You take the safe route. All your loot gets taken away. At least everybody is safe now.");
            if (resources.Food >= 5)
            resources.Food = 5;
            if (resources.Money >= 10)
            resources.Money = 10;
            if (resources.Oxfood >= 5)
                resources.Oxfood = 5;
            Console.WriteLine("They took everything but a few things. You should check your items.");
        }
    }
}