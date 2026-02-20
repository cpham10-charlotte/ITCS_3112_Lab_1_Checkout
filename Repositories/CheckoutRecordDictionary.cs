using ITCS_3112_Lab_1_Checkout.Domain;

namespace ITCS_3112_Lab_1_Checkout.Repositories;

public class CheckoutRecordDictionary
{
    public CheckoutRecordDictionary()
    {
        Dictionary<string, CheckoutRecord> records = new Dictionary<string, CheckoutRecord>();
    }
}