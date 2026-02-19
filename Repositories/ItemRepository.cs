using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

public class ItemRepository : IRepository
{
    private Dictionary<string, Item> items;

    // Initializes the class with an existing dictionary
    public ItemRepository(Dictionary<string, Item> items)
    {
        this.items = items;
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
    
    
}