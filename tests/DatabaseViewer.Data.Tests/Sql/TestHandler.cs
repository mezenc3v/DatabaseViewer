using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace DatabaseViewer.Data.Tests.Sql
{
	[SetUpFixture]
	public class TestHandler
	{
		/// <summary>
		/// Is called by the test runtime when the test environment loads
		/// </summary>
		[OneTimeSetUp]
		public static void AssemblyInit()
		{
			Trace.TraceInformation("Assembly initializing is starting");
			var file = GetScriptFileName();
			Trace.TraceInformation($"starting script {file}...");
			if (file == null)
			{
				throw new FileNotFoundException("Could not locale database deploy script");
			}

			var procInfo = new ProcessStartInfo(file.FullName)
			{
				WorkingDirectory = file.Directory.FullName,
				WindowStyle = ProcessWindowStyle.Normal
			};
			//var proc = Process.Start(procInfo);
			//proc?.WaitForExit();
		}

		/// <summary>
		/// Searches for the database project and retrieves its full project filename if found
		/// </summary>
		/// <returns>The filename or <c>null</c> if the file wasn't found</returns>
		private static FileInfo GetScriptFileName()
		{
			const string scriptDir = ".shared";
			const string scriptName = "DatabaseDeployScript";
			try
			{
				var dir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
				if (dir == null)
				{
					return null;
				}

				while (dir.Parent != null && !dir.GetDirectories(scriptDir).Any())
				{
					dir = dir.Parent;
					if (dir == null)
					{
						return null;
					}
				}
				dir = dir.GetDirectories(scriptDir).First();
				var fileInfo = dir.GetFiles(ConfigurationManager.AppSettings[scriptName]).FirstOrDefault();
				return fileInfo;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}