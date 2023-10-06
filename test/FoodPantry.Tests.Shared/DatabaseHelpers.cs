using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FoodPantry.Tests.Shared;

internal static class DatabaseHelpers
{
    public static async Task<DatabaseSchemaTestHelper> GetTablesSchemaAsync(DbContext dbContext, string collectionName = "Tables")
    {
        var connection = await GetOpenConnectionAsync(dbContext);
        
        var schema = await connection.GetSchemaAsync(collectionName);
        return new DatabaseSchemaTestHelper(schema);
    }
    
    public static async Task<DatabaseSchemaTestHelper> GetColumnsSchemaAsync(DbContext dbContext, string tableName, string schemaName = "public", string collectionName = "Columns")
    {
        var connection = await GetOpenConnectionAsync(dbContext);

        var schema = await connection.GetSchemaAsync(collectionName, new[] { null, schemaName, tableName, null});
        return new DatabaseSchemaTestHelper(schema);
    }

    private static async Task<DbConnection> GetOpenConnectionAsync(DbContext dbContext)
    {
        var connection = dbContext.Database.GetDbConnection();
        if(connection.State != ConnectionState.Open)
            await connection.OpenAsync();
        return connection;
    }
}