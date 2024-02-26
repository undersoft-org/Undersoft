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
/// Unit tests for the type <see cref="WorkNoteBox"/>.
/// </summary>
public class WorkNoteBoxTests
{
    private WorkNoteBox _testClass;
    private IFixture _fixture;
    private string _recipient;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkNoteBox"/>.
    /// </summary>
    public WorkNoteBoxTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._recipient = _fixture.Create<string>();
        this._testClass = _fixture.Create<WorkNoteBox>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkNoteBox(this._recipient);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the Recipient parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRecipient(string value)
    {
        FluentActions.Invoking(() => new WorkNoteBox(value)).Should().Throw<ArgumentNullException>().WithParameterName("Recipient");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithNotes()
    {
        // Arrange
        var notes = _fixture.Create<WorkNote[]>();

        // Act
        this._testClass.Notify(notes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the notes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithNotesWithNullNotes()
    {
        FluentActions.Invoking(() => this._testClass.Notify(default(WorkNote[]))).Should().Throw<ArgumentNullException>().WithParameterName("notes");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithNote()
    {
        // Arrange
        var note = _fixture.Create<WorkNote>();

        // Act
        this._testClass.Notify(note);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the note parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithNoteWithNullNote()
    {
        FluentActions.Invoking(() => this._testClass.Notify(default(WorkNote))).Should().Throw<ArgumentNullException>().WithParameterName("note");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithKeyAndNotes()
    {
        // Arrange
        var key = _fixture.Create<string>();
        var notes = _fixture.Create<WorkNote[]>();

        // Act
        this._testClass.Notify(key, notes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the notes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithKeyAndNotesWithNullNotes()
    {
        FluentActions.Invoking(() => this._testClass.Notify(_fixture.Create<string>(), default(WorkNote[]))).Should().Throw<ArgumentNullException>().WithParameterName("notes");
    }

    /// <summary>
    /// Checks that the Notify method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNotifyWithKeyAndNotesWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.Notify(value, _fixture.Create<WorkNote[]>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithKeyAndValue()
    {
        // Arrange
        var key = _fixture.Create<string>();
        var value = _fixture.Create<WorkNote>();

        // Act
        this._testClass.Notify(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithKeyAndValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Notify(_fixture.Create<string>(), default(WorkNote))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Notify method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNotifyWithKeyAndValueWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.Notify(value, _fixture.Create<WorkNote>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithKeyAndIoqueues()
    {
        // Arrange
        var key = _fixture.Create<string>();
        var ioqueues = _fixture.Create<object>();

        // Act
        this._testClass.Notify(key, ioqueues);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the ioqueues parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithKeyAndIoqueuesWithNullIoqueues()
    {
        FluentActions.Invoking(() => this._testClass.Notify(_fixture.Create<string>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("ioqueues");
    }

    /// <summary>
    /// Checks that the Notify method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNotifyWithKeyAndIoqueuesWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.Notify(value, _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TakeNote method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTakeNote()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = this._testClass.TakeNote(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TakeNote method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallTakeNoteWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.TakeNote(value)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TakeNotes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTakeNotes()
    {
        // Arrange
        var keys = _fixture.Create<IList<string>>();

        // Act
        var result = this._testClass.TakeNotes(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TakeNotes method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTakeNotesWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.TakeNotes(default(IList<string>))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the GetParams method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetParams()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetParams(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetParams method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetParamsWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetParams(value)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the MeetsRequirements method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMeetsRequirements()
    {
        // Arrange
        var keys = _fixture.Create<IList<string>>();

        // Act
        var result = this._testClass.MeetsRequirements(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MeetsRequirements method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMeetsRequirementsWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.MeetsRequirements(default(IList<string>))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the QualifyToEvoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQualifyToEvoke()
    {
        // Act
        this._testClass.QualifyToEvoke();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Evokers property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEvokers()
    {
        this._testClass.CheckProperty(x => x.Evokers, _fixture.Create<WorkNoteEvokers>(), _fixture.Create<WorkNoteEvokers>());
    }

    /// <summary>
    /// Checks that setting the Work property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetWork()
    {
        this._testClass.CheckProperty(x => x.Work, _fixture.Create<WorkItem>(), _fixture.Create<WorkItem>());
    }

    /// <summary>
    /// Checks that setting the RecipientName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRecipientName()
    {
        this._testClass.CheckProperty(x => x.RecipientName);
    }
}