using System;
using System.Net.WebSockets;

namespace M266A_Dutly
{
    public class RandomVillageEncounter
    {
        private int VillageChance = 6;
        //This method gets called every round. There's a 20% chance that you encounter a village
        public void RandomChanceVillageEncounter()
        {
            Random rnd = new Random();

            int village = rnd.Next(VillageChance);

            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (village)
            {
                case 1:
                    Console.WriteLine("In the distance you see something. There seems to be a village. You immediately head towards it!");
                    Console.ResetColor();
                    VillageGameplay();
                    break;
                case 2:
                    Console.WriteLine("In the distance you see something. When you go towards it it suddenly disappears. It was only an illusion. Apparently this journey is making you crazy");
                    break;
                default:
                    Console.WriteLine("There is only emptiness. There seems to be nothing in this endless desert. All you want is to reach civilisation");
                    break;
            }
            Console.ResetColor();
        }
        //This is the main village menu
        public void VillageGameplay()
        {
            PrintMenuVillage();
            CheckEntry(Convert.ToInt32(Console.ReadLine()));
        }
        //This prints the main village menu
        public void PrintMenuVillage()
        {
            Console.WriteLine("Press [1] to head to the shop");
            Console.WriteLine("Press [2] to check your items");
            Console.WriteLine("Press [3] to leave the village");
        }
        //This checks if what you chose
        public void CheckEntry(int entry)
        {
            switch (entry)
            {
                case 1:
                    this.PrintShopMenu();
                    this.ShopCheckEntry(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 2:
                    Resources.ItemStatus();
                    this.VillageGameplay();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("As you leave the village, the night breaks in.");
                    Console.ResetColor();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
        
        //This prints the Shop menu
        public void PrintShopMenu()
        {
            Console.WriteLine("Press [1] to buy an ox (80 Dollars)");
            Console.WriteLine("Press [2] to buy 10 Food (20 Dollars)");
            Console.WriteLine("Press [3] to buy 10 oxfood (15 Dollars)");
            Console.WriteLine("Press [4] to buy 1 medicine (25 Dollars)");
            Console.WriteLine("Press [5] to sell an ox (+70 Dollars)");
            Console.WriteLine("Press [0] to leave the shop");
        }
        
        //These are the choices
        public void ShopCheckEntry(int entry)
        {
            Resources resources = new Resources();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (entry)
            {
                case 1:
                    this.EnoughMoney(80);
                    Oxen.OxCount++;
                    Console.WriteLine("You bought an Ox");
                    Console.ResetColor();
                    break;
                case 2:
                    this.EnoughMoney(20);
                    resources.Food += 10;
                    Console.ResetColor();
                    break;
                case 3:
                    this.EnoughMoney(15);
                    resources.Oxfood += 10;
                    Console.ResetColor();
                    break;
                case 4:
                    this.EnoughMoney(25);
                    resources.Medicine++;
                    Console.ResetColor();
                    break;
                case 5:
                    Oxen.OxCount--;
                    resources.Money += 70;
                    break;
                case 0:
                    this.VillageGameplay();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
            Console.ResetColor();
            this.VillageGameplay();
        }
        //This checks if you have enough money
        public void EnoughMoney(int moneyRequired)
        {
            Resources resources = new Resources();

            if (resources.Money < moneyRequired)
            {
                Console.WriteLine("You don't have enough money");
                Console.ResetColor();
                this.VillageGameplay();
            }
            else
            {
                resources.Money -= moneyRequired;
            }
            Console.ResetColor();
        }
    }
}