using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Repositories;
using ITCS_3112_Lab_1_Checkout.Services;

namespace ITCS_3112_Lab_1_Checkout;

class Program
{
    static void Main(string[] args)
    {
        var itemRepository = new ItemRepository(new Dictionary<string, Item>(), new Dictionary<string, CheckoutRecord>());
        var policy = new Policy(new List<Item>());
        var clock = new Clock();
        var catalog = new Catalog(itemRepository);
        var checkoutService = new CheckoutService(itemRepository, policy, clock, catalog);

        while (true)
        {
            ShowMenu();
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    AddItems(itemRepository);
                    break;
                case "2":
                    ListAvailable(checkoutService);
                    break;
                case "3":
                    ListUnavailable(checkoutService);
                    break;
                case "4":
                    CheckoutItem(checkoutService);
                    break;
                case "5":
                    ReturnItem(checkoutService);
                    break;
                case "6":
                    ShowDueSoon(checkoutService);
                    break;
                case "7":
                    ShowOverdue(checkoutService);
                    break;
                case "8":
                    Search(checkoutService);
                    break;
                case "9":
                    MarkLost(checkoutService);
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Welcome to the Equipment Checkout System!\nChoose an option: \n1) Add items to inventory\n2) List available items\n3) List unavailable items\n4) Check out item\n5) Return item\n6) Show due soon (next 24h)\n7) Show overdue items\n8) Search items (optional)\n9) Mark item LOST\n0) Exit");
        Console.WriteLine("\nSelect a number: ");
    }

    static void AddItems(ItemRepository repository)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("Add items to inventory");
        Console.WriteLine("Enter each field on its own line: ID, Name, Category, Condition");
    }

    static void ListAvailable(ICheckoutService checkoutService)
    {
        IReadOnlyList<Item> items = checkoutService.GetCatalog().ListAvailable();
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id} - {item.Name} - {item.Category} - {item.Condition}");
        }
    }

    static void ListUnavailable(ICheckoutService checkoutService)
    {
        
    }
    
    static void CheckoutItem(ICheckoutService checkoutService)
    {}
    static void ReturnItem(ICheckoutService checkoutService){}
    
    static void ShowDueSoon(ICheckoutService checkoutService){}
    
    static void ShowOverdue(ICheckoutService checkoutService){}
    
    static void Search(ICheckoutService checkoutService){}
    
    static void MarkLost(ICheckoutService checkoutService){}
}