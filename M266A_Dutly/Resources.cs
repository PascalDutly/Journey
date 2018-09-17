using System;
using System.Runtime.CompilerServices;

namespace M266A_Dutly
{
    
    
    public class Resources
    {
        private static int _food = 15;
        private static int _money = 100;
        private static int _oxfood = 15;
        private static int _medicine = 2;
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
            _food = _food + _foodGathered;
            Console.WriteLine("Food: " + _food);
            Console.ResetColor();
            Console.WriteLine("___________________");
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
            _oxfood = _oxfood + _foodGathered;
            Console.ResetColor();
        }

        public void GiveFood()
        {
            _food = _food - People.PersonCount;
            _oxfood = _oxfood - Oxen.OxCount;
        }
        
        //This method shows you your items
        public void ItemStatus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Money: " + _money + "Dollars");
            Console.WriteLine("Food: " + _food);
            Console.WriteLine("OxFood: " + _oxfood);
            Console.WriteLine("Medicine: " + _medicine);
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