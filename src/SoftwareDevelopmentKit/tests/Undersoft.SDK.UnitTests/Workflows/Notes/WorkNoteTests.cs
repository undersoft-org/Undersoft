using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;
using Undersoft.SDK.Workflows.Notes;

namespace Undersoft.SDK.UnitTests.Workflows.Notes;

/// <summary>
/// Unit tests for the type <see cref="WorkNote"/>.
/// </summary>
public class WorkNoteTests
{
    private WorkNote _testClass;
    private IFixture _fixture;
    private WorkItem _senderWorkItem;
    private WorkItem _recipientWorkItem;
    private WorkNoteEvoker _out;
    private WorkNoteEvokers _in;
    private object[] _params;
    private string _senderString;
    private string _recipientString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkNote"/>.
    /// </summary>
    public WorkNoteTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._senderWorkItem = _fixture.Create<WorkItem>();
        this._recipientWorkItem = _fixture.Create<WorkItem>();
        this._out = _fixture.Create<WorkNoteEvoker>();
        this._in = _fixture.Create<WorkNoteEvokers>();
        this._params = _fixture.Create<object[]>();
        this._senderString = _fixture.Create<string>();
        this._recipientString = _fixture.Create<string>();
        this._testClass = _fixture.Create<WorkNote>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkNote(this._senderWorkItem, this._recipientWorkItem, this._out, this._in, this._params);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNote(this._senderString, this._params);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNote(this._senderString, this._recipientString, this._out, this._in, this._params);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNote(this._senderString, this._recipientString, this._out, this._params);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNote(this._senderString, this._recipientString, this._params);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSender()
    {
        FluentActions.Invoking(() => new WorkNote(default(WorkItem), this._recipientWorkItem, this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(default(string), this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(default(string), this._recipientString, this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(default(string), this._recipientString, this._out, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(default(string), this._recipientString, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that instance construction throws when the recipient parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRecipient()
    {
        FluentActions.Invoking(() => new WorkNote(this._senderWorkItem, default(WorkItem), this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNote(this._senderString, default(string), this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNote(this._senderString, default(string), this._out, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNote(this._senderString, default(string), this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
    }

    /// <summary>
    /// Checks that instance construction throws when the Out parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOut()
    {
        FluentActions.Invoking(() => new WorkNote(this._senderWorkItem, this._recipientWorkItem, default(WorkNoteEvoker), this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("Out");
        FluentActions.Invoking(() => new WorkNote(this._senderString, this._recipientString, default(WorkNoteEvoker), this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("Out");
        FluentActions.Invoking(() => new WorkNote(this._senderString, this._recipientString, default(WorkNoteEvoker), this._params)).Should().Throw<ArgumentNullException>().WithParameterName("Out");
    }

    /// <summary>
    /// Checks that instance construction throws when the In parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullIn()
    {
        FluentActions.Invoking(() => new WorkNote(this._senderWorkItem, this._recipientWorkItem, this._out, default(WorkNoteEvokers), this._params)).Should().Throw<ArgumentNullException>().WithParameterName("In");
        FluentActions.Invoking(() => new WorkNote(this._senderString, this._recipientString, this._out, default(WorkNoteEvokers), this._params)).Should().Throw<ArgumentNullException>().WithParameterName("In");
    }

    /// <summary>
    /// Checks that instance construction throws when the Params parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullParams()
    {
        FluentActions.Invoking(() => new WorkNote(this._senderWorkItem, this._recipientWorkItem, this._out, this._in, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("Params");
        FluentActions.Invoking(() => new WorkNote(this._senderString, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("Params");
        FluentActions.Invoking(() => new WorkNote(this._senderString, this._recipientString, this._out, this._in, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("Params");
        FluentActions.Invoking(() => new WorkNote(this._senderString, this._recipientString, this._out, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("Params");
        FluentActions.Invoking(() => new WorkNote(this._senderString, this._recipientString, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("Params");
    }

    /// <summary>
    /// Checks that the constructor throws when the sender parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSender(string value)
    {
        FluentActions.Invoking(() => new WorkNote(value, this._recipientWorkItem, this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(value, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(value, this._recipientString, this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(value, this._recipientString, this._out, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNote(value, this._recipientString, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the constructor throws when the recipient parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRecipient(string value)
    {
        FluentActions.Invoking(() => new WorkNote(this._senderWorkItem, value, this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNote(this._senderString, value, this._out, this._in, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNote(this._senderString, value, this._out, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNote(this._senderString, value, this._params)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
    }

    /// <summary>
    /// Checks that setting the EvokerOut property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEvokerOut()
    {
        this._testClass.CheckProperty(x => x.EvokerOut, _fixture.Create<WorkNoteEvoker>(), _fixture.Create<WorkNoteEvoker>());
    }

    /// <summary>
    /// Checks that setting the EvokersIn property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEvokersIn()
    {
        this._testClass.CheckProperty(x => x.EvokersIn, _fixture.Create<WorkNoteEvokers>(), _fixture.Create<WorkNoteEvokers>());
    }

    /// <summary>
    /// Checks that setting the Recipient property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRecipient()
    {
        this._testClass.CheckProperty(x => x.Recipient, _fixture.Create<WorkItem>(), _fixture.Create<WorkItem>());
    }

    /// <summary>
    /// Checks that setting the RecipientName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRecipientName()
    {
        this._testClass.CheckProperty(x => x.RecipientName);
    }

    /// <summary>
    /// Checks that setting the Sender property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSender()
    {
        this._testClass.CheckProperty(x => x.Sender, _fixture.Create<WorkItem>(), _fixture.Create<WorkItem>());
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