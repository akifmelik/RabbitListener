
namespace RabbitListener.Domain.Contracts.Models
{
    public class LogObject
    {
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string? StatusCode { get; set; }
    }
}
