using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;

namespace RoraimaProject.Config
{
    public class LoggerConfiguration : BaseConfiguration
	{
		public LoggerConfiguration(IConfiguration configuration) : base(configuration)
		{

		}

		public string PathToLog
		{
			get
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					return _configuration.GetValue<string>("Logging:PathToLogWindows");
				}
				return _configuration.GetValue<string>("Logging:PathToLogLinux");
			}
		}

		public LogLevel LogLevel
		{
			get
			{
				return Enum.TryParse(_configuration.GetValue<string>("Logging:LogLevel:Default"), out LogLevel logLevel) ?
						logLevel : LogLevel.Information;
			}
		}
	}
}
