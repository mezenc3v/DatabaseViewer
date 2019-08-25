using System;
using System.Linq;
using DataBaseViewer.Configuration;
using DatabaseViewer.Data;
using DatabaseViewer.Data.Sql;

namespace DatabaseViewer.Console
{
	class Program
	{
		private static readonly DatabaseSettings DatabaseSettings = new DatabaseSettings();
		static void Main(string[] args)
		{
			var connStr = GetConnectionString();
			if (!string.IsNullOrWhiteSpace(connStr))
			{
				var repo = new SqlDatabaseRepository(connStr);
				var meta = repo.GetMetaOfAllTables();
				ShowDatabaseInfo(meta);
				System.Console.ReadKey();
			}
		}

		private static string GetConnectionString()
		{
			var connectionStrings = DatabaseSettings.ConnectionStrings.ToArray();
			System.Console.WriteLine("Select connection string:");
			int i = 1;
			foreach (var connectionStringSetting in connectionStrings)
			{
				System.Console.WriteLine($"{i}) {connectionStringSetting.Name}");
				i++;
			}

			var selectedNumber = (int)char.GetNumericValue(System.Console.ReadKey().KeyChar);

			return connectionStrings.Length >= selectedNumber && selectedNumber > 0
				? connectionStrings[selectedNumber - 1].ConnectionString
				: null;
		}

		private static void ShowDatabaseInfo(DatabaseMap meta)
		{
			System.Console.WriteLine("Database name: {0}", meta.DatabaseName);
			foreach (var tableMap in meta.TableMaps)
			{
				System.Console.WriteLine("----------------");
				System.Console.WriteLine("Table name: {0}", tableMap.TableName);
				foreach (var columnMap in tableMap.ColumnMaps)
				{
					System.Console.WriteLine("Column name: {0}, type: {1}", columnMap.ColumnName, columnMap.ColumnType);
				}
			}
			System.Console.WriteLine("----------------");
		}
	}
}
