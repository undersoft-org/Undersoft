using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Undersoft.IDP.Admin.Api.Configuration.Test;
using Undersoft.IDP.Admin.Api.IntegrationTests.Base;
using Undersoft.IDP.Admin.Api.IntegrationTests.Common;
using Xunit;

namespace Undersoft.IDP.Admin.Api.IntegrationTests
{
    public class ClientsControllerTests : BaseClassFixture
    {
        public ClientsControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetClientsAsAdmin()
        {
            SetupAdminClaimsViaHeaders();

            var response = await Client.GetAsync("api/clients");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetClientsWithoutPermissions()
        {
            Client.DefaultRequestHeaders.Clear();

            var response = await Client.GetAsync("api/clients");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            //The redirect to login
            response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
        }
    }
}
