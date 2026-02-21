using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Repositories;
namespace ITCS_3112_Lab_1_Checkout.Services;

public class CheckoutService : ICheckoutService
{
    private readonly ItemRepository repository;
    private readonly IPolicy policy;
    private readonly IClock clock;
    private readonly ICatalog catalog;

    public CheckoutService(ItemRepository repository, IPolicy policy, IClock clock, ICatalog catalog)
    {
        this.repository = repository;
        this.policy = policy;
        this.clock = clock;
        this.catalog = catalog;
    }
    
    public IReadOnlyList<CheckoutRecord> FindOverdue()
    {
        //gets current day from clock
        var today = clock.Today();
        //returns all active records, filters those by overdue due dates
        return ListActiveLoans().Where(record => record.DueDate < today).ToList();
    }

    public ICatalog GetCatalog()
    {
        return catalog;
    }

    public CheckoutRecord Checkout(List<string> itemId, Borrower borrower, DateTime dueDate)
    {
        //empty list of checked out items to be stored.
        var items = new List<Item>();
        //loops through each item id.
        foreach (var id in itemId)
        {
            //finds item with that id.
            var item = repository.GetItem(id);
            //if item doesn't exist, throws exception.
            if (item == null)
            {
                throw new Exception($"Item with id {itemId} not found");
            }
            //if policy says item cannot be checked out, throws exception.
            if (!policy.CanCheckout(item))
            {
                throw new Exception($"Item with id {itemId} cannot be checked out");
            }
            //otherwise, adds item to list.
            items.Add(item);
        }
        
        var normalizedDueDate = policy.NormalizeDueDate(dueDate);
        //creates new checkout record with unique ID, list of checked out items, borrower, and due date.
        var record = new CheckoutRecord(Guid.NewGuid().ToString(), items, borrower){DueDate = normalizedDueDate};

        //updates each item's status.
        foreach (var item in items)
        {
            //marks item as checked out + saves back into repository.
            item.Status = StatusEnum.CHECKED_OUT;
            repository.SaveItem(item);
        }
        
        //saves record and returns it.
        repository.SaveRecord(record);
        return record;
    }

    public CheckoutRecord ReturnItem(string itemId)
    {
        //get all records, finding first that contains the item.
        var record = repository.AllRecords().FirstOrDefault(record => record.Items.Any(i => i.Id == itemId));
        //if not found, throws exception.
        if (record == null)
        {
            throw new Exception($"Item with id {itemId} not found");
        }
        //finds exact item inside record.
        var item = record.Items.First(i => i.Id == itemId);
        //marks available again.
        item.Status = StatusEnum.AVAILABLE;
        //saves updated item + removes it from record, updates, and returns.
        repository.SaveItem(item);
        record.Items.Remove(item);
        repository.SaveRecord(record);
        return record;
    }

    public void MarkLost(string itemId)
    {
        //gets item from repository and checks if it exists.
        if (repository.GetItem(itemId) == null)
        {
            throw new Exception($"Item with id {itemId} not found");
        }
        //marks as lost and saves back to repository.
        repository.GetItem(itemId).Status = StatusEnum.LOST;
        repository.SaveItem(repository.GetItem(itemId));
    }

    public IReadOnlyList<CheckoutRecord> ListActiveLoans()
    {
        //returns all records, keeping those where at least one item is still checked out.
        return repository.AllRecords().Where(record => record.Items.Any(i => i.Status == StatusEnum.CHECKED_OUT)).ToList();
    }

    public IReadOnlyList<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        var today = clock.Today();
        var duration = today.Add(window);
        //returns all active records where the due date is after or current to today/before or current to the window end date.
        return ListActiveLoans().Where(record => record.DueDate >= today && record.DueDate <= duration).ToList();
    }
}