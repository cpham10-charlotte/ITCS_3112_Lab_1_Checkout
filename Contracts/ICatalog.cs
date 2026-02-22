using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts;
/// <summary>
/// Provides read only access to catalog data.
/// </summary>
public interface ICatalog
{
    /// <summary>
    /// Lists items that are available for checkout.
    /// </summary>
    /// <returns>Read only list of available items.</returns>
    IReadOnlyList<Item> ListAvailable();

    /// <summary>
    /// Lists items that are unavailable for checkout.
    /// </summary>
    /// <returns>Read only list of unavailable items.</returns>
    IReadOnlyList<Item> ListUnavailable();
    
    /// <summary>
    /// Finds specific item by its unique id.
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns>Matching item if found</returns>
    Item? FindById(string itemId);

    /// <summary>
    /// Searches catalog by text query.
    /// </summary>
    /// <param name="query"></param>
    /// <returns>Read only list of matching items.</returns>
    IReadOnlyList<Item> SearchBy(string query);
}