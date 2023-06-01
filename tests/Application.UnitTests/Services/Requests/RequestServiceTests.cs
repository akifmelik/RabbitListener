using Moq;
using NUnit.Framework;
using RabbitListener.Application.Infrastructure.Requests;
using RabbitListener.Domain.Contracts.Interfaces;


namespace Application.UnitTests.Services.Requests
{
    [TestFixture]
    public class RequestServiceTests
    {
        private Mock<IRequestService> _requestService ;

        [SetUp]
        public void Setup()
        {
            _requestService = new Mock<IRequestService>();
        }

        [Test]
        [TestCaseSource(nameof(GetUrls))]
        public async Task Head_Request_IsSuccess(string url)
        {
            try
            {
                await _requestService.Object.Head(url);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        public static IEnumerable<string> GetUrls()
        {
            yield return "https://www.akakce.com";
            yield return "https://www.google.com.tr/";
            yield return "https://www.amazon.com";

        }

    }
}