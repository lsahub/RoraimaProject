using Microsoft.Extensions.Configuration;

namespace RoraimaProject.Config
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public class RoraimaConfiguration : BaseConfiguration
	{
		public LoggerConfiguration LoggerConfiguration { get; }

		public RoraimaConfiguration(IConfiguration configuration) : base(configuration)
		{
			LoggerConfiguration = new LoggerConfiguration(configuration);
		}

		public string RoraimaDBConnectionString
		{
			get
			{
				return _configuration.GetConnectionString("RoraimaDBConnection");
			}
		}
	}
}
