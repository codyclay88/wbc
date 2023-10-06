using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FoodPantry.Tests.Shared;

public abstract class SchemaTestsBase<TContext> : IAsyncLifetime where TContext : DbContext
{
    protected readonly TContext DbContext;
    private readonly string _schemaName;
    private readonly string _tableName;
    private DatabaseSchemaTestHelper? _tablesSchema;
    private DatabaseSchemaTestHelper? _columnsSchema;
    
    protected SchemaTestsBase(TContext? dbContext, string tableName, string schemaName = "public")
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _tableName = tableName;
        _schemaName = schemaName;
    }
    
    protected void AssertTableExists()
    {
        _tablesSchema!.AssertTableExists(_tableName, _schemaName);
    }
    
    protected void AssertColumnExists(string columnName, string dataType)
    {
        _columnsSchema!.AssertColumnExists(columnName, dataType);
    }

    public async Task InitializeAsync()
    {
        _tablesSchema = await DatabaseHelpers.GetTablesSchemaAsync(DbContext);
        _columnsSchema = await DatabaseHelpers.GetColumnsSchemaAsync(DbContext, _tableName, _schemaName);
    }

    public Task DisposeAsync()
    {
        // No cleanup needed at the moment
        return Task.CompletedTask;
    }
}