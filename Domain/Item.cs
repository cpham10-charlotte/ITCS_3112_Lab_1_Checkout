using ITCS_3112_Lab_1_Checkout.Services;

namespace ITCS_3112_Lab_1_Checkout.Domain;

/// <summary>
/// Items that the system holds and the borrowers interact with
/// </summary>
public class Item
{
    public string Id { get; init; }
    public string Name { get; set; }
    public CategoryEnum Category { get; set; }
    public StatusEnum Status { get; set; }
    public string Description { get; set; }
    public ConditionEnum Condition { get; set; }
    public Policy Policy { get; set; }

    public Item(string id, string name, CategoryEnum category, StatusEnum status, ConditionEnum condition)
    {
        this.Id = id;
        this.Name = name;
        this.Category = category;
        this.Status = status;
        this.Condition = condition;
    }

    public override string ToString()
    {
        return $"{this.Id}: {this.Name}, {this.Category}, {this.Status}, {this.Condition}";
    }
}