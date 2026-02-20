namespace ITCS_3112_Lab_1_Checkout.Domain;

public class CheckoutRecord
{
    public string Id { get; init; }
    public List<Item> Items { get; init; }
    public Borrower Borrower { get; init; }
    public DateTime Date { get; init; }
    public DateTime DueDate { get; init; }

    public CheckoutRecord(string id, List<Item> items, Borrower borrower)
    {
        this.Id = id;
        this.Items = items;
        this.Borrower = borrower;
        this.Date = DateTime.Now;
    }
}