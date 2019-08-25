using System.Collections.Generic;
using System.Linq;
using DatabaseViewer.Data.Sql;
using NUnit.Framework;

namespace DatabaseViewer.Data.Tests.Sql
{
	[TestFixture]
	public class DatabaseRepositoryTests
	{
		/// <summary>
		/// Receives metadata from a test database and compares the received values
		/// </summary>
		[Test]
		public void ShouldBeReturnAllTablesAndColumns()
		{
			//arrange
			const string connectionString = "";
			var testData = GetTestDatabaseMap();
			var repo = new SqlDatabaseRepository(connectionString);
			//act
			var databaseMeta = repo.GetMetaOfAllTables();
			//asserts
			Assert.AreEqual(testData.DatabaseName, databaseMeta.DatabaseName);
			AssertsTables(testData.TableMaps, databaseMeta.TableMaps);
		}

		/// <summary>
		/// Сompares table data
		/// </summary>
		/// <param name="source">source tables</param>
		/// <param name="target">target tables</param>
		private static void AssertsTables(IEnumerable<TableMap> source, IEnumerable<TableMap> target)
		{
			var orderedSource = source.OrderBy(s => s.TableName).ToArray();
			var orderedTarget = target.OrderBy(t => t.TableName).ToArray();

			Assert.AreEqual(orderedSource.Length, orderedTarget.Length, "The number of tables in the database does not match");

			for (int i = 0; i < orderedSource.Length; i++)
			{
				AssertsColumns(orderedSource[i].ColumnMaps, orderedTarget[i].ColumnMaps);
			}
		}

		/// <summary>
		/// Сompares table column data
		/// </summary>
		/// <param name="source">source columns</param>
		/// <param name="target">target columns</param>
		private static void AssertsColumns(IEnumerable<ColumnMap> source, IEnumerable<ColumnMap> target)
		{
			var orderedSource = source.OrderBy(s => s.ColumnName).ThenBy(s => s.ColumnType).ToArray();
			var orderedTarget = target.OrderBy(t => t.ColumnName).ThenBy(t => t.ColumnType).ToArray();

			Assert.AreEqual(orderedSource.Length, orderedTarget.Length, "The number of columns in the table does not match");

			for (int i = 0; i < orderedSource.Length; i++)
			{
				AssertsColumn(orderedSource[i], orderedTarget[i]);
			}
		}

		/// <summary>
		/// Сompares column data
		/// </summary>
		/// <param name="source">source column</param>
		/// <param name="target">target column</param>
		private static void AssertsColumn(ColumnMap source, ColumnMap target)
		{
			Assert.AreEqual(source.ColumnName, target.ColumnName);
			Assert.AreEqual(source.ColumnType, target.ColumnType);
		}

		private static DatabaseMap GetTestDatabaseMap()
		{
			return new DatabaseMap("")
			{
				TableMaps = new List<TableMap>
				{
					new TableMap("")
					{
						ColumnMaps = new List<ColumnMap>
						{
							new ColumnMap("", "")
						}
					},
				}
			};
		}
	}
}