using OrderTakerApi.Contracts;
using OrderTakerRepositories.Interfaces;
using OrderTakerServices.Interfaces;
using OrderTakerServices.Mappers;

namespace OrderTakerServices.Services;

public class ItemsService(IItemsRepository itemsRepository) : IItemsService
{
    public async Task<IEnumerable<ItemResponseContract>> GetAllItemsAsync()
    {
        var items = await itemsRepository.GetAllItemsAsync();
        return items.Select(item => ItemsMapper.ToContract(ItemsMapper.ToModel(item)));
    }
}