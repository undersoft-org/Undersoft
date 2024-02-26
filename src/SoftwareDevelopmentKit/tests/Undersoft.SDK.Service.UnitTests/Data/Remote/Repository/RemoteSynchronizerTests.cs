using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.OData.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Repository;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote.Repository;

/// <summary>
/// Unit tests for the type <see cref="RemoteSynchronizer"/>.
/// </summary>
public class RemoteSynchronizerTests
{
    private RemoteSynchronizer _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteSynchronizer"/>.
    /// </summary>
    public RemoteSynchronizerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RemoteSynchronizer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteSynchronizer();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the AddRepository method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRepository()
    {
        // Arrange
        var repository = _fixture.Create<IRepository>();

        // Act
        this._testClass.AddRepository(repository);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRepository method throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRepositoryWithNullRepository()
    {
        FluentActions.Invoking(() => this._testClass.AddRepository(default(IRepository))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the OnLinked method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnLinked()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var args = _fixture.Create<LoadCompletedEventArgs>();

        // Act
        this._testClass.OnLinked(sender, args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnLinked method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnLinkedWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.OnLinked(default(object), _fixture.Create<LoadCompletedEventArgs>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the OnLinked method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnLinkedWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.OnLinked(_fixture.Create<object>(), default(LoadCompletedEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the AcquireLinker method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquireLinker()
    {
        // Act
        this._testClass.AcquireLinker();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseLinker method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReleaseLinker()
    {
        // Act
        this._testClass.ReleaseLinker();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AcquireResult method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquireResult()
    {
        // Act
        this._testClass.AcquireResult();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseResult method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReleaseResult()
    {
        // Act
        this._testClass.ReleaseResult();

        // Assert
        Assert.Fail("Create or modify test");
    }
}