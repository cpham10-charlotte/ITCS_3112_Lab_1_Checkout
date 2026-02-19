using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

public class ItemRepository : IRepository
{
    private Dictionary<string, Item> items;
    private Dictionary<string, CheckoutRecord> records;

    // Initializes the class with an existing dictionary
    public ItemRepository(Dictionary<string, Item> items, Dictionary<string, CheckoutRecord> records)
    {
        this.items = items;
        this.records = records;
    }
    public void SaveItem(Item item)
    {
        // If item exists, stores in variable
        Item item existingItem = this.GetItem(item.Id);

        // Removes item if it exists
        if (existingItem != null)
        {
            items.Remove(existingItem);
        }
        
        items.Add(item.Id, item);
    }

    public Item GetItem(string id)
    {
        Item match = null;
        // Checks if item exists and finds match
        items.TryGetValue(id, out match);
        return match;
    }

    public IReadOnlyList<Item> AllItems()
    {
        return items.Values.ToList();
    }

    public void SaveRecord(CheckoutRecord record)
    {
        // If item exists, stores in variable
        CheckoutRecord existingRecord = this.GetActiveRecordFor(record.Id);

        // Removes item if it exists
        if (existingRecord != null)
        {
            throw new ArgumentException("Record already exists");
        }
        else
        {
            records.Add(record);
        }
    }
}