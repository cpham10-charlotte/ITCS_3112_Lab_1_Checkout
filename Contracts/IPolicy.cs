using ITCS_3112_Lab_1_Checkout.Domain;
namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// Defines rules related to borrowing and due dates.
/// </summary>
public interface IPolicy
{
    /// <summary>
    /// Determines whether an item can be checked out.
    /// </summary>
    /// <param name="item">Item being evaluated.</param>
    /// <returns>true if item can be checked out; otherwise false</returns>
    bool CanCheckout(Item item);
    
    /// <summary>
    /// Adjusts due date according to policy.
    /// </summary>
    /// <param name="proposed">Proposed due date.</param>
    /// <returns>Normalized due date that follows policy.</returns>
    DateTime NormalizeDueDate(DateTime proposed);
}