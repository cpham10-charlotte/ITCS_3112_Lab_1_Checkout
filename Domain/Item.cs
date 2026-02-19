using ITCS_3112_Lab_1_Checkout.Services;

namespace ITCS_3112_Lab_1_Checkout.Domain;

public class Item
{
    private string Id { get; init; }
    public string Name { get; set; }
    public CategoryEnum Category { get; private set; }
    public StatusEnum Status { get; private set; }
    public string Description { get; set; }
    public ConditionEnum Condition { get; private set; }
    private Policy Policy { get; set; }

    public Item(string id, string name, CategoryEnum category, StatusEnum status, ConditionEnum condition, Policy policy)
    {
        this.Id = id;
        this.Name = name;
        this.Category = category;
        this.Status = status;
        this.Condition = condition;
        this.Policy = policy;
    }
}