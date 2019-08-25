using System;
using System.Collections.Generic;

namespace DatabaseViewer.Data
{
	public class TableMap
	{
		public string TableName { get; set; }
		public List<ColumnMap> ColumnMaps { get; set; }

		public TableMap(string tableName)
		{
			TableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
			ColumnMaps = new List<ColumnMap>();
		}
	}
}