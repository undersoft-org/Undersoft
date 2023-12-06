using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Undersoft.IDP.Admin.Api.IntegrationTests.Base;
using Undersoft.IDP.Admin.Api.IntegrationTests.Common;
using Xunit;

namespace Undersoft.IDP.Admin.Api.IntegrationTests
{
    public class ApiResourcesControllerTests : BaseClassFixture
    {
        public ApiResourcesControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetApiResourcesAsAdmin()
        {
            SetupAdminClaimsViaHeaders();

            var response = await Client.GetAsync("api/apiresources");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetApiResourcesWithoutPermissions()
        {
            Client.DefaultRequestHeaders.Clear();

            var response = await Client.GetAsync("api/apiresources");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            //The redirect to login
            response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
        }
    }
}