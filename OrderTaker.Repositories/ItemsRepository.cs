using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using OrderTakerRepositories.Entities;
using OrderTakerRepositories.Interfaces;
using OrderTakerRepositories.Options;

namespace OrderTakerRepositories;

public class ItemsRepository(IOptions<OrderTakerOptions> options) : IItemsRepository
{
    public IEnumerable<ItemEntity> GetAllItems()
    {
        const string query = "SELECT * FROM Items;";
        using var connection = new SqlConnection(options.Value.ConnectionString);
        var items = connection.Query<ItemEntity>(query);
        return items;
    }
}