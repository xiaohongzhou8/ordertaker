using OrderTakerApi.Contracts;
using OrderTakerRepositories.Interfaces;
using OrderTakerServices.Interfaces;
using OrderTakerServices.Mappers;

namespace OrderTakerServices.Services;

public class ItemsService(IItemsRepository itemsRepository) : IItemsService
{
    public IEnumerable<ItemResponseContract> GetAllItems()
    {
        var items = itemsRepository.GetAllItems()
            .Select(item => ItemsMapper.ToContract(ItemsMapper.ToModel(item)));
        return items;
    }
}