using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;
using Undersoft.SDK.Workflows.Notes;

namespace Undersoft.SDK.UnitTests.Workflows.Notes;

/// <summary>
/// Unit tests for the type <see cref="WorkNoteEvokers"/>.
/// </summary>
public class WorkNoteEvokersTests
{
    private WorkNoteEvokers _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkNoteEvokers"/>.
    /// </summary>
    public WorkNoteEvokersTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<WorkNoteEvokers>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkNoteEvokers();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithObjectives()
    {
        // Arrange
        var objectives = _fixture.Create<IEnumerable<WorkItem>>();

        // Act
        var result = this._testClass.Contains(objectives);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the objectives parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithObjectivesWithNullObjectives()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(IEnumerable<WorkItem>))).Should().Throw<ArgumentNullException>().WithParameterName("objectives");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithRelayNames()
    {
        // Arrange
        var relayNames = _fixture.Create<IEnumerable<string>>();

        // Act
        var result = this._testClass.Contains(relayNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the relayNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithRelayNamesWithNullRelayNames()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(IEnumerable<string>))).Should().Throw<ArgumentNullException>().WithParameterName("relayNames");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForString()
    {
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<WorkNoteEvoker>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForWorkItem()
    {
        this._testClass[_fixture.Create<WorkItem>()].Should().BeAssignableTo<WorkNoteEvoker>();
        Assert.Fail("Create or modify test");
    }
}