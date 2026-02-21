using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Services;
/// <summary>
/// Provides checkout and due date rules.
/// </summary>
public class Policy : IPolicy
{
    private List<Item> items;
    private bool canCheckout;
    
    public Policy(List<Item> items)
    {
        this.items = items;
    }
    
    public bool CanCheckout(Item item)
    {
        //if the list does not contain the item, returns false.
        if (!items.Contains(item))
        {
            canCheckout = false;
            return false;
        }
        //if the status is not available, return false.
        if (item.Status != StatusEnum.AVAILABLE)
        {
            canCheckout = false;
            return false;
        }
        //if the condition is poor, returns false.
        if (item.Condition == ConditionEnum.POOR)
        {
            canCheckout = false;
            return false;
        }
        //otherwise, returns true and may be checked out.
        canCheckout = true;
        return true;
    }
    
    public DateTime NormalizeDueDate(DateTime proposed)
    {
        //window of 2 weeks
        var maxDate = DateTime.Today.AddDays(14);
        //if proposed date is earlier than current date, returns current date.
        if (proposed < DateTime.Today)
        {
            return DateTime.Today;
        }
        //if date is over 14 days, it caps at 14.
        if (proposed > maxDate)
        {
            return maxDate;
        }
        //otherwise, date proposed is returned.
        return proposed;
    }
}