using ITCS_3112_Lab_1_Checkout.Contracts;

namespace ITCS_3112_Lab_1_Checkout.Services;

public class Clock : IClock
{
    public DateTime Today()
    {
        return DateTime.Today;
    }
}