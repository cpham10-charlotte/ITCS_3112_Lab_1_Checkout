using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

/// <summary>
/// Repository for items and their associated records
/// </summary>
public class ItemRepository : IRepository
{
    private Dictionary<string, Item> items;
    private Dictionary<string, CheckoutRecord> records;
    
    public ItemRepository(Dictionary<string, Item> items, Dictionary<string, CheckoutRecord> records)
    {
        this.items = items;
        this.records = records;
    }
    /// <summary>
    /// Adds item to repository
    /// </summary>
    /// <param name="item">Item to be added</param>
    public void SaveItem(Item item)
    {
        // If item exists, stores in variable
        Item existingItem = this.GetItem(item.Id);

        // Removes item if it exists
        if (existingItem != null)
        {
            items.Remove(existingItem.Id, out existingItem);
        }
        
        items.Add(item.Id, item);
    }

    /// <summary>
    /// Retrieves item from repository
    /// </summary>
    /// <param name="id">Id of requested item</param>
    /// <returns>Item requested</returns>
    /// <exception cref="ArgumentException">Throws if item is not found</exception>
    public Item GetItem(string id)
    {
        Item match = null;
        // Checks if item exists and finds match
        items.TryGetValue(id, out match);
        if (match == null)
        {
            throw new ArgumentException("Item not found");
        }
        else
        {
            return match;
        }
    }
    
    /// <summary>
    /// Returns a list of all items within repository
    /// </summary>
    /// <returns>List of all items</returns>
    public IReadOnlyList<Item> AllItems()
    {
        return items.Values.ToList();
    }

    /// <summary>
    /// Logs record from transaction into repository
    /// </summary>
    /// <param name="record">Record to be added</param>
    /// <exception cref="ArgumentException">Throws if record is already in repository</exception>
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
            records.Add(record.Id, record);
        }
    }

    /// <summary>
    /// Retrieves requested record
    /// </summary>
    /// <param name="id">Id of record requested</param>
    /// <returns>Requested record</returns>
    /// <exception cref="ArgumentException">Throws if record is not found</exception>
    public CheckoutRecord GetActiveRecordFor(string id)
    {
        CheckoutRecord match = null;
        
        records.TryGetValue(id, out match);
        if (match == null)
        {
            throw new ArgumentException("Record not found");
        }
        else
        {
            return match;
        }
    }

    /// <summary>
    /// Returns a list of all records in repository
    /// </summary>
    /// <returns>List of CheckoutRecords</returns>
    public IReadOnlyList<CheckoutRecord> AllRecords()
    {
        return records.Values.ToList();
    }
}