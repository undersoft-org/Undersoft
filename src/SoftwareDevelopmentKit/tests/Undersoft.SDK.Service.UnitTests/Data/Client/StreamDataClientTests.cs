using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Client;

/// <summary>
/// Unit tests for the type <see cref="StreamDataClient"/>.
/// </summary>
public partial class StreamDataClient_1Tests
{
    private StreamDataClient<TStore> _testClass;
    private IFixture _fixture;
    private Uri _serviceUri;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StreamDataClient"/>.
    /// </summary>
    public StreamDataClient_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceUri = _fixture.Create<Uri>();
        this._testClass = _fixture.Create<StreamDataClient<TStore>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new StreamDataClient<TStore>(this._serviceUri);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceUri parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceUri()
    {
        FluentActions.Invoking(() => new StreamDataClient<TStore>(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceUri");
    }
}