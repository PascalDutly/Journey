using System;

namespace M266A_Dutly
{
    public class RandomVillageEncounter
    {
        private int VillageChance = 6;

        public void RandomChanceVillageEncounter()
        {
            Random rnd = new Random();

            int Village = rnd.Next(VillageChance);

            
            switch (Village)
            {
                case 1:
                    Console.WriteLine("In the distance you see something. There seems to be a village. You immediately head towards it!");
                    VillageGameplay();
                    break;
                case 2:
                    Console.WriteLine("In the distance you see something. When you go towards it it suddenly disappears. It was only an illusion.");
                    break;
                default:
                    Console.WriteLine("There is only emptiness. There seems to be nothing in this endless desert");
                    break;
            }
        }

        public void VillageGameplay()
        {
            PrintMenuVillage();
            CheckEntry(Convert.ToInt32(Console.ReadLine()));
        }

        public void PrintMenuVillage()
        {
            Console.WriteLine("Press [1] to head to the shop");
            Console.WriteLine("Press [2] to head to leave the village");
        }

        public void CheckEntry(int entry)
        {
            switch (entry)
            {
                case 1:
                    this.PrintShopMenu();
                    this.ShopCHeckEntry(Convert.ToInt32(Console.ReadLine()));
                    break;
            }
        }

        public void PrintShopMenu()
        {
            Console.WriteLine("Press [1] to buy an ox (80 Dollars)");
            Console.WriteLine("Press [2] to buy 10 Food (20 Dollars)");
            Console.WriteLine("Press [3] to buy 10 oxfood (15 Dollars)");
            Console.WriteLine("Press [4] to buy 1 medicine (25 Dollars)");
            Console.WriteLine("Press [0] to leave the shop");
        }

        public void ShopCHeckEntry(int entry)
        {
            switch (entry)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}