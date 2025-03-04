using Application;

namespace Api.Conf
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration conf) => Ioc.AddApplicationServices(services, conf);
        
    }
}
