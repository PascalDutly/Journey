using System;

namespace M266A_Dutly
{
    public class RandomEventDisease
    {
        //This prints the text
        public void PrintText()
        {
            Console.WriteLine("One of your people has no energy. He's sick");
            this.PrintMenu();
            this.CheckEntry(Convert.ToInt32(Console.ReadLine()));
        }
        //This prints the menu
        private void PrintMenu()
        {
            Console.WriteLine("Press [1] to give him medicine. Chance of surviving: 80%");
            Console.WriteLine("Press [2] to give no medicine. Chance of surviving: 25%");
        }
        //This checks your choosing
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
            }
        }
        //This is the first option. 80% chance of surviving
        private void Option1()
        {
            Random rnd = new Random();
            
            this.CheckIfEnoughResources(1);
            Console.WriteLine("He's thankful for your help.");

            int liveOrDie = rnd.Next(5);
            if (liveOrDie == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("All your efforts were useless. He died anyways");
                Console.ResetColor();
                People.PersonDies();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("He managed to survive thanks to you!");
                Console.ResetColor();
            }
        }
        // 25% chance of surviving If liveOrDie is 1, he survives
        private void Option2()
        {
            Random rnd = new Random();
            int liveOrDie = rnd.Next(4);

            if (liveOrDie == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Through a miracle he managed to survive.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("All hope is lost. He died a painful death.");
                Console.ResetColor();
                People.PersonDies();
            }
        }
        //This only checks if you have enough resources
        private void CheckIfEnoughResources(int requiredMedicine)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Resources resources = new Resources();
            if (requiredMedicine > resources.Medicine)
            {
                Console.WriteLine("You don't have enough Medicine");
                Console.ResetColor();
                PrintText();
            }
            else
            {
                Console.WriteLine("The chance of him surviving increased");
                resources.Medicine = resources.Medicine - requiredMedicine;
            }
            Console.ResetColor();
        }
    }
}