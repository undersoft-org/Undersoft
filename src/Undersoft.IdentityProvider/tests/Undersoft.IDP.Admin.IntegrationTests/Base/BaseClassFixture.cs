using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.IDP.Admin.IntegrationTests.Common;
using Undersoft.IDP.Admin.UI.Configuration;
using Xunit;

namespace Undersoft.IDP.Admin.IntegrationTests.Base
{
    public class BaseClassFixture : IClassFixture<TestFixture>
    {
        protected readonly HttpClient Client;
        protected readonly TestServer TestServer;

        public BaseClassFixture(TestFixture fixture)
        {
            Client = fixture.Client;
            TestServer = fixture.TestServer;
        }

        protected virtual void SetupAdminClaimsViaHeaders()
        {
            using (var scope = TestServer.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<AdminConfiguration>();
                Client.SetAdminClaimsViaHeaders(configuration);
            }
        }
    }
}