using System;

namespace M266A_Dutly
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Console.SetWindowSize(
                Math.Min(200, Console.LargestWindowWidth),
                Math.Min(60, Console.LargestWindowHeight));
            
            America america = new America();
            
            America.SetDifficulty();
            america.Start();
            

        }
        
        
    }
}
//The console window is 200 characters wide

// IMPORTANT: You should run the code in the real console window.
// Different things get displayed in different colors
// Default color: Menu
// Yellow: Information
// Blue: Text
// Red: Negative event