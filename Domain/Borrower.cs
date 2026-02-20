namespace ITCS_3112_Lab_1_Checkout.Domain;

/// <summary>
/// Class for Individuals who borrow and return items
/// </summary>
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

    /// <summary>
    /// Adds item to borrowers item list
    /// </summary>
    /// <param name="item">Item being borrowed</param>
    public void BorrowItem(Item item)
    {
        this.BorrowedItems.Add(item);
    }
    
    /// <summary>
    /// Removes item from borrowers item list 
    /// </summary>
    /// <param name="item">Item being returned</param>
    public void ReturnItem(Item item)
    {
        this.BorrowedItems.Remove(item);
    }

    /// <summary>
    /// Logs record after borrower borrows an item
    /// </summary>
    /// <param name="record">Record from transaction</param>
    public void LogRecord(CheckoutRecord record)
    {
        this.BorrowHistory.Add(record);
    }
}