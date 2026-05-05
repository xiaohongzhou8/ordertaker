using OrderTakerRepositories.Entities;

namespace OrderTakerRepositories.Interfaces;

public interface IItemsRepository
{
    public IEnumerable<ItemEntity> GetAllItems();
}