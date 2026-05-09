using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using OrderTakerRepositories.Options;

namespace OrderTaker.Data;

public class DbInit(IOptions<ConnectionStrings> options)
{
    private readonly ConnectionStrings _connectionStrings = options.Value;

    public void Init()
    {
        using var connection = new SqliteConnection(_connectionStrings.DefaultConnection);
        connection.Open();
        connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Items (
                Id TEXT NOT NULL PRIMARY KEY,
                Name TEXT NOT NULL,
                Price REAL NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Orders (
                OrderId INTEGER PRIMARY KEY AUTOINCREMENT,
                OrderName TEXT NOT NULL,
                OrderDateTime TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS ItemsOrders (
                OrderId INTEGER NOT NULL,
                ItemId TEXT NOT NULL,
                Amount INTEGER,

                PRIMARY KEY (OrderId, ItemId)
            );
        ");
    }
}