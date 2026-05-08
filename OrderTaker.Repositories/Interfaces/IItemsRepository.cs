using OrderTakerRepositories.Entities;

namespace OrderTakerRepositories.Interfaces;

public interface IItemsRepository
{
    public Task<IEnumerable<ItemEntity>> GetAllItemsAsync();
    public Task<ItemEntity> CreateItemAsync(ItemEntity item);
}