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
        var policy = new Policy();
        var clock = new Clock();
        var catalog = new Catalog(itemRepository);
        var checkoutService = new CheckoutService(itemRepository, policy, clock, catalog);
        bool hold = true;
        
        Item item1 = new Item("LPT1", "Dell XPS 13", CategoryEnum.LAPTOP,  StatusEnum.AVAILABLE, ConditionEnum.GOOD);
        Item item2 = new Item("LPT2", "Dell XPS 15", CategoryEnum.LAPTOP, StatusEnum.CHECKED_OUT, ConditionEnum.GOOD);
        Item item3 = new Item("VR1", "Oculus Rift", CategoryEnum.VR_HEADSET,  StatusEnum.AVAILABLE, ConditionEnum.FAIR);
        Item item4 = new Item("S1", "Sensor Name", CategoryEnum.SENSOR,  StatusEnum.LOST, ConditionEnum.POOR);
        
        itemRepository.SaveItem(item1);
        itemRepository.SaveItem(item2);
        itemRepository.SaveItem(item3);
        itemRepository.SaveItem(item4);
        
        while (hold)
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
                case "0":
                    hold = false;
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
        /* Console.WriteLine("Enter each field on its own line: ID, Name, Category, Condition"); */
        Console.WriteLine("Enter Item Id: \n");
        string id = Console.ReadLine();
        Console.WriteLine("Enter Item Name: \n");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Item Category (LAPTOP, VR HEADSET, SENSOR): \n");
        string category = Console.ReadLine();
        Enum.TryParse(category, true, out CategoryEnum categoryEnum);
        Console.WriteLine("Enter Item Condition(GOOD, FAIR, POOR): \n");
        string condition = Console.ReadLine();
        Enum.TryParse(condition, true, out ConditionEnum conditionEnum);

        Item newItem = new Item(id, name, categoryEnum, StatusEnum.AVAILABLE, conditionEnum);
        repository.SaveItem(newItem);
    }

    static void ListAvailable(ICheckoutService checkoutService)
    {
        IReadOnlyList<Item> items = checkoutService.GetCatalog().ListAvailable();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    

    static void ListUnavailable(ICheckoutService checkoutService)
    {
        IReadOnlyList<Item> items = checkoutService.GetCatalog().ListUnavailable();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    static void CheckoutItem(ICheckoutService checkoutService)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("Checkout item:");
        Console.WriteLine("Enter Borrower Id: \n");
        string borrowerId = Console.ReadLine();
        Console.WriteLine("Enter Borrower Name: \n");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Borrower Email: \n");
        string email = Console.ReadLine();

        var borrower = new Borrower(borrowerId, name, email);
        
        Console.WriteLine("Enter Item Id: \n");
        string itemId = Console.ReadLine();
        
        Console.WriteLine("Due date:");
        DateTime dueDate;
        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            Console.WriteLine("Invalid due date");
        }

        try
        {
            var record = checkoutService.Checkout(new List<string> { itemId }, borrower, dueDate);
            Console.WriteLine("Record:");
            Console.WriteLine($"{record.Date} | Checkout due {record.DueDate} | {borrower.Name}");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    static void ReturnItem(ICheckoutService checkoutService)
    {
        Console.WriteLine("Enter Item Id: ");
        string itemId = Console.ReadLine();
        checkoutService.ReturnItem(itemId);
    }

    static void ShowDueSoon(ICheckoutService checkoutService)
    {
        IReadOnlyList<CheckoutRecord> records = checkoutService.FindDueSoon(TimeSpan.FromDays(1));
        foreach (var record in records)
        {
            Console.WriteLine(record);
        }
    }

    static void ShowOverdue(ICheckoutService checkoutService)
    {
        IReadOnlyList<CheckoutRecord> records = checkoutService.FindOverdue();
        foreach (var record in records)
        {
            Console.WriteLine(record);
        }
    }

    static void Search(ICheckoutService checkoutService)
    {
        Console.WriteLine("Enter number for search type: \n1) Item Id \n2) Name \n3) Category ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter item Id: ");
                string id = Console.ReadLine();
                var item = checkoutService.GetCatalog().FindById(id);
                if (item == null)
                {
                    Console.WriteLine("Item not found");
                }
                else
                {
                    Console.WriteLine($"{item.Id} | {item.Name} | {item.Condition}");
                }
                break;
            case "2":
                Console.WriteLine("Enter item Name: ");
                string name = Console.ReadLine();
                var result = checkoutService.GetCatalog().SearchBy(name);
                if (result.Count == 0)
                {
                    Console.WriteLine("None found");
                    return;
                }

                foreach (var items in result)
                {
                    Console.WriteLine($"{items.Id} | {items.Name} | {items.Condition}");
                }
                break;
            case "3":
                Console.WriteLine("Enter item Category: ");
                string category = Console.ReadLine(); 
                var categoryResult = checkoutService.GetCatalog().SearchBy(category);
                if (categoryResult.Count == 0)
                {
                    Console.WriteLine("None found");
                    return;
                }

                foreach (var items in categoryResult)
                {
                    Console.WriteLine($"{items.Id} | {items.Name} | {items.Condition}");
                }
                break;
        }
    }

    static void MarkLost(ICheckoutService checkoutService)
    {
        Console.WriteLine("Enter item id: ");
        string itemId = Console.ReadLine();
        checkoutService.MarkLost(itemId);
        Console.WriteLine($"{itemId} has been marked as lost");
    }
}