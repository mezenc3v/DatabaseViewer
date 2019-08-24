using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DataBaseViewer.Configuration
{
    public class DatabaseSettings
    {
        private System.Configuration.Configuration Config { get; }

        public IEnumerable<ConnectionStringSettings> ConnectionStrings => Config.ConnectionStrings.ConnectionStrings.Cast<ConnectionStringSettings>();

        public DatabaseSettings()
        {
            Config = GetConfig();
        }

        private static System.Configuration.Configuration GetConfig()
        {
            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var location = new Uri(executingAssembly.CodeBase).LocalPath;
            return ConfigurationManager.OpenExeConfiguration(location);
        }
    }
}