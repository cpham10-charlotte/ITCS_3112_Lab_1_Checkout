using ITCS_3112_Lab_1_Checkout.Domain;
namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// Sends notifications to borrowers regarding checked out items.
/// </summary>
public interface INotifier
{
    /// <summary>
    /// Notifies borrower that an item is due soon.
    /// </summary>
    /// <param name="borrower">Borrower which receives the notification.</param>
    /// <param name="record">Checkout record related to the notification.</param>
    void DueSoon(Borrower borrower, CheckoutRecord record);
    
    /// <summary>
    /// Notifies borrower that an item is overdue.
    /// </summary>
    /// <param name="borrower">Borrower which receives the notification.</param>
    /// <param name="record">Checkout record related to the notification.</param>
    void Overdue(Borrower borrower, CheckoutRecord record);
}