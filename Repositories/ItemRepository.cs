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
        Item item existingItem = this.GetItem(item.id);
    }
}