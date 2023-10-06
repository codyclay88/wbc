using System.Data;
using Xunit;
using Xunit.Sdk;

namespace FoodPantry.Tests.Shared;

internal class DatabaseSchemaTestHelper
{
    private readonly DataTable _schema; 
    
    public DatabaseSchemaTestHelper(DataTable schema)
    {
        _schema = schema;
    }
    
    public void AssertTableExists(string tableName, string schemaName = "public")
    {
        var table = _schema.AsEnumerable().FirstOrDefault(r => r["TABLE_NAME"].ToString() == tableName);
        
        if (table == null)
            throw new XunitException($"{tableName} does not exist in the database.");

        Assert.Equal(table["TABLE_SCHEMA"], (schemaName));
    }
    
    public void AssertColumnExists(string columnName, string dataType)
    {
        var column = _schema.AsEnumerable().FirstOrDefault(r => r["COLUMN_NAME"].ToString() == columnName);
        
        if (column == null)
            throw new XunitException($"{columnName} does not exist in the database.");
        
        Assert.Equal(column["COLUMN_NAME"], columnName);
        Assert.Equal(column["DATA_TYPE"], dataType);
    }
}