using Microsoft.Extensions.DependencyInjection;
using RabbitListener.Infrastructure.Extensions;


var _serviceProvider = ServiceCollectionExtensions
    .AddDependencies(new ServiceCollection())
    .BuildServiceProvider();


var _RabbitMQService = _serviceProvider.GetRequiredService<RabbitMQService>();
_RabbitMQService.AddQueues();
