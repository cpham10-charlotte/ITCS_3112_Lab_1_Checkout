using ITCS_3112_Lab_1_Checkout.Domain;
namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// 
/// </summary>
public interface IRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    void SaveItem(Item item);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    Item? GetItem(string itemId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<Item> AllItems();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="record"></param>
    void SaveRecord(CheckoutRecord record);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    CheckoutRecord? GetActiveRecordFor(string itemId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<CheckoutRecord> AllRecords();
    
    
}