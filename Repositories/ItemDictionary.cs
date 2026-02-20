using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

public class ItemDictionary
{
    public ItemDictionary()
    {
        Dictionary<string, Item> items = new Dictionary<string, Item>();
    }
}