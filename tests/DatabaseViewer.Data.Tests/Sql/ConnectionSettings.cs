using System;
using System.Configuration;
using System.Linq;

namespace DatabaseViewer.Data.Tests.Sql
{
	public class ConnectionSettings
	{
		private Configuration Config { get; }

		public string ConnectionString
		{
			get
			{
				var connString = Config.ConnectionStrings.ConnectionStrings
					.Cast<ConnectionStringSettings>()
					.FirstOrDefault()?.ConnectionString;

				if (connString == null)
				{
					throw new Exception(nameof(Config.ConnectionStrings.ConnectionStrings));
				}
				return connString;
			}
		}

		public ConnectionSettings()
		{
			Config = GetConfig();
		}

		private static Configuration GetConfig()
		{
			var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			var location = new Uri(executingAssembly.CodeBase).LocalPath;
			return ConfigurationManager.OpenExeConfiguration(location);
		}
	}
}