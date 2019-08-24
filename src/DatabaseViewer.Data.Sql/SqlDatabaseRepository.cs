using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseViewer.Data.Sql
{
    public class SqlDatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public SqlDatabaseRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public DatabaseMap GetMetaOfAllTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tablesMeta = connection.GetSchema("Tables");
                var databaseMap = new DatabaseMap(tablesMeta.TableName);
                foreach (DataRow tableMeta in tablesMeta.Rows)
                {
                    var tableName = tableMeta["TABLE_NAME"].ToString();
                    var restrictionArr = new[] { connection.Database, null, tableName, null };

                    databaseMap.DatabaseName = tableName;
                    var tablesMetaList = new TableMap(tableName);
                    databaseMap.TableMaps.Add(tablesMetaList);

                    DataTable columns = connection.GetSchema("Columns", restrictionArr);
                    DataTable dataTypes = connection.GetSchema("DataTypes");
                    foreach (DataRow row in columns.Rows)
                    {
                        var colName = row["COLUMN_NAME"].ToString();
                        var typeShortName = row["DATA_TYPE"].ToString();

                        var typeFullName = dataTypes.Rows
                            .OfType<DataRow>()
                            .FirstOrDefault(p => p["TypeName"].ToString() == typeShortName)
                            ?["DataType"].ToString() ?? typeShortName;

                        tablesMetaList.ColumnMaps.Add(new ColumnMap(colName, typeFullName));
                    }
                }
                return databaseMap;
            }
        }
    }
}