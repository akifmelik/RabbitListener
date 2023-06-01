using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using RabbitListener.Infrastructure.Extensions;

namespace Infrastructure.UnitTests.Services
{
    [TestFixture]
    public class ServiceCollectionExtensionsTests
    {
        private IServiceCollection _serviceCollection;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new Mock<IServiceCollection>().Object;
        }

        [Test]
        public void Dependencies_IsUp()
        {
            try
            {
                _serviceCollection.AddDependencies();
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }
    }
}