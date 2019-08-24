using System;

namespace DatabaseViewer.Data
{
    public class ColumnMap
    {
        public string ColumnType { get; set; }
        public string ColumnName { get; set; }

        public ColumnMap(string columnName, string columnType)
        {
            ColumnName = columnName ?? throw new ArgumentNullException(nameof(columnName));
            ColumnType = columnType ?? throw new ArgumentNullException(nameof(columnType));
        }
    }
}