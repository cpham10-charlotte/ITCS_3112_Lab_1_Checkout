using ITCS_3112_Lab_1_Checkout.Domain;
namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// 
/// </summary>
public interface INotifier
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="borrower"></param>
    /// <param name="record"></param>
    void DueSoon(Borrower borrower, CheckoutRecord record);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="borrower"></param>
    /// <param name="record"></param>
    void Overdue(Borrower borrower, CheckoutRecord record);
}