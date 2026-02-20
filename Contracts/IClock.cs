namespace ITCS_3112_Lab_1_Checkout.Contracts;

/// <summary>
/// Provides current date.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets today's date.
    /// </summary>
    /// <returns>Current date.</returns>
    DateTime Today();
}