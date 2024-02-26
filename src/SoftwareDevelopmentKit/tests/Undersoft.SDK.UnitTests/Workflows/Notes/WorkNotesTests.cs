using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows.Notes;

namespace Undersoft.SDK.UnitTests.Workflows.Notes;

/// <summary>
/// Unit tests for the type <see cref="WorkNotes"/>.
/// </summary>
public class WorkNotesTests
{
    private WorkNotes _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkNotes"/>.
    /// </summary>
    public WorkNotesTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<WorkNotes>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkNotes();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Send method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSend()
    {
        // Arrange
        var parametersList = _fixture.Create<WorkNote[]>();

        // Act
        this._testClass.Send(parametersList);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Send method throws when the parametersList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSendWithNullParametersList()
    {
        FluentActions.Invoking(() => this._testClass.Send(default(WorkNote[]))).Should().Throw<ArgumentNullException>().WithParameterName("parametersList");
    }

    /// <summary>
    /// Checks that the SetOutbox method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetOutbox()
    {
        // Arrange
        var value = _fixture.Create<WorkNoteBox>();

        // Act
        this._testClass.SetOutbox(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetOutbox method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetOutboxWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetOutbox(default(WorkNoteBox))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the CreateOutbox method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateOutbox()
    {
        // Arrange
        var key = _fixture.Create<string>();
        var noteBox = _fixture.Create<WorkNoteBox>();

        // Act
        this._testClass.CreateOutbox(key, noteBox);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateOutbox method throws when the noteBox parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateOutboxWithNullNoteBox()
    {
        FluentActions.Invoking(() => this._testClass.CreateOutbox(_fixture.Create<string>(), default(WorkNoteBox))).Should().Throw<ArgumentNullException>().WithParameterName("noteBox");
    }

    /// <summary>
    /// Checks that the CreateOutbox method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateOutboxWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.CreateOutbox(value, _fixture.Create<WorkNoteBox>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }
}