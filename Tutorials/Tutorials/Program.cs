// See https://aka.ms/new-console-template for more information
using System;

class program
{
    static List<(string Name, double Price, double Quantity)> Items = new();
    static void Main() {
        Console.WriteLine("______________Simple Inventory Management______________");
        Console.WriteLine("");
        Console.WriteLine("1.Add an item(Name, Quantity, Price) ");
        Console.WriteLine("2.Remove an item ");
        Console.WriteLine("3.Update quantity of an item");
        Console.WriteLine("4.List all items with total value(Quantity × Price)");
        Console.WriteLine("5.Exit");
        Console.WriteLine("_______________________________________________________");

        while (true)
        {
            Console.Write("Enter choice(1,2,3,4,5): ");
            string choice = Console.ReadLine();
            int choiceCheck;
            if (!int.TryParse(choice, out choiceCheck) || choiceCheck < 0)
            {
                Console.WriteLine("Enter valid number");
                continue;
            }

            switch (choiceCheck)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Remove();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    View();
                    break;
                case 5:
                    Console.WriteLine("thank you !!!");
                    return;
                    break;
                default:
                    Console.WriteLine("Enter number from List ");
                    break;
            }

        }
    }

    static void Add(){
        Console.Write("Enter Name Item: ");
        string Name = Console.ReadLine();
        if (string.IsNullOrEmpty(Name)) {
            Console.WriteLine("Name cant be empty ");
            return;
        }

        Console.Write("Enter Quantity of Items: ");
        string Quantity = Console.ReadLine();
        double quantity;
        if (!double.TryParse(Quantity, out quantity)) {
            Console.WriteLine("Please enter a valid number for Quantity");
            return;
        }

        Console.Write("Enter price per Item: R ");
        string Price = Console.ReadLine();
        double PricePerItem;
        if (!double.TryParse(Price, out PricePerItem) || PricePerItem < 0) {
            Console.WriteLine("Please enter only numbers");
            return;
        }

        Items.Add((Name, PricePerItem, quantity));
        Console.WriteLine("Item added successfully!");
        Console.WriteLine("_______________________________________________________");
    }
    static void Remove(){
        Console.Write("Enter Item name: ");
        string Remove = Console.ReadLine();
        if (string.IsNullOrEmpty(Remove))
        {
            Console.WriteLine("Name cant be empty ");
            return;
        }


        int removedCount = Items.RemoveAll(item => item.Name.Equals(Remove, StringComparison.OrdinalIgnoreCase));

        if (removedCount > 0)
            Console.WriteLine($"Removed {removedCount} item(s) named '{Remove}'.");
        else
            Console.WriteLine("Item not found.");
        Console.WriteLine("_______________________________________________________");
    }

    static void Update(){
        Console.Write("Enter Item Name: ");
        string Name = Console.ReadLine();
        if (string.IsNullOrEmpty(Name))
        {
            Console.WriteLine("Name cant be empty ");
        }

        int Found = Items.FindIndex(item => item.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));

        if (Found == -1)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        Console.Write("Enter a new quantity: ");
        string qtity = Console.ReadLine();
        int newquantity;
        if(!int.TryParse(qtity,out newquantity))
        {
            Console.WriteLine("Please enter a valid number for quantity ");
            return;

        }

        //update price
        Console.Write("Enter new price (or press Enter to keep old price): ");
        string priceInput = Console.ReadLine();
        double newprice = Items[Found].Price;

        if (!string.IsNullOrEmpty(priceInput))
        {
            if (!double.TryParse(priceInput,out newprice) || newprice <0)
            {
                Console.WriteLine("Invalid price entered. Keeping old price. ");
                newprice = Items[Found].Price;
            }
        }
        Items[Found] = (Items[Found].Name,newquantity ,newprice );
        Console.WriteLine("Invalid price entered. Keeping old price.");
        Console.WriteLine("_______________________________________________________");

    }

    static void View()
    {

        if (Items.Count == 0)
        {
            Console.WriteLine("No items found.");
            return;
        }
        Console.WriteLine("List of all items with total value(Quantity × Price)");

        foreach (var list in Items)
        {
            double TotalValue = list.Price * list.Quantity;
            Console.WriteLine($"Name:{list.Name} Quantity:{list.Quantity} Price:{list.Price} Total Value:{TotalValue}");
        }

    }

    }


















