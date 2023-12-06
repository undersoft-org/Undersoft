using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Undersoft.IDP.Admin.IntegrationTests.Base;
using Undersoft.IDP.Admin.UI.Configuration.Constants;
using Xunit;

namespace Undersoft.IDP.Admin.IntegrationTests
{
    public class HomeControllerTests : BaseClassFixture
    {
        public HomeControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ReturnSuccessWithAdminRole()
        {
            SetupAdminClaimsViaHeaders();

            // Act
            var response = await Client.GetAsync("/home/index");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnRedirectWithoutAdminRole()
        {
            //Remove
            Client.DefaultRequestHeaders.Clear();

            // Act
            var response = await Client.GetAsync("/home/index");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            //The redirect to login
            response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
        }
    }
}