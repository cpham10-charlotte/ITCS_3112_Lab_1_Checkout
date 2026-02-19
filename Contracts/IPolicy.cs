using ITCS_3112_Lab_1_Checkout.Domain;
namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// 
/// </summary>
public interface IPolicy
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    bool CanCheckout(Item item);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="proposed"></param>
    /// <returns></returns>
    DateTime NormalizeDueDate(DateTime proposed);
}