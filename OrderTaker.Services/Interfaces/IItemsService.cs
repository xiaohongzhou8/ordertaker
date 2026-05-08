using OrderTakerApi.Contracts;

namespace OrderTakerServices.Interfaces;

public interface IItemsService
{
    public Task<IEnumerable<ItemResponseContract>> GetAllItemsAsync();
}