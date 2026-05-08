namespace OrderTakerRepositories.Entities;

public class ItemEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}