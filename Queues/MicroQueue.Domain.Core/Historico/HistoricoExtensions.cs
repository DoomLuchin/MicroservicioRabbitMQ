using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroQueue.Domain.Core.Historico
{
    public static class HistoricoExtensions
    {
        public static void AddHistoricoClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(HistoricoServices.ApiLogsAlliance, config =>
            {
                HistoricoSettings? settings = configuration.GetSection("HistoricoSettings").Get<HistoricoSettings>();

                var address = $"{settings?.URL}";
                config.BaseAddress = new Uri(address);
                config.DefaultRequestHeaders.Add(HistoricoServices.HeaderLogsAlliance, settings?.ApiKey);
            });
        }
    }
}
