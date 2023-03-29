using System;
using System.Reflection;

namespace characterInventory
{
    public class Inventory
    {
        public string Item { get; set; }
        public double Weight { get; set; }

        // overloaded operator ++ and operator --
        public static Inventory operator ++(Inventory weight)
        {
            return weight++;
        }
        public static Inventory operator --(Inventory weight)
        {
            return weight--;
        }
        // overloaded operator + and operator -
        public static Inventory operator +(Inventory item1, Inventory item2)
        {
            Inventory inventory = new Inventory();
            inventory.Weight = item1.Weight + item2.Weight;
            return inventory;
        }
        public static Inventory operator -(Inventory item1, Inventory item2)
        {
            Inventory inventory = new Inventory();
            inventory.Weight = item1.Weight - item2.Weight;
            return inventory;
        }
        // overloaded operator > and operator <
        public static bool operator >(Inventory item1, Inventory item2)
        {
            bool larger = false;
            if (item1.Weight > item2.Weight)
                larger = true;
            return larger;
        }
        public static bool operator <(Inventory item1, Inventory item2)
        {
            bool smaller = false;
            if (item1.Weight < item2.Weight)
                smaller = true;
            return smaller;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Inventory[] myInventory = new Inventory[100];
                for (int i = 0; i < myInventory.Length; i++)
                {
                    myInventory[i] = new Inventory();
                }
                int selection = Menu();
                int index = 0, entry = 0;
                double check = 0;
                string answ = "";
                while (selection != 5)
                {
                    switch (selection)
                    {
                        case 1:
                            if (index < 100)
                            {
                                Console.Write("What is the item's name? ");
                                myInventory[index].Item = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Please enter the weight of the item(lb): ");
                                myInventory[index].Weight = double.Parse(Console.ReadLine());
                                Console.WriteLine();
                                index++;
                            } 
                            else
                            {
                                Console.WriteLine("Your Inventory is full - see programming");
                            }
                            break;
                        case 2:
                            for (int i = 0; i < myInventory.Length; i++)
                            {
                                if (myInventory[i].Item != "" && myInventory[i].Item != null)
                                {
                                    Console.WriteLine($"Item: {myInventory[i].Item}     Weight: {myInventory[i].Weight}");
                                }
                            }
                            break;
                        case 3:
                            for (int i = 0; i < myInventory.Length; i++)
                            {
                                if (myInventory[i].Item != "" && myInventory[i].Item != null)
                                {
                                    Console.WriteLine($"Index: {i+1}     Item: {myInventory[i].Item}     Weight: {myInventory[i].Weight}");
                                }
                            }
                            Console.WriteLine("What entry would you like to change?");
                            Console.WriteLine($"1 through {index}");
                            while (!int.TryParse(Console.ReadLine(), out entry))
                            {
                                Console.WriteLine($"Please select 1 - {index}");
                            }
                            entry -= 1;  // subtract 1 to begin index at 0
                            selection = Change();
                            if (selection == 1)
                            {
                                Console.Write("What is the item's new name? ");
                                myInventory[entry].Item = Console.ReadLine();
                                Console.WriteLine();
                            } 
                            else if (selection == 2)
                            {
                                Console.Write("Would you like to increase the weight by 1lb? Y for Yes ");
                                answ = Console.ReadLine();
                                if (answ == "Y" || answ == "y")
                                {
                                    myInventory[entry].Weight++;
                                    Console.WriteLine();
                                    break;
                                }
                                Console.Write("Would you like to increase the weight by more than 1lb? Y for Yes ");
                                answ = Console.ReadLine();
                                if (answ == "Y" || answ == "y")
                                {
                                    Console.Write("Enter the weight: ");
                                    double w;
                                    while (!double.TryParse(Console.ReadLine(), out w))
                                        Console.WriteLine($"Please choose a valid number");
                                    myInventory[entry].Weight += w;
                                    Console.WriteLine();
                                    break;
                                }
                                Console.Write("Would you like to decrease the weight by 1lb? Y for Yes ");
                                answ = Console.ReadLine();
                                if (answ == "Y" || answ == "y")
                                {
                                    myInventory[entry].Weight--;
                                    Console.WriteLine();
                                    break;
                                }
                                Console.Write("Would you like to decrease the weight by more than 1lb? Y for Yes ");
                                answ = Console.ReadLine();
                                if (answ == "Y" || answ == "y")
                                {
                                    Console.Write("Enter the weight: ");
                                    double w;
                                    while (!double.TryParse(Console.ReadLine(), out w))
                                        Console.WriteLine($"Please choose a valid number");
                                    myInventory[entry].Weight -= w;
                                    Console.WriteLine();
                                    break;
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("What weight should we display items above? ");
                            check = double.Parse(Console.ReadLine());
                            foreach (Inventory item in myInventory)
                            {
                                if (item.Weight >= check)
                                {
                                    Console.WriteLine($"Item: {item.Item}     Weight: {item.Weight}");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }

                    selection = Menu();
                }
            }

            public static int Menu()
            {
                int choice = 0;
                Console.WriteLine("Please make a selection from the menu");
                Console.WriteLine("1 - Add an item");
                Console.WriteLine("2 - Print Inventory");
                Console.WriteLine("3 - Change an item");
                Console.WriteLine("4 - Check items above certain weight");
                Console.WriteLine("5 - Quit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                    Console.WriteLine("Please select 1 - 4");
                return choice;
            }
            public static int Change()
            {
                int choice = 0;
                Console.WriteLine("Please make a selection from the menu");
                Console.WriteLine("1 - Change name");
                Console.WriteLine("2 - Change weight");
                Console.WriteLine("3 - Nevermind");
                while (!int.TryParse(Console.ReadLine(), out choice))
                    Console.WriteLine("Please select 1 - 3");
                return choice;
            }
        }
    }
}