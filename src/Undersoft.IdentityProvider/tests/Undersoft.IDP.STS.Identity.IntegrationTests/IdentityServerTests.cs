using System.Threading.Tasks;
using FluentAssertions;
using IdentityModel.Client;
using Undersoft.IDP.STS.Identity.IntegrationTests.Base;
using Xunit;

namespace Undersoft.IDP.STS.Identity.IntegrationTests
{
    public class IdentityServerTests : BaseClassFixture
    {
        public IdentityServerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task CanShowDiscoveryEndpoint()
        {
            var disco = await Client.GetDiscoveryDocumentAsync("http://localhost");

            disco.Should().NotBeNull();
            disco.IsError.Should().Be(false);

            disco.KeySet.Keys.Count.Should().Be(1);
        }
    }
}
