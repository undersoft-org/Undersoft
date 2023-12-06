using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Undersoft.IDP.STS.Identity.IntegrationTests.Base;
using Xunit;

namespace Undersoft.IDP.STS.Identity.IntegrationTests
{
    public class HomeControllerTests : BaseClassFixture
    {
        public HomeControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task EveryoneHasAccessToHomepage()
        {
            Client.DefaultRequestHeaders.Clear();

            // Act
            var response = await Client.GetAsync("/home/index");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}