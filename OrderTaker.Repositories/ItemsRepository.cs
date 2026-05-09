using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using OrderTakerRepositories.Entities;
using OrderTakerRepositories.Interfaces;
using OrderTakerRepositories.Options;

namespace OrderTakerRepositories;

public class ItemsRepository(IOptions<ConnectionStrings> options) : IItemsRepository
{
    private readonly ConnectionStrings _connectionStrings = options.Value;

    public async Task<ItemEntity> CreateItemAsync(ItemEntity item)
    {
        const string query = "INSERT INTO Items (Id, Name, Price) VALUES (@Id, @Name, @Price);";
        await using var connection = new SqliteConnection(_connectionStrings.DefaultConnection);
        connection.Open();
        await connection.ExecuteAsync(query, item);
        return item;
    }

    public async Task<IEnumerable<ItemEntity>> GetAllItemsAsync()
    {
        const string query = "SELECT * FROM Items;";
        await using var connection = new SqliteConnection(_connectionStrings.DefaultConnection);
        connection.Open();
        var items = await connection.QueryAsync<ItemEntity>(query);
        return items;
    }
}