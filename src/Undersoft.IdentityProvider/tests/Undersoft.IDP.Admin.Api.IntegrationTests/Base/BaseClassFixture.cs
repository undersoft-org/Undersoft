using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.IDP.Admin.Api.Configuration;
using Undersoft.IDP.Admin.Api.Configuration.Test;
using Undersoft.IDP.Admin.Api.IntegrationTests.Common;
using Xunit;

namespace Undersoft.IDP.Admin.Api.IntegrationTests.Base
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
                var configuration = scope.ServiceProvider.GetRequiredService<AdminApiConfiguration>();
                Client.SetAdminClaimsViaHeaders(configuration);
            }
        }
    }
}