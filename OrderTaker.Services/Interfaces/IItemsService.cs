using OrderTakerApi.Contracts;

namespace OrderTakerServices.Interfaces;

public interface IItemsService
{
    public IEnumerable<ItemResponseContract> GetAllItems();
}