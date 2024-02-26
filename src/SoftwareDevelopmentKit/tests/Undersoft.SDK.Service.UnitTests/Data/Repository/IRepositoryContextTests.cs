using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="DbContextConfigurationSnapshot"/>.
/// </summary>
public class DbContextConfigurationSnapshotTests
{
    private DbContextConfigurationSnapshot _testClass;
    private IFixture _fixture;
    private bool? _autoDetectChangesEnabled;
    private QueryTrackingBehavior? _queryTrackingBehavior;
    private AutoTransactionBehavior _autoTransactionsBehaviour;
    private bool? _lazyLoadingEnabled;
    private CascadeTiming? _cascadeDeleteTiming;
    private CascadeTiming? _deleteOrphansTiming;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbContextConfigurationSnapshot"/>.
    /// </summary>
    public DbContextConfigurationSnapshotTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._autoDetectChangesEnabled = _fixture.Create<bool?>();
        this._queryTrackingBehavior = _fixture.Create<QueryTrackingBehavior?>();
        this._autoTransactionsBehaviour = _fixture.Create<AutoTransactionBehavior>();
        this._lazyLoadingEnabled = _fixture.Create<bool?>();
        this._cascadeDeleteTiming = _fixture.Create<CascadeTiming?>();
        this._deleteOrphansTiming = _fixture.Create<CascadeTiming?>();
        this._testClass = _fixture.Create<DbContextConfigurationSnapshot>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DbContextConfigurationSnapshot(this._autoDetectChangesEnabled, this._queryTrackingBehavior, this._autoTransactionsBehaviour, this._lazyLoadingEnabled, this._cascadeDeleteTiming, this._deleteOrphansTiming);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the AutoTransactionBehavior property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAutoTransactionBehavior()
    {
        // Assert
        this._testClass.AutoTransactionBehavior.As<object>().Should().BeAssignableTo<AutoTransactionBehavior>();

        Assert.Fail("Create or modify test");
    }
}