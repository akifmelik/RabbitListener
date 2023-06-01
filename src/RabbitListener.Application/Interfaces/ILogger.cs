
using RabbitListener.Domain.Contracts.Models;

namespace RabbitListener.Domain.Contracts.Interfaces
{
    public interface ILogger
    {
        Task Log(LogObject logObject);
    }
}
