﻿using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Undersoft.IDP.Admin.IntegrationTests.Base;
using Undersoft.IDP.Admin.IntegrationTests.Common;
using Undersoft.IDP.Admin.UI.Configuration.Constants;
using Xunit;

namespace Undersoft.IDP.Admin.IntegrationTests
{
    public class GrantControllerTests : BaseClassFixture
    {
        public GrantControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ReturnSuccessWithAdminRole()
        {
            SetupAdminClaimsViaHeaders();

            foreach (var route in RoutesConstants.GetGrantRoutes())
            {
                // Act
                var response = await Client.GetAsync($"/Grant/{route}");

                // Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task ReturnRedirectWithoutAdminRole()
        {
            //Remove
            Client.DefaultRequestHeaders.Clear();

            foreach (var route in RoutesConstants.GetGrantRoutes())
            {
                // Act
                var response = await Client.GetAsync($"/Grant/{route}");

                // Assert           
                response.StatusCode.Should().Be(HttpStatusCode.Redirect);

                //The redirect to login
                response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
            }
        }
    }
}
