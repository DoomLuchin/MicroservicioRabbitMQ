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

                config.BaseAddress = new Uri($"{settings?.URL}");
                config.DefaultRequestHeaders.Add(HistoricoServices.HeaderLogsAlliance, settings?.ApiKey);
            });
        }
    }
}
