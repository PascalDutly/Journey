using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace M266A_Dutly
{
    public class America
    {
        private static int _difficulty;

        //One round consists of these methods
        public void Start()
        {
            PrintMenu();
            this.CheckEntry(Convert.ToInt32(Console.ReadLine()));
            this.RandomEvent();
            Console.WriteLine("_________________________________");
            RandomVillageEncounter randomVillageEncounter = new RandomVillageEncounter();
            randomVillageEncounter.RandomChanceVillageEncounter();
            Console.WriteLine("_________________________________");
            Console.WriteLine("Press 'Enter' to sleep");
            Console.ReadLine();
            DrawPictures.PrintNight();
            this.Progress();
            this.CheckIfGameIsOver();
        }

        //Your Progress
        public void Progress()
        {
            _difficulty = _difficulty - 10;
            Console.WriteLine("There are only {0} km left", _difficulty);
        }

        //The game will progress 10 km per round (How many rounds = difficulty / 10)
        public static void SetDifficulty()
        {
            Console.WriteLine("Choose your difficulty! 50 is easy, 500 is hard");
            _difficulty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your journey will be {0} Kilometers long", _difficulty);
        }

        //The menu gets printed
        public static void PrintMenu()
        {
            Console.WriteLine("Press [1] to hunt for food in the wild");
            Console.WriteLine("Press [2] to gather food for your oxen in the wild");
            Console.WriteLine("Press [3] to see your items");
            Console.WriteLine("Press [4] to save your game");
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
                    Resources.ItemStatus();
                    this.Start();
                    break;
                case 4:
                    this.Save();
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
            int random = rnd.Next(1, 5);

            switch (random)
            {
                case 1:
                    RandomEventBandits randomEventBandits = new RandomEventBandits();
                    randomEventBandits.PrintText();
                    break;
                case 2:
                    RandomEventAbandonedWagon.PrintText();
                    break;
                case 3:
                    RandomEventStarvingPerson randomEventStarvingPerson = new RandomEventStarvingPerson();
                    randomEventStarvingPerson.PrintText();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(
                        "Today is a calm day. Nothing special seems to happen. Consider yourself lucky. Not every day goes so well");
                    Console.ResetColor();
                    break;
            }


            Console.ResetColor();
        }

        //Every round the game checks if the game is over
        public void CheckIfGameIsOver()
        {
            if (Oxen.AllOxenDead == true)
            {
                Console.WriteLine(
                    "All of your oxen died. You're left in the middle of nowhere. Your journey ends here. Game Over");
            }

            if (People.AllPersonsDead == true)
            {
                Console.WriteLine("Every person died. Game Over");
            }

            if (_difficulty <= 0)
            {
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
            if (rating >= 11000)
                Console.WriteLine("Your rating is Gold");
            else if (rating >= 8000)
                Console.WriteLine("Your rating is Silver");
            else if (rating >= 6000)
                Console.WriteLine("Your Rating is Bronze");
            else
                Console.WriteLine("You journey was really tough wasn't it? At least you made it.");
            Console.WriteLine("Score: {0}", rating);
            string text = System.IO.File.ReadAllText(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\You_Win.txt");
            Console.Write(text);
            Environment.Exit(0);
        }

        public void Save()
        {
            Resources resources = new Resources();

            Console.WriteLine("What slot do you want to save it in? (Please only use integers)");
            int saveSlot = Convert.ToInt32(Console.ReadLine());
            
            string[] items =
            {
                Convert.ToString(resources.Money), Convert.ToString(resources.Food),
                Convert.ToString(resources.Medicine), Convert.ToString(resources.Oxfood),
                Convert.ToString(Oxen.OxCount), Convert.ToString(People.PersonCount),
                Convert.ToString(_difficulty)
            };
            System.IO.File.WriteAllLines(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames\SaveGame" + saveSlot +".txt", items);

            string text = System.IO.File.ReadAllText(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames\SaveGame" + saveSlot + ".txt");
            Console.Write(text);
            Console.WriteLine();
        }

        public int Difficulty
        {
            get => _difficulty;
            set => _difficulty = value;
        }
    }
}