namespace OrderTakerServices.Models;

public class ItemModel
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}