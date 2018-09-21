using System;

namespace M266A_Dutly
{
    public class Oxen
    {
        private static int _oxCount = 3;
        public static bool AllOxenDead = false;
        //This method kills an ox and it shows you how many oxen are left
        public void OxDies()
        {
            Console.WriteLine("One of your oxen died");
            _oxCount--;
            if (_oxCount <= 0)
            {
                AllOxenDead = true;
            }
            else if (_oxCount > 1)
            {
                Console.WriteLine("There are {0} oxen left", _oxCount);
            }
            else
            {
                Console.WriteLine("There is only {0} ox left. You should buy or find a new one.", _oxCount);
            }
        }
        
        //This adds an ox.
        public void OxAdd()
        {
            _oxCount++;
        }

        public static int OxCount
        {
            get => _oxCount;
            set => _oxCount = value;
        }
    }
}