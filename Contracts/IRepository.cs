using ITCS_3112_Lab_1_Checkout.Domain;
namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// Handles storage and retrieval of items and checkout records.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Saves item in repository.
    /// </summary>
    /// <param name="item">Item to be saved.</param>
    void SaveItem(Item item);
    
    /// <summary>
    /// Retrieves item by ID.
    /// </summary>
    /// <param name="itemId">Item identifier.</param>
    /// <returns>Item if found, otherwise null.</returns>
    Item? GetItem(string itemId);
    
    /// <summary>
    /// Gets all items in repository.
    /// </summary>
    /// <returns>Ready only list of all items.</returns>
    IReadOnlyList<Item> AllItems();
    
    /// <summary>
    /// Saves checkout record.
    /// </summary>
    /// <param name="record">Checkout record to be saved.</param>
    void SaveRecord(CheckoutRecord record);
    
    /// <summary>
    /// Gets active checkout record for given time.
    /// </summary>
    /// <param name="itemId">Item identifier.</param>
    /// <returns>Active checkout record if one exists.</returns>
    CheckoutRecord? GetActiveRecordFor(string itemId);
    
    /// <summary>
    /// Retrieves all checkout records.
    /// </summary>
    /// <returns>Read only list of all checkout records.</returns>
    IReadOnlyList<CheckoutRecord> AllRecords();
    
    
}