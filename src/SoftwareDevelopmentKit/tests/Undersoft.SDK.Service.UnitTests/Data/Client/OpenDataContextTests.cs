using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.OData.Edm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Remote;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Client;

/// <summary>
/// Unit tests for the type <see cref="OpenDataContext"/>.
/// </summary>
public partial class OpenDataContextTests
{
    private class TestOpenDataContext : OpenDataContext
    {
        public TestOpenDataContext(Uri serviceUri) : base(serviceUri)
        {
        }

        public IEdmModel PublicOnModelCreating(IEdmModel builder)
        {
            return base.OnModelCreating(builder);
        }
    }

    private TestOpenDataContext _testClass;
    private IFixture _fixture;
    private Uri _serviceUri;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenDataContext"/>.
    /// </summary>
    public OpenDataContextTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceUri = _fixture.Create<Uri>();
        this._testClass = _fixture.Create<TestOpenDataContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestOpenDataContext(this._serviceUri);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceUri parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceUri()
    {
        FluentActions.Invoking(() => new TestOpenDataContext(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceUri");
    }

    /// <summary>
    /// Checks that the CreateServiceModelAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCreateServiceModelAsync()
    {
        // Act
        var result = await this._testClass.CreateServiceModelAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateServiceModelSync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateServiceModelSync()
    {
        // Act
        var result = this._testClass.CreateServiceModelSync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddServiceModelAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddServiceModelAsync()
    {
        // Act
        var result = await this._testClass.AddServiceModelAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddServiceModelSync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddServiceModelSync()
    {
        // Act
        var result = this._testClass.AddServiceModelSync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServiceModel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServiceModel()
    {
        // Act
        var result = this._testClass.GetServiceModel();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnModelCreating method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnModelCreating()
    {
        // Arrange
        var builder = _fixture.Create<IEdmModel>();

        // Act
        var result = this._testClass.PublicOnModelCreating(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnModelCreating method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnModelCreatingWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnModelCreating(default(IEdmModel))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the CreateQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateQuery()
    {
        // Arrange
        var resourcePath = _fixture.Create<string>();
        var isComposable = _fixture.Create<bool>();

        // Act
        var result = this._testClass.CreateQuery<T>(resourcePath, isComposable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateQuery method throws when the resourcePath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateQueryWithInvalidResourcePath(string value)
    {
        FluentActions.Invoking(() => this._testClass.CreateQuery<T>(value, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("resourcePath");
    }

    /// <summary>
    /// Checks that the CreateQuery maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void CreateQueryPerformsMapping()
    {
        // Arrange
        var resourcePath = _fixture.Create<string>();
        var isComposable = _fixture.Create<bool>();

        // Act
        var result = this._testClass.CreateQuery<T>(resourcePath, isComposable);

        // Assert
        result.IsComposable.Should().Be(isComposable);
    }

    /// <summary>
    /// Checks that the SetAuthorizationHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetAuthorizationHeader()
    {
        // Arrange
        var securityString = _fixture.Create<string>();

        // Act
        this._testClass.SetAuthorizationHeader(securityString);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetAuthorizationHeader method throws when the securityString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetAuthorizationHeaderWithInvalidSecurityString(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetAuthorizationHeader(value)).Should().Throw<ArgumentNullException>().WithParameterName("securityString");
    }

    /// <summary>
    /// Checks that the Remotes property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRemotes()
    {
        // Arrange
        var testValue = _fixture.Create<Registry<RemoteRelation>>();

        // Act
        this._testClass.Remotes = testValue;

        // Assert
        this._testClass.Remotes.Should().BeSameAs(testValue);
    }
}