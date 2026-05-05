using OrderTakerApi.Contracts;
using OrderTakerRepositories.Entities;
using OrderTakerServices.Models;

namespace OrderTakerServices.Mappers;

public static class ItemsMapper
{
    public static ItemResponseContract ToContract(ItemModel item)
    {
        return new ItemResponseContract
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
        };
    }

    public static ItemModel ToModel(ItemEntity item)
    {
        return new ItemModel
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
        };
    }
}