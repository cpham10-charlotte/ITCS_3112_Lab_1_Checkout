using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;
using ITCS_3112_Lab_1_Checkout.Repositories;
namespace ITCS_3112_Lab_1_Checkout.Services;
/// <summary>
/// Provides readonly access to items in system.
/// </summary>
public class Catalog : ICatalog
{
    private readonly ItemRepository repository;

    public Catalog(ItemRepository repository)
    {
        this.repository = repository;
    }
    
    public IReadOnlyList<Item> ListAvailable()
    {
        //returns list of onlt available items
        return repository.AllItems().Where(item => item.Status == StatusEnum.AVAILABLE).ToList();
    }

    public IReadOnlyList<Item> ListUnavailable()
    {
        return repository.AllItems().Where(item => item.Status == StatusEnum.CHECKED_OUT 
                                                   || item.Status == StatusEnum.LOST).ToList();
    }
    
    public Item? FindById(string itemId)
    {
        //returns item found by item id.
        return repository.GetItem(itemId);
    }

    public IReadOnlyList<Item> SearchBy(string query)
    {
        //checks if query is empty
        if (string.IsNullOrWhiteSpace(query))
        {
            //returns empty list
            return new List<Item>();
        }
        
        query = query.Trim().ToLower();
        //retrieves all items, keeps only those which item or category name contain the query
        return repository.AllItems().Where(item => item.Name.ToLower().Contains(query) || item.Category.ToString().ToLower().Contains(query)).ToList();
        
    }
}