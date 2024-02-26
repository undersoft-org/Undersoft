using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="Workspace"/>.
/// </summary>
public class WorkspaceTests
{
    private Workspace _testClass;
    private IFixture _fixture;
    private WorkAspect _aspect;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Workspace"/>.
    /// </summary>
    public WorkspaceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._aspect = _fixture.Create<WorkAspect>();
        this._testClass = _fixture.Create<Workspace>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Workspace(this._aspect);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the aspect parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullAspect()
    {
        FluentActions.Invoking(() => new Workspace(default(WorkAspect))).Should().Throw<ArgumentNullException>().WithParameterName("aspect");
    }

    /// <summary>
    /// Checks that the Close method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClose()
    {
        // Arrange
        var SafeClose = _fixture.Create<bool>();

        // Act
        this._testClass.Close(SafeClose);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Allocate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAllocate()
    {
        // Arrange
        var workersCount = _fixture.Create<int>();

        // Act
        var result = this._testClass.Allocate(workersCount);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Allocate maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AllocatePerformsMapping()
    {
        // Arrange
        var workersCount = _fixture.Create<int>();

        // Act
        var result = this._testClass.Allocate(workersCount);

        // Assert
        result.WorkersCount.Should().Be(workersCount);
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRun()
    {
        // Arrange
        var work = _fixture.Create<WorkItem>();

        // Act
        this._testClass.Run(work);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the work parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithNullWork()
    {
        FluentActions.Invoking(() => this._testClass.Run(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("work");
    }

    /// <summary>
    /// Checks that the Reset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReset()
    {
        // Arrange
        var workersCount = _fixture.Create<int>();

        // Act
        this._testClass.Reset(workersCount);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Activate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallActivate()
    {
        // Act
        this._testClass.Activate();

        // Assert
        Assert.Fail("Create or modify test");
    }
}