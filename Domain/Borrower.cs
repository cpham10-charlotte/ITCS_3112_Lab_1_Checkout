namespace ITCS_3112_Lab_1_Checkout.Domain;

public class Borrower
{
    public string Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Item> BorrowedItems { get; set; }
    public List<CheckoutRecord> BorrowHistory { get; set; }

    public Borrower(string id, string name, string email)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.BorrowedItems = new List<Item>();
        this.BorrowHistory = new List<CheckoutRecord>();
    }

    public void BorrowItem(Item item)
    {
        this.BorrowedItems.Add(item);
    }
    
    public void ReturnItem(Item item)
    {
        this.BorrowedItems.Remove(item);
    }
}