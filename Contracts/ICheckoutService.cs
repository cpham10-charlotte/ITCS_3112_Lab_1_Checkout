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
    
    /// <summary>
    /// Checks out item to borrower and creates new checkout record.
    /// </summary>
    /// <param name="itemId">Unique item identifier.</param>
    /// <param name="borrower">Borrower who is checking out item.</param>
    /// <param name="dueDate">Requested due date for item.</param>
    /// <returns>Created checkout record.</returns>
    /// <remarks>
    /// Precondition:
    /// Item must exist.
    /// Item must be eligible for checkout.
    /// Postcondition:
    /// New checkout record must be created and stored.
    /// Item status is updated.
    /// </remarks>
    CheckoutRecord Checkout(List<string> itemId, Borrower borrower, DateTime dueDate);
    
    /// <summary>
    /// Returns item and closes its active checkout record.
    /// </summary>
    /// <param name="itemId">Unique ID of item being returned.</param>
    /// <returns>Updated checkout record with return date set.</returns>
    /// <remarks>
    /// Precondition: Item must have active checkout record.
    /// Postconditions:
    /// Checkout record updated with returned date.
    /// Item status updated.
    /// </remarks>
    CheckoutRecord ReturnItem(string itemId);

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