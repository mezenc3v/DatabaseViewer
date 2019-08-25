using System;
using System.Collections.Generic;
using System.Linq;
using Aga.Controls.Tree;
using DatabaseViewer.Data;

namespace DatabaseViewer.WinForms.Model
{
	public class TableView : Node
	{
		private readonly TableMap _map;

		public TableView(TableMap map)
		{
			_map = map ?? throw new ArgumentNullException(nameof(map));
			ColumnViews = _map.ColumnMaps.Select(c => new ColumnView(c));
			foreach (var columnView in ColumnViews)
			{
				Nodes.Add(columnView);
			}
			Tag = _map.TableName;
		}

		public string TableName => _map.TableName;

		public IEnumerable<ColumnView> ColumnViews { get; }
	}
}