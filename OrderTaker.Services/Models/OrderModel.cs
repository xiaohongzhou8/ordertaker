namespace OrderTakerServices.Models;

public class OrderModel
{
    public int Id { get; set; }
    public string OrderName { get; set; } = "no name";
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public Dictionary<ItemModel, int> Items { get; set; } = new();
}