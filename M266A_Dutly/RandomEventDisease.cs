using System;

namespace M266A_Dutly
{
    public class RandomEventDisease
    {
        public void PrintText()
        {
            Console.WriteLine("One of your people has no energy. He's sick");
            this.PrintMenu();
            this.CheckEntry(Convert.ToInt32(Console.ReadLine()));
        }

        private void PrintMenu()
        {
            Console.WriteLine("Press [1] to give him medicine. Chance of surviving: 80%");
            Console.WriteLine("Press [2] to give no medicine. Chance of surviving: 25%");
        }

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

        private void CheckIfEnoughResources(int requiredMedicine)
        {
            Resources resources = new Resources();
            if (requiredMedicine > resources.Medicine)
            {
                Console.WriteLine("You don't have enough Medicine");
                PrintText();
            }
            else
            {
                Console.WriteLine("The chance of him surviving increased");
                resources.Medicine = resources.Medicine - requiredMedicine;
            }
            
        }
    }
}