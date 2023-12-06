using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Undersoft.IDP.STS.Identity.IntegrationTests.Base
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
    }
}