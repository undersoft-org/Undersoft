using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;
using Undersoft.SDK.Workflows;
using Undersoft.SDK.Workflows.Notes;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="Worker"/>.
/// </summary>
public class WorkerTests
{
    private Worker _testClass;
    private IFixture _fixture;
    private string _name;
    private Mock<IInvoker> _method;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Worker"/>.
    /// </summary>
    public WorkerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._method = _fixture.Freeze<Mock<IInvoker>>();
        this._testClass = _fixture.Create<Worker>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Worker(this._name, this._method.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the Method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethod()
    {
        FluentActions.Invoking(() => new Worker(this._name, default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("Method");
    }

    /// <summary>
    /// Checks that the constructor throws when the Name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new Worker(value, this._method.Object)).Should().Throw<ArgumentNullException>().WithParameterName("Name");
    }

    /// <summary>
    /// Checks that the GetInput method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetInput()
    {
        // Act
        var result = this._testClass.GetInput();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetInput method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetInput()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        this._testClass.SetInput(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetInput method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetInputWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetInput(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the GetOutput method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetOutput()
    {
        // Act
        var result = this._testClass.GetOutput();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetOutput method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetOutput()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        this._testClass.SetOutput(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetOutput method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetOutputWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetOutput(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the CanSetOutput method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCanSetOutput()
    {
        // Act
        var result = this._testClass.CanSetOutput();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClone()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowToWithTAndString()
    {
        // Arrange
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.FlowTo<T>(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowToWithTAndStringWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowTo<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the FlowTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowToWithTAndFuncOfTAndDelegate()
    {
        // Arrange
        Func<T, Delegate> methodName = x => _fixture.Create<Delegate>();

        // Act
        var result = this._testClass.FlowTo<T>(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the methodName parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowToWithTAndFuncOfTAndDelegateWithNullMethodName()
    {
        FluentActions.Invoking(() => this._testClass.FlowTo<T>(default(Func<T, Delegate>))).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the FlowTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowToWithRecipient()
    {
        // Arrange
        var recipient = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowTo(recipient);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the recipient parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowToWithRecipientWithNullRecipient()
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("recipient");
    }

    /// <summary>
    /// Checks that the FlowTo maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FlowToWithRecipientPerformsMapping()
    {
        // Arrange
        var recipient = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowTo(recipient);

        // Assert
        result.Name.Should().BeSameAs(recipient.Name);
        result.Case.Should().BeSameAs(recipient.Case);
    }

    /// <summary>
    /// Checks that the FlowTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowToWithRecipientAndRelationWorks()
    {
        // Arrange
        var Recipient = _fixture.Create<WorkItem>();
        var RelationWorks = _fixture.Create<WorkItem[]>();

        // Act
        var result = this._testClass.FlowTo(Recipient, RelationWorks);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the Recipient parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowToWithRecipientAndRelationWorksWithNullRecipient()
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(default(WorkItem), _fixture.Create<WorkItem[]>())).Should().Throw<ArgumentNullException>().WithParameterName("Recipient");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the RelationWorks parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowToWithRecipientAndRelationWorksWithNullRelationWorks()
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(_fixture.Create<WorkItem>(), default(WorkItem[]))).Should().Throw<ArgumentNullException>().WithParameterName("RelationWorks");
    }

    /// <summary>
    /// Checks that the FlowTo maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FlowToWithRecipientAndRelationWorksPerformsMapping()
    {
        // Arrange
        var Recipient = _fixture.Create<WorkItem>();
        var RelationWorks = _fixture.Create<WorkItem[]>();

        // Act
        var result = this._testClass.FlowTo(Recipient, RelationWorks);

        // Assert
        result.Name.Should().BeSameAs(Recipient.Name);
        result.Case.Should().BeSameAs(Recipient.Case);
    }

    /// <summary>
    /// Checks that the FlowTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowToWithRecipientNameAndMethodName()
    {
        // Arrange
        var RecipientName = _fixture.Create<string>();
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.FlowTo(RecipientName, methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the RecipientName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowToWithRecipientNameAndMethodNameWithInvalidRecipientName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("RecipientName");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowToWithRecipientNameAndMethodNameWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the FlowTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowToWithRecipientNameAndRelationNames()
    {
        // Arrange
        var RecipientName = _fixture.Create<string>();
        var RelationNames = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.FlowTo(RecipientName, RelationNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the RelationNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowToWithRecipientNameAndRelationNamesWithNullRelationNames()
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(_fixture.Create<string>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("RelationNames");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the RecipientName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowToWithRecipientNameAndRelationNamesWithInvalidRecipientName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(value, _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("RecipientName");
    }

    /// <summary>
    /// Checks that the FlowFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowFromWithTAndString()
    {
        // Arrange
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.FlowFrom<T>(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowFromWithTAndStringWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the FlowFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowFromWithTAndFuncOfTAndDelegate()
    {
        // Arrange
        Func<T, Delegate> methodName = x => _fixture.Create<Delegate>();

        // Act
        var result = this._testClass.FlowFrom<T>(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the methodName parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowFromWithTAndFuncOfTAndDelegateWithNullMethodName()
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom<T>(default(Func<T, Delegate>))).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the FlowFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowFromWithSender()
    {
        // Arrange
        var sender = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowFrom(sender);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowFromWithSenderWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the FlowFrom maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FlowFromWithSenderPerformsMapping()
    {
        // Arrange
        var sender = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowFrom(sender);

        // Assert
        result.Name.Should().BeSameAs(sender.Name);
        result.Case.Should().BeSameAs(sender.Case);
    }

    /// <summary>
    /// Checks that the FlowFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowFromWithSenderAndRelationWorks()
    {
        // Arrange
        var Sender = _fixture.Create<WorkItem>();
        var RelationWorks = _fixture.Create<WorkItem[]>();

        // Act
        var result = this._testClass.FlowFrom(Sender, RelationWorks);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the Sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowFromWithSenderAndRelationWorksWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(default(WorkItem), _fixture.Create<WorkItem[]>())).Should().Throw<ArgumentNullException>().WithParameterName("Sender");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the RelationWorks parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowFromWithSenderAndRelationWorksWithNullRelationWorks()
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(_fixture.Create<WorkItem>(), default(WorkItem[]))).Should().Throw<ArgumentNullException>().WithParameterName("RelationWorks");
    }

    /// <summary>
    /// Checks that the FlowFrom maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FlowFromWithSenderAndRelationWorksPerformsMapping()
    {
        // Arrange
        var Sender = _fixture.Create<WorkItem>();
        var RelationWorks = _fixture.Create<WorkItem[]>();

        // Act
        var result = this._testClass.FlowFrom(Sender, RelationWorks);

        // Assert
        result.Name.Should().BeSameAs(Sender.Name);
        result.Case.Should().BeSameAs(Sender.Case);
    }

    /// <summary>
    /// Checks that the FlowFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowFromWithSenderNameAndMethodName()
    {
        // Arrange
        var SenderName = _fixture.Create<string>();
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.FlowFrom(SenderName, methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the SenderName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowFromWithSenderNameAndMethodNameWithInvalidSenderName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("SenderName");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowFromWithSenderNameAndMethodNameWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the FlowFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlowFromWithSenderNameAndRelationNames()
    {
        // Arrange
        var SenderName = _fixture.Create<string>();
        var RelationNames = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.FlowFrom(SenderName, RelationNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the RelationNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowFromWithSenderNameAndRelationNamesWithNullRelationNames()
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(_fixture.Create<string>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("RelationNames");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the SenderName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFlowFromWithSenderNameAndRelationNamesWithInvalidSenderName(string value)
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(value, _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("SenderName");
    }

    /// <summary>
    /// Checks that setting the Input property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInput()
    {
        this._testClass.CheckProperty(x => x.Input, _fixture.Create<Registry<object>>(), _fixture.Create<Registry<object>>());
    }

    /// <summary>
    /// Checks that setting the Output property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOutput()
    {
        this._testClass.CheckProperty(x => x.Output, _fixture.Create<Registry<object>>(), _fixture.Create<Registry<object>>());
    }

    /// <summary>
    /// Checks that setting the RootWorker property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRootWorker()
    {
        this._testClass.CheckProperty(x => x.RootWorker, _fixture.Create<Worker>(), _fixture.Create<Worker>());
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
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that setting the Process property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProcess()
    {
        this._testClass.CheckProperty(x => x.Process, _fixture.Create<IInvoker>(), _fixture.Create<IInvoker>());
    }

    /// <summary>
    /// Checks that setting the OutputId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOutputId()
    {
        this._testClass.CheckProperty(x => x.OutputId);
    }

    /// <summary>
    /// Checks that setting the InputId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInputId()
    {
        this._testClass.CheckProperty(x => x.InputId);
    }
}