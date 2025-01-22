/*
Mission 3
Trace Wilson

System to manage food item inventory at a food bank. 

A food item consists of:
    • Name (e.g., "Canned Beans")
    • Category (e.g., "Canned Goods", "Dairy", "Produce")
    • Quantity (e.g., 15 units)
    • Expiration Date
The system provides a menu for the user to:
    • Add Food Items
    • Delete Food Items
    • Print List of Current Food Items
    • Exit the Program*/

using Mission3;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        
        // declare variables
        
        string command = "";
        List<FoodItem> items = new List<FoodItem>();

        
        // welcome text
        Console.WriteLine("Welcome to the Food Bank System!!");
        while (true)
        {
            
            // options text
            Console.WriteLine("Type one of the following commands: ");
            Console.WriteLine("1. Add an item");
            Console.WriteLine("2. Delete an item");
            Console.WriteLine("3. List current items");
            Console.WriteLine("4. Exit the Program");

            // user inputs the number of the command they want
            command = Console.ReadLine();
            
            // Logic to call the correct method for the command
            if (command == "1")
            {
                AddItem(items);
            }
            else if (command == "2")
            {
                DeleteItem(items);
            }
            else if (command == "3")
            {
                ListItems(items);
            }
            else if (command == "4")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
            // check if input was invalid
            else
            {
                Console.WriteLine("Invalid command. Please try again.");
            }
        }
    }
    // AddItem method: receives input to create a new item, and stores it to a list
    static void AddItem(List<FoodItem> items)
    {
        // initialize variables
        string itemName = "";
        string itemCategory = "";
        int itemQuantity = 0;
        DateTime itemExpirationDate;

        // prompt user to enter information for the new item
        // store each input in a variable
        Console.WriteLine("Item Name: ");
        itemName = Console.ReadLine();
        
        Console.WriteLine("Item Category: ");
        itemCategory = Console.ReadLine();
        
        Console.WriteLine("Item Quantity: ");
        while (!int.TryParse(Console.ReadLine(), out itemQuantity))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the quantity:");
        }
        
        
        Console.Write("Item Expiration Date (mm/dd/yyyy): ");
        while (!DateTime.TryParse(Console.ReadLine(), out itemExpirationDate))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date in the format mm/dd/yyyy:");
        }

        // create new FoodItem object
        FoodItem newItem = new FoodItem(itemName, itemCategory, itemQuantity, itemExpirationDate);

        // add the FoodItem object to the list of items
        items.Add(newItem);

        Console.WriteLine(items);
    }

    // DeleteItem method: Searches by name for an item and deletes it from the system
    static void DeleteItem(List<FoodItem> items)
    {
        // check if there are items available to delete
        if (items.Count == 0)
        {
            Console.WriteLine("\nNo items available to delete.");
            return;
        }
        
        // search by item name for the item to delete
        Console.WriteLine("\nEnter the name of the item to delete:");
        string itemName = Console.ReadLine();
        FoodItem itemToDelete = items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        // if the item exists, it is deleted from the list
        if (itemToDelete != null)
        {
            items.Remove(itemToDelete);
            Console.WriteLine($"Item '{itemName}' has been deleted.");
        }
        // if the input item does not exist, exit back to the command selection 
        else
        {
            Console.WriteLine($"Item '{itemName}' not found.");
        }
    }

    // ListItems method: Prints out the information for all items in the system
    static void ListItems(List<FoodItem> items)
    {
        Console.WriteLine("\nCurrent Items in the Food Bank:");
        foreach (var item in items)
        {
            Console.WriteLine($"Name: {item.Name}, Category: {item.Category}, Quantity: {item.Quantity}, Expiration: {item.Expiration.ToString("MM/dd/yyyy")}");
        }
    }

}