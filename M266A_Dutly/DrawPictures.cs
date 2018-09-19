using System;

namespace M266A_Dutly
{
    public class DrawPictures
    {
        //This method creates the night sky randomly
        public static void PrintNight()
        {
            Random rnd = new Random();
            
            for (int j = 0; j < 396; j++)
            {
                int whiteSpace = rnd.Next(5, 25);
                for (int i = 0; i < whiteSpace; i++)
                {
                    Console.Write(" ");
                }
                //The color of the stars get changed depending on the value of whiteSpace
                if (whiteSpace < 12)
                    Console.ForegroundColor = ConsoleColor.Blue;
                
                else if (whiteSpace > 17)
                    Console.ForegroundColor = ConsoleColor.Cyan;

                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                Console.Write("*");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        
    }
}