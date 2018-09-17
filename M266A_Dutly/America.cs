using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace M266A_Dutly
{
   
    public class America
    {
        private static int difficulty;
        
        //This happens every new round
        public void Start()
        {
            PrintMenu();
            this.CheckEntry(Convert.ToInt32(Console.ReadLine()));
            this.RandomEvent();
            RandomVillageEncounter randomVillageEncounter = new RandomVillageEncounter();
            randomVillageEncounter.RandomChanceVillageEncounter();
            DrawPictures.PrintNight();
            this.Progress();
            this.CheckIfGameIsOver();
        }
        //Your Progress
        public void Progress()
        {
            difficulty = difficulty - 10;
            Console.WriteLine("There are only {0} km left", difficulty);
        }
        //The game will progress 10 km per round (How many rounds = difficulty / 10)
        public static void SetDifficulty()
        {
            Console.WriteLine("Choose your difficulty! 50 is easy, 500 is hard");
            difficulty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your journey will be {0} Kilometers long", difficulty);
        }
        //The menu gets printed
        public static void PrintMenu()
        {
            Console.WriteLine("Press [1] to hunt for food in the wild");
            Console.WriteLine("Press [2] to gather food for your oxen in the wild");
            Console.WriteLine("Press [3] to see your items");
            Console.WriteLine("Press [0] to end the game");
        }
        //The Player can choose what to do
        public void CheckEntry(int entry)
        {
            Resources resources = new Resources();
            
            switch (entry)
            {
                case 1:
                    resources.HuntFood();
                    break;
                case 2:
                    resources.HuntOxenFood();
                    break;
                case 3:
                    resources.ItemStatus();
                    this.Start();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid");
                    Start();
                    break;
            }
            resources.GiveFood();
        }
        //After the player chose what to do, a random event happens
        public void RandomEvent()
        {
            //Console.ForegroundColor = ConsoleColor.Blue;
            
            Random rnd = new Random();
            int random = rnd.Next(1, 4);
            
            switch (random)
            {
                case 1:
                    RandomEventBandits.PrintText();
                    break;
                case 2:
                    RandomEventAbandonedWagon.PrintText();
                    break;
                case 3:
                    Console.WriteLine("Today is a calm day. Nothing special seems to happen. Consider yourself lucky. Not every day goes so well");
                    break;
            }
            Console.WriteLine("Press 'Enter' to sleep");
            Console.ReadLine();
            Console.ResetColor();
        }
        //Every round the game checks if the game is over
        public void CheckIfGameIsOver()
        {
            if (Oxen.AllOxenDead == true)
            {
                Console.WriteLine("All of your oxen died. You're left in the middle of nowhere. Your journey ends here. Game Over");
            }

            if (People.AllPersonsDead == true)
            {
                Console.WriteLine("Every person died. Game Over");
            }

            if (difficulty <= 0)
            {
                Console.WriteLine("You win");
                this.Rating();
            }
            else
            {
                this.Start();
            }
        }
        
        //This is a rating system. Every oxen gives you 1000 points and every person gives you 3000 points
        //You can see below how many points you need
        public void Rating()
        {
            int rating = Oxen.OxCount * 1000 + People.PersonCount * 3000;
            if (rating >= 10000)
                Console.WriteLine("Your rating is Gold");
            else if (rating >= 8000)
                Console.WriteLine("Your rating is Silver");
            else if(rating >= 5000)
                Console.WriteLine("Your Rating is Bronze");
            else
                Console.WriteLine("You journey was really tough wasn't it? At least you made it.");
        }
        
    }
}