using System;
using Aga.Controls.Tree;
using DatabaseViewer.Data;

namespace DatabaseViewer.WinForms.Model
{
    public class ColumnView : Node
    {
        private readonly ColumnMap _map;

        public ColumnView(ColumnMap map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public string ColumnName => _map.ColumnName;
        public string TypeName => _map.ColumnType;
    }
}