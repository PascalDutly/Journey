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
            Console.WriteLine("__________Random Event___________");
            this.RandomEvent();
            Console.WriteLine("_________Random Village__________");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are only {0} km left", _difficulty);
            Console.ResetColor();
        }

        //The game will progress 10 km per round (How many rounds = difficulty / 10)
        public static void SetDifficulty()
        {
            Console.WriteLine("You chose to start a new game (Your savefiles still exist)");
            Console.WriteLine("Choose your difficulty! 50 is easy, 500 is hard");
            _difficulty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your journey will be {0} Kilometers long", _difficulty);
        }

        //The menu gets printed
        public static void PrintMenu()
        {
            Console.WriteLine("Press [1] to hunt food in the wild");
            Console.WriteLine("Press [2] to gather food for your oxen in the wild");
            Console.WriteLine("Press [3] to travel further (20km instead of 10km)");
            Console.WriteLine("Press [4] to see your items");
            Console.WriteLine("Press [5] to save your game");
            Console.WriteLine("Press [6] to delete your protocol (Clear the console window)");
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You traveled 10km further than usual.");
                    Console.ResetColor();
                    _difficulty -= 10;
                    break;
                case 4:
                    Resources.ItemStatus();
                    this.Start();
                    break;
                case 5:
                    this.Save();
                    this.Start();
                    break;
                case 6:
                    Console.Clear();
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
            int random = rnd.Next(1, 8);

            switch (random)
            {
                case 1:
                    RandomEventBandits randomEventBandits = new RandomEventBandits();
                    randomEventBandits.PrintText();
                    break;
                case 2:
                    RandomEventAbandonedWagon randomEventAbandonedWagon = new RandomEventAbandonedWagon();
                    randomEventAbandonedWagon.PrintText();
                    break;
                case 3:
                    RandomEventStarvingPerson randomEventStarvingPerson = new RandomEventStarvingPerson();
                    randomEventStarvingPerson.PrintText();
                    break;
                case 4:
                    RandomEventWeirdStone randomEventWeirdStone = new RandomEventWeirdStone();
                    randomEventWeirdStone.PrintText();
                    break;
                case 5:
                    RandomEventDisease randomEventDisease = new RandomEventDisease();
                    randomEventDisease.PrintText();
                    break;
                case 6:
                    RandomEventRiver randomEventRiver = new RandomEventRiver();
                    randomEventRiver.PrintText();
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (People.AllPersonsDead == true)
            {
                Console.WriteLine("Every person died. Game Over");
                Console.ReadLine();
                Environment.Exit(0);
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
            Console.ReadLine();
            Environment.Exit(0);
        }
        //This lets you save your current game. You can also overwrite an existing savegame 
        public void Save()
        {
            Resources resources = new Resources();

            Console.WriteLine("What slot do you want to save it in? (Please only use integers)");
            Console.WriteLine("The Savefiles below already exist. You overwrite them by ONLY selecting their number");
            Program.PrintSaveGameNames();
            int saveSlot = Convert.ToInt32(Console.ReadLine());
            
            string[] items =
            {
                Convert.ToString(resources.Money), Convert.ToString(resources.Food),
                Convert.ToString(resources.Medicine), Convert.ToString(resources.Oxfood),
                Convert.ToString(Oxen.OxCount), Convert.ToString(People.PersonCount),
                Convert.ToString(_difficulty)
            };
            System.IO.File.WriteAllLines(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames\SaveGame" + saveSlot +".txt", items);

            //string text = System.IO.File.ReadAllText(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames\SaveGame" + saveSlot + ".txt");
            //Console.Write(text);
            Console.WriteLine("Game save successful!");
            Console.WriteLine();
        }

        public static int Difficulty
        {
            get => _difficulty;
            set => _difficulty = value;
        }
    }
}