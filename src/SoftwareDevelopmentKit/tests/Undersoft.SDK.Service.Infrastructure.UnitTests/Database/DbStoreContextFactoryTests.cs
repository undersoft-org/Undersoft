using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Store;
using TContext = Microsoft.EntityFrameworkCore.DbContext;
using TSourceProvider = Undersoft.SDK.Service.ServiceSourceProviderConfiguration;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="DbStoreContextFactory"/>.
/// </summary>
[TestClass]
public class DbStoreContextFactory_2Tests
{
    private DbStoreContextFactory<TContext, TSourceProvider> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbStoreContextFactory"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DbStoreContextFactory<TContext, TSourceProvider>>();
    }

    /// <summary>
    /// Checks that the CreateDbContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateDbContextWithArgs()
    {
        // Arrange
        var args = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.CreateDbContext(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateDbContext method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateDbContextWithArgsWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.CreateDbContext(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the CreateDbContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateDbContextWithNoParameters()
    {
        // Act
        var result = this._testClass.CreateDbContext();

        // Assert
        Assert.Fail("Create or modify test");
    }
}