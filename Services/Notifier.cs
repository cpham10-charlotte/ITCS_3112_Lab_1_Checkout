using ITCS_3112_Lab_1_Checkout.Contracts;
using ITCS_3112_Lab_1_Checkout.Domain;


namespace ITCS_3112_Lab_1_Checkout.Services;

public class Notifier : INotifier
{
    public void DueSoon(Borrower borrower, CheckoutRecord record)
    {
        Console.WriteLine($"Reminder: {borrower.Name}, item{record.Id} is due on {record.DueDate:d}");
    }

    public void Overdue(Borrower borrower, CheckoutRecord record)
    {
        Console.WriteLine($"OVERDUE: {borrower.Name}, item{record.Id} was due on {record.DueDate:d}");
    }
}