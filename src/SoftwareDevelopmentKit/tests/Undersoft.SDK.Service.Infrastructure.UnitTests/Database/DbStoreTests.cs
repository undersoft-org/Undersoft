using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.Database;
using TContext = Microsoft.EntityFrameworkCore.DbContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database;

/// <summary>
/// Unit tests for the type <see cref="DbStore"/>.
/// </summary>
[TestClass]
public partial class DbStore_2Tests
{
    private class TestDbStore : DbStore<TStore, TContext>
    {
        public TestDbStore(DbContextOptions<TContext> options) : base(options)
        {
        }

        public void PublicOnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    private TestDbStore _testClass;
    private IFixture _fixture;
    private DbContextOptions<TContext> _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbStore"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<DbContextOptions<TContext>>();
        this._testClass = _fixture.Create<TestDbStore>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestDbStore(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestDbStore(default(DbContextOptions<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the PublicOnModelCreating method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnModelCreating()
    {
        // Arrange
        var modelBuilder = _fixture.Create<ModelBuilder>();

        // Act
        this._testClass.PublicOnModelCreating(modelBuilder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnModelCreating method throws when the modelBuilder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnModelCreatingWithNullModelBuilder()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnModelCreating(default(ModelBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
    }
}