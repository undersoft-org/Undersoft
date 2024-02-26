using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="RepositoryOptions"/>.
/// </summary>
public class RepositoryOptionsTests
{
    private RepositoryOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryOptions"/>.
    /// </summary>
    public RepositoryOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RepositoryOptions>();
    }

    /// <summary>
    /// Checks that the Sources property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSources()
    {
        // Arrange
        var testValue = _fixture.Create<Dictionary<string, RepositorySourceOptions>>();

        // Act
        this._testClass.Sources = testValue;

        // Assert
        this._testClass.Sources.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Clients property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClients()
    {
        // Arrange
        var testValue = _fixture.Create<Dictionary<string, RepositoryClientOptions>>();

        // Act
        this._testClass.Clients = testValue;

        // Assert
        this._testClass.Clients.Should().BeSameAs(testValue);
    }
}