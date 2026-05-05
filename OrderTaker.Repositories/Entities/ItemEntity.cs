namespace OrderTakerRepositories.Entities;

public class ItemEntity
{
    public string Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}