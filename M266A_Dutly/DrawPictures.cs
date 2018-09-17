using System;

namespace M266A_Dutly
{
    public class DrawPictures
    {
        //This method creates the night sky randomly
        public static void PrintNight()
        {
            Random rnd = new Random();
            
            for (int j = 0; j < 400; j++)
            {
                int whiteSpace = rnd.Next(5, 25);
                for (int i = 0; i < whiteSpace; i++)
                {
                    Console.Write(" ");
                }
                //I did the if statements like this
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