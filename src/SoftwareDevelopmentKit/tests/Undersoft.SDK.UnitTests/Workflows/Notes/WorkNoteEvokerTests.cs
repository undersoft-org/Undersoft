using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques;
using Undersoft.SDK.Workflows;
using Undersoft.SDK.Workflows.Notes;

namespace Undersoft.SDK.UnitTests.Workflows.Notes;

/// <summary>
/// Unit tests for the type <see cref="WorkNoteEvoker"/>.
/// </summary>
public class WorkNoteEvokerTests
{
    private WorkNoteEvoker _testClass;
    private IFixture _fixture;
    private WorkItem _sender;
    private WorkItem _recipient;
    private WorkItem[] _relayWorks;
    private string[] _relayNames;
    private string _recipientName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkNoteEvoker"/>.
    /// </summary>
    public WorkNoteEvokerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sender = _fixture.Create<WorkItem>();
        this._recipient = _fixture.Create<WorkItem>();
        this._relayWorks = _fixture.Create<WorkItem[]>();
        this._relayNames = _fixture.Create<string[]>();
        this._recipientName = _fixture.Create<string>();
        this._testClass = _fixture.Create<WorkNoteEvoker>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkNoteEvoker(this._sender, this._recipient, this._relayWorks);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNoteEvoker(this._sender, this._recipient, this._relayNames);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNoteEvoker(this._sender, this._recipientName, this._relayWorks);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkNoteEvoker(this._sender, this._recipientName, this._relayNames);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSender()
    {
        FluentActions.Invoking(() => new WorkNoteEvoker(default(WorkItem), this._recipient, this._relayWorks)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNoteEvoker(default(WorkItem), this._recipient, this._relayNames)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNoteEvoker(default(WorkItem), this._recipientName, this._relayWorks)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
        FluentActions.Invoking(() => new WorkNoteEvoker(default(WorkItem), this._recipientName, this._relayNames)).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that instance construction throws when the recipient parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRecipient()
    {
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, default(WorkItem), this._relayWorks)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, default(WorkItem), this._relayNames)).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
    }

    /// <summary>
    /// Checks that instance construction throws when the relayWorks parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRelayWorks()
    {
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, this._recipient, default(WorkItem[]))).Should().Throw<ArgumentNullException>().WithParameterName("relayWorks");
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, this._recipientName, default(WorkItem[]))).Should().Throw<ArgumentNullException>().WithParameterName("relayWorks");
    }

    /// <summary>
    /// Checks that instance construction throws when the relayNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRelayNames()
    {
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, this._recipient, default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("relayNames");
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, this._recipientName, default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("relayNames");
    }

    /// <summary>
    /// Checks that the constructor throws when the recipientName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRecipientName(string value)
    {
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, value, this._relayWorks)).Should().Throw<ArgumentNullException>().WithParameterName("recipientName");
        FluentActions.Invoking(() => new WorkNoteEvoker(this._sender, value, this._relayNames)).Should().Throw<ArgumentNullException>().WithParameterName("recipientName");
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.Should().BeAssignableTo<IUnique>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the EvokerName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEvokerName()
    {
        this._testClass.CheckProperty(x => x.EvokerName);
    }

    /// <summary>
    /// Checks that setting the EvokerType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEvokerType()
    {
        this._testClass.CheckProperty(x => x.EvokerType, _fixture.Create<EvokerType>(), _fixture.Create<EvokerType>());
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