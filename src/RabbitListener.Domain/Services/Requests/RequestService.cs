using RabbitListener.Domain.Contracts.Interfaces;
using RabbitListener.Domain.Contracts.Models;

namespace RabbitListener.Application.Infrastructure.Requests
{
    public class RequestService : IRequestService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        public RequestService(ILogger logger,
                            IHttpClientFactory httpClientFactory
                            )
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task Head(string url)
        {
            try
            {
                var res = await _httpClient.SendAsync(
                    new HttpRequestMessage(HttpMethod.Head, url));

                await _logger.Log(new LogObject
                {
                    ServiceName = "RabbitListener",
                    Url = url,
                    StatusCode = res.StatusCode.ToString(),
                });

            }
            catch (Exception e)
            {
                await _logger.Log(new LogObject
                {
                    ServiceName = "RabbitListener",
                    Url = url,
                    StatusCode = e.Message,
                });
            }

        }

    }
}
