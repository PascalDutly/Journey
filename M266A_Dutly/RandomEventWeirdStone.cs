using System;

namespace M266A_Dutly
{
    public class RandomEventWeirdStone
    {
        public void PrintText()
        {
            DrawStonePlate();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "You stumble upon a weird stone. There is something written on it. It's like a code. Try to solve it (You only have one try)");

            Console.WriteLine(
                "01000100 01110101 01110100 01101100 01111001 00100000 01101001 01110011 00100000 01100011 01101111 01101111 01101100");
            Console.ResetColor();

            this.SolveRiddle(Console.ReadLine());
        }

        public void SolveRiddle(string solution)
        {
            if (solution == "Dutly is cool")
            {
                Console.WriteLine(
                    "Correct, I will tell you a secret as a reward. This event only exists to waste your time");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }

        public static void DrawStonePlate()
        {
            string text =
                System.IO.File.ReadAllText(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\StonePlate.txt");
            Console.Write(text);
            Console.WriteLine();
        }
    }
}