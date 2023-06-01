using Microsoft.Extensions.DependencyInjection;
using RabbitListener.Application.Infrastructure.Requests;
using RabbitListener.Domain.Contracts.Interfaces;
using RabbitListener.Infrastructure.Services.Log;

namespace RabbitListener.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                    .AddScoped<IRequestService, RequestService>()
                    .AddScoped<ILogger, JsonLogger>()
                    .AddSingleton<RabbitMQService>()                   
                    .AddHttpClient();
        }
    }
}


