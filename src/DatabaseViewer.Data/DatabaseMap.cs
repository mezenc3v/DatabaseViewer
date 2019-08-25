using System;
using System.Collections.Generic;

namespace DatabaseViewer.Data
{
	public class DatabaseMap
	{
		public string DatabaseName { get; set; }
		public List<TableMap> TableMaps { get; set; }

		public DatabaseMap(string databaseName)
		{
			DatabaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
			TableMaps = new List<TableMap>();
		}
	}
}