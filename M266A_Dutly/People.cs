using System;

namespace M266A_Dutly
{
    public class People
    {
        private static int _personCount = 4;
        public static bool AllPersonsDead = false;
        //This method gets called when a Person dies. 
        public void PersonDies()
        {
            Console.WriteLine("One of your people died.");
            _personCount--;
            if (_personCount <= 0)
            {
                AllPersonsDead = true;
            }
            else if (_personCount > 1)
            {
                Console.WriteLine("There are {0} People left", _personCount);
            }
            else
            {
                Console.WriteLine("There is only {0} Person left. If you're a real man you won't give up.", _personCount);
            }
        }

        public static int PersonCount
        {
            get => _personCount;
            set => _personCount = value;
        }
    }
}