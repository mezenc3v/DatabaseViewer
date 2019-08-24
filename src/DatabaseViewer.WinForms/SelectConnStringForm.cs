using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using DataBaseViewer.Configuration;

namespace DatabaseViewer.WinForms
{
    public partial class SelectConnStringForm : Form
    {
        private readonly DatabaseSettings _settings = new DatabaseSettings();

        public string ConnectionString { get; private set; }
        public SelectConnStringForm()
        {
            InitializeComponent();
            connStrCb.DataSource = _settings.ConnectionStrings.ToList();
            connStrCb.DisplayMember = "Name";
            CenterToParent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            var connString = connStrCb.SelectedItem as ConnectionStringSettings;
            ConnectionString = connString?.ConnectionString;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connectBtn.Enabled = _settings.ConnectionStrings.Any();
        }
    }
}
