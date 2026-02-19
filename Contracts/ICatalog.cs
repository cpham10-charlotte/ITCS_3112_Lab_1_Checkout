using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts;
/// <summary>
/// 
/// </summary>
public interface ICatalog
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<Item> ListAvailable();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    Item? FindById(string itemId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    IReadOnlyList<Item> SearchBy(string query);
}