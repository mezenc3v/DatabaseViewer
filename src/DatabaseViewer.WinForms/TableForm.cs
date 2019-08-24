using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aga.Controls.Tree;
using Aga.Controls.Tree.NodeControls;
using DatabaseViewer.Data;
using DatabaseViewer.Data.Sql;
using DatabaseViewer.WinForms.Model;

namespace DatabaseViewer.WinForms
{
    public partial class TableForm : Form
    {
        private readonly SelectConnStringForm _connStringForm = new SelectConnStringForm();
        private readonly TreeModel _treeModel = new TreeModel();

        public TableForm()
        {
            InitializeComponent();
            CenterToParent();
            InitTree();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void ShowConnectionForm()
        {
            //circular form call
            while (true)
            {
                var dialogResult = _connStringForm.ShowDialog(this);
                if (dialogResult != DialogResult.OK)
                {
                    Close();
                    break;
                }

                if (string.IsNullOrWhiteSpace(_connStringForm.ConnectionString))
                {
                    MessageBox.Show("Connection string was not specified");
                }
                else
                {
                    var tableViews = LoadDatabaseMap(_connStringForm.ConnectionString);
                    UpdateTreeModel(tableViews);
                    break;
                }
            }
        }

        private void UpdateTreeModel(IEnumerable<TableView> views)
        {
            _treeModel.Nodes.Clear();
            foreach (var tableView in views)
            {
                _treeModel.Nodes.Add(tableView);
            }
        }

        private static IEnumerable<TableView> LoadDatabaseMap(string connectionString)
        {
            IDatabaseRepository repo = new SqlDatabaseRepository(connectionString);
            var databaseMap = repo.GetMetaOfAllTables();
            return databaseMap.TableMaps.Select(m => new TableView(m)).ToList();
        }

        private void InitTree()
        {
            tableTreeView.Model = _treeModel;
            tableTreeView.UseColumns = true;

            var tableCol = new TreeColumn("Table name", 150);
            var columnCol = new TreeColumn("Column Name", 150);
            var typeCol = new TreeColumn("Type name", 150);

            tableTreeView.Columns.Add(tableCol);
            tableTreeView.Columns.Add(columnCol);
            tableTreeView.Columns.Add(typeCol);

            tableTreeView.NodeControls.Add(new NodeTextBox
            {
                DataPropertyName = "TableName",
                ParentColumn = tableCol
            });
            tableTreeView.NodeControls.Add(new NodeTextBox
            {
                DataPropertyName = "ColumnName",
                ParentColumn = columnCol
            });
            tableTreeView.NodeControls.Add(new NodeTextBox
            {
                DataPropertyName = "TypeName",
                ParentColumn = typeCol
            });
        }
    }
}
