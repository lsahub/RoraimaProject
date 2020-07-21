using Microsoft.Extensions.Configuration;


namespace RoraimaProject.Config
{
    public abstract class BaseConfiguration
	{
		protected IConfiguration _configuration { get; }


		public BaseConfiguration(IConfiguration configuration)
		{
			_configuration = configuration;
		} 
	}
}
