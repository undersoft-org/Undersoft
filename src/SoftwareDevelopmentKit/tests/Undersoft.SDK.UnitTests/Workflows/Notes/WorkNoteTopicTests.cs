using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows.Notes;

namespace Undersoft.SDK.UnitTests.Workflows.Notes;

/// <summary>
/// Unit tests for the type <see cref="WorkNoteTopic"/>.
/// </summary>
public class WorkNoteTopicTests
{
    private WorkNoteTopic _testClass;
    private IFixture _fixture;
    private string _senderName;
    private IList<WorkNote> _notelist;
    private WorkNoteBox _recipient;
    private WorkNote _note;
    private object[] _parameters;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkNoteTopic"/>.
    /// </summary>
    public WorkNoteTopicTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._senderName = _fixture.Create<string>();
        this._notelist = _fixture.Create<IList<WorkNote>>();
        this._recipient = _fixture.Create<WorkNoteBox>();
        this._note = _fixture.Create<WorkNote>();
        this._parameters = _fixture.Create<object[]>();
        this._testClass = _fixture.Create<WorkNoteTopic>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkNoteTopic(this._senderName, this._notelist, this._recipient);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNoteTopic(this._senderName, this._note, this._recipient);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNoteTopic(this._senderName, this._recipient);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNoteTopic(this._senderName, this._recipient, this._parameters);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the notelist parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullNotelist()
    {
        FluentActions.Invoking(() => new WorkNoteTopic(this._senderName, default(IList<WorkNote>), this._recipient)).Should().Throw<ArgumentNullException>().WithParameterName("notelist");
    }

    /// <summary>
    /// Checks that instance construction throws when the note parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullNote()
    {
        FluentActions.Invoking(() => new WorkNoteTopic(this._senderName, default(WorkNote), this._recipient)).Should().Throw<ArgumentNullException>().WithParameterName("note");
    }

    /// <summary>
    /// Checks that instance construction throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullParameters()
    {
        FluentActions.Invoking(() => new WorkNoteTopic(this._senderName, this._recipient, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the constructor throws when the senderName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSenderName(string value)
    {
        FluentActions.Invoking(() => new WorkNoteTopic(value, this._notelist, this._recipient)).Should().Throw<ArgumentNullException>().WithParameterName("senderName");
        FluentActions.Invoking(() => new WorkNoteTopic(value, this._note, this._recipient)).Should().Throw<ArgumentNullException>().WithParameterName("senderName");
        FluentActions.Invoking(() => new WorkNoteTopic(value, this._recipient)).Should().Throw<ArgumentNullException>().WithParameterName("senderName");
        FluentActions.Invoking(() => new WorkNoteTopic(value, this._recipient, this._parameters)).Should().Throw<ArgumentNullException>().WithParameterName("senderName");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithNoteList()
    {
        // Arrange
        var noteList = _fixture.Create<IList<WorkNote>>();

        // Act
        this._testClass.Notify(noteList);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the noteList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithNoteListWithNullNoteList()
    {
        FluentActions.Invoking(() => this._testClass.Notify(default(IList<WorkNote>))).Should().Throw<ArgumentNullException>().WithParameterName("noteList");
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
    public void CanCallNotifyWithParameters()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        this._testClass.Notify(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithParametersWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Notify(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Notify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNotifyWithSenderNameAndParameters()
    {
        // Arrange
        var senderName = _fixture.Create<string>();
        var parameters = _fixture.Create<object[]>();

        // Act
        this._testClass.Notify(senderName, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Notify method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNotifyWithSenderNameAndParametersWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Notify(_fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Notify method throws when the senderName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNotifyWithSenderNameAndParametersWithInvalidSenderName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Notify(value, _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("senderName");
    }

    /// <summary>
    /// Checks that setting the Notes property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNotes()
    {
        this._testClass.CheckProperty(x => x.Notes, _fixture.Create<WorkNote>(), _fixture.Create<WorkNote>());
    }

    /// <summary>
    /// Checks that setting the SenderName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSenderName()
    {
        this._testClass.CheckProperty(x => x.SenderName);
    }
}