using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// Handles checkout, returns, and tracking.
/// </summary>
public interface ICheckoutService
{
    /// <summary>
    /// Lists all checkout records which are overdue.
    /// </summary>
    /// <returns>Read only list of overdue checkout records.</returns>
    IReadOnlyList<CheckoutRecord> FindOverdue();
    
    /// <summary>
    /// Provides access to catalog.
    /// </summary>
    /// <returns>Instance of ICatalog.</returns>
    ICatalog GetCatalog();
    
    
    //Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate);

    //Receipt ReturnItem(string itemId);

    /// <summary>
    /// Marks item as lost.
    /// </summary>
    /// <param name="itemId">ID of item to be marked as lost.</param>
    /// <remarks>
    /// Precondition: Item must exist.
    /// Postcondition: Item status updated to lost.
    /// </remarks>
    void MarkLost(string itemId);

    /// <summary>
    /// Lists active check out records.
    /// </summary>
    /// <returns>Read only list of active checkout records.</returns>
    IReadOnlyList<CheckoutRecord> ListActiveLoans();
    
    /// <summary>
    /// Finds items due within a specific time window.
    /// </summary>
    /// <param name="window">Time span to check upcoming due dates.</param>
    /// <returns>Read only list of checkout records due soon.</returns>
    IReadOnlyList<CheckoutRecord> FindDueSoon(TimeSpan window);
}