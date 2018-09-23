using System;
using System.Runtime.CompilerServices;

namespace M266A_Dutly
{
    public class Resources
    {
        private static int _food = 15;
        private static int _money = 70;
        private static int _oxfood = 15;
        private static int _medicine = 3;
        private int _maxFoodRate = 10;
        private int _maxOxFoodRate = 15;
        private int _foodGathered;

        //A random number between 0 and 10 gets added to Food
        public void HuntFood()
        {
            Random rnd = new Random();

            _foodGathered = rnd.Next(_maxFoodRate);

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (_foodGathered != 0)
            {
                Console.WriteLine("Your hunt was successful");
                Console.WriteLine("You gathered {0} Food", _foodGathered);
            }
            else
            {
                Console.WriteLine("Your hunt failed. You got no food.");
            }

            _maxFoodRate++;
            Console.WriteLine("Your experience in hunting food increased");

            _food = _food + _foodGathered;
            Console.WriteLine("Food: " + _food);
            Console.ResetColor();
            //Console.WriteLine("_________________________________");
        }

        //A random number between 0 and 15 gets added to Oxfood
        public void HuntOxenFood()
        {
            Random rnd = new Random();
            _foodGathered = rnd.Next(_maxOxFoodRate);

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (_foodGathered != 0)
            {
                Console.WriteLine("You successfully gathered food for your oxen");
                Console.WriteLine("You gathered {0} Oxfood", _foodGathered);
            }
            else
            {
                Console.WriteLine("Your hunt failed.");
            }

            _maxOxFoodRate++;
            Console.WriteLine("Your experience in hunting oxfood increased");
            
            _oxfood = _oxfood + _foodGathered;
            Console.ResetColor();
            //Console.WriteLine("_________________________________");
        }

        //Every round this method gets called automatically. It gives your people and your oxen Food.
        public void GiveFood()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            _food = _food - People.PersonCount;
            _oxfood = _oxfood - Oxen.OxCount;
            if (_food <= 0)
            {
                _food = 0;
                Console.WriteLine("There is not enough food left for all.");
                People.PersonCount--;
            }
            
            if (_oxfood <= 0)
            {
                _oxfood = 0;
                Console.WriteLine("Your oxen don't have enough food. One of them can't move anymore");
                Oxen.OxCount--;
            }
            

            Console.ResetColor();
        }
        
        //This method shows you your items
        public static void ItemStatus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Money: " + _money + " Dollars");
            Console.WriteLine("Food: " + _food);
            Console.WriteLine("OxFood: " + _oxfood);
            Console.WriteLine("Medicine: " + _medicine);
            Console.WriteLine("Oxen: " + Oxen.OxCount);
            Console.WriteLine("People: " + People.PersonCount);
            Console.ResetColor();
        }


        public int FoodGathered
        {
            get => _foodGathered;
            set => _foodGathered = value;
        }

        public int Food
        {
            get => _food;
            set => _food = value;
        }

        public int Money
        {
            get => _money;
            set => _money = value;
        }

        public int Oxfood
        {
            get => _oxfood;
            set => _oxfood = value;
        }

        public int Medicine
        {
            get => _medicine;
            set => _medicine = value;
        }
    }
}