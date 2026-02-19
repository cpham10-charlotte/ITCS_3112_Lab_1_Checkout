using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// 
/// </summary>
public interface ICheckoutService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<CheckoutRecord> FindOverdue();
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    ICatalog GetCatalog();
    
    
    //Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate);

    //Receipt ReturnItem(string itemId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemId"></param>
    void MarkLost(string itemId);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<CheckoutRecord> ListActiveLoans();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="window"></param>
    /// <returns></returns>
    IReadOnlyList<CheckoutRecord> FindDueSoon(TimeSpan window);
}