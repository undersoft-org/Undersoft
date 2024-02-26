using System;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Uniques;
using Undersoft.SDK.Workflows;
using Undersoft.SDK.Workflows.Notes;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkItem"/>.
/// </summary>
public class WorkItemTests
{
    private WorkItem _testClass;
    private IFixture _fixture;
    private Mock<IInvoker> _operation;
    private Worker _worker;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkItem"/>.
    /// </summary>
    public WorkItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._operation = _fixture.Freeze<Mock<IInvoker>>();
        this._worker = _fixture.Create<Worker>();
        this._testClass = _fixture.Create<WorkItem>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkItem(this._operation.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkItem(this._worker);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the operation parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOperation()
    {
        FluentActions.Invoking(() => new WorkItem(default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("operation");
    }

    /// <summary>
    /// Checks that instance construction throws when the worker parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullWorker()
    {
        FluentActions.Invoking(() => new WorkItem(default(Worker))).Should().Throw<ArgumentNullException>().WithParameterName("worker");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRun()
    {
        // Arrange
        var input = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Run(input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithNullInput()
    {
        FluentActions.Invoking(() => this._testClass.Run(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvokeWithArrayOfObject()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Invoke(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithArrayOfObjectWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithArrayOfObjectAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithTAndArrayOfObjectAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync<T>(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
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
        var Recipient = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowTo(Recipient);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowTo method throws when the Recipient parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowToWithRecipientWithNullRecipient()
    {
        FluentActions.Invoking(() => this._testClass.FlowTo(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("Recipient");
    }

    /// <summary>
    /// Checks that the FlowTo maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FlowToWithRecipientPerformsMapping()
    {
        // Arrange
        var Recipient = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowTo(Recipient);

        // Assert
        result.Name.Should().BeSameAs(Recipient.Name);
        result.Case.Should().BeSameAs(Recipient.Case);
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
        var Sender = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowFrom(Sender);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FlowFrom method throws when the Sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFlowFromWithSenderWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.FlowFrom(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("Sender");
    }

    /// <summary>
    /// Checks that the FlowFrom maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FlowFromWithSenderPerformsMapping()
    {
        // Arrange
        var Sender = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.FlowFrom(Sender);

        // Assert
        result.Name.Should().BeSameAs(Sender.Name);
        result.Case.Should().BeSameAs(Sender.Case);
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
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithT()
    {
        // Act
        var result = this._testClass.AddWork<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndArrayOfType()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.AddWork<T>(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndArrayOfTypeWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndArrayOfObject()
    {
        // Arrange
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.AddWork<T>(consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndArrayOfObjectWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndArrayOfTypeAndArrayOfObject()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.AddWork<T>(arguments, consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndArrayOfTypeAndArrayOfObjectWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndArrayOfTypeAndArrayOfObjectWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(_fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndFuncOfTAndString()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();

        // Act
        var result = this._testClass.AddWork<T>(method);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndStringWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Func<T, string>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndFuncOfTAndStringAndArrayOfType()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.AddWork<T>(method, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndStringAndArrayOfTypeWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Func<T, string>), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndStringAndArrayOfTypeWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(x => _fixture.Create<string>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndFuncOfTAndStringAndArrayOfObject()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();
        var constructorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.AddWork<T>(method, constructorParams
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndStringAndArrayOfObjectWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Func<T, string>), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndStringAndArrayOfObjectWithNullConstructorParams()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(x => _fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithT()
    {
        // Act
        var result = this._testClass.Work<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndArrayOfType()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.Work<T>(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndArrayOfTypeWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndArrayOfTypePerformsMapping()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.Work<T>(arguments);

        // Assert
        result.Arguments.Should().BeSameAs(arguments);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndArrayOfObject()
    {
        // Arrange
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndArrayOfObjectWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndArrayOfTypeAndArrayOfObject()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(arguments, consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndArrayOfTypeAndArrayOfObjectWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndArrayOfTypeAndArrayOfObjectWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(_fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndArrayOfTypeAndArrayOfObjectPerformsMapping()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(arguments, consrtuctorParams);

        // Assert
        result.Arguments.Should().BeSameAs(arguments);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndFuncOfTAndString()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();

        // Act
        var result = this._testClass.Work<T>(method);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndStringWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Func<T, string>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndFuncOfTAndStringPerformsMapping()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();

        // Act
        var result = this._testClass.Work<T>(method);

        // Assert
        result.Method.Should().BeSameAs(method);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndFuncOfTAndStringAndArrayOfType()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.Work<T>(method, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndStringAndArrayOfTypeWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Func<T, string>), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndStringAndArrayOfTypeWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(x => _fixture.Create<string>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndFuncOfTAndStringAndArrayOfTypePerformsMapping()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.Work<T>(method, arguments);

        // Assert
        result.Method.Should().BeSameAs(method);
        result.Arguments.Should().BeSameAs(arguments);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndFuncOfTAndStringAndArrayOfObject()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();
        var constructorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(method, constructorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndStringAndArrayOfObjectWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Func<T, string>), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Work method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndStringAndArrayOfObjectWithNullConstructorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(x => _fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndFuncOfTAndStringAndArrayOfObjectPerformsMapping()
    {
        // Arrange
        Func<T, string> @method = x => _fixture.Create<string>();
        var constructorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(method, constructorParams);

        // Assert
        result.Method.Should().BeSameAs(method);
    }

    /// <summary>
    /// Checks that the Allocate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAllocate()
    {
        // Arrange
        var laborsCount = _fixture.Create<int>();

        // Act
        var result = this._testClass.Allocate(laborsCount);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the Fire method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFireWithArrayOfObjectAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Fire(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Fire method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Execute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecute()
    {
        // Arrange
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Execute(target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Execute method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.Execute(default(object), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Execute method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Execute(_fixture.Create<object>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExecuteAsyncWithObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.ExecuteAsync(target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteAsyncWithObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExecuteAsync(default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteAsyncWithObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExecuteAsync(_fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExecuteAsyncWithTAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.ExecuteAsync<T>(target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteAsyncWithTAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExecuteAsync<T>(default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteAsyncWithTAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExecuteAsync<T>(_fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Fire method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFireWithBoolAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var firstAsTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Fire(firstAsTarget, target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Fire method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithBoolAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Fire method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithBoolAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvokeWithBoolAndObjectAndArrayOfObject()
    {
        // Arrange
        var firstAsTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Invoke(firstAsTarget, target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithBoolAndObjectAndArrayOfObjectWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithBoolAndObjectAndArrayOfObjectWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithBoolAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var firstAsTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync(firstAsTarget, target, parameters
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithBoolAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithBoolAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithTAndBoolAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var firstAsTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync<T>(firstAsTarget, target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndBoolAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndBoolAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithArgumentsAsync()
    {
        // Arrange
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.InvokeAsync(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithWithTargetAndTargetAndArgumentsAsync()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.InvokeAsync(withTarget, target, arguments
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithWithTargetAndTargetAndArgumentsWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), default(object), _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithWithTargetAndTargetAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), _fixture.Create<object>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
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
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that setting the QualifiedName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetQualifiedName()
    {
        this._testClass.CheckProperty(x => x.QualifiedName);
    }

    /// <summary>
    /// Checks that the MethodName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMethodName()
    {
        // Assert
        this._testClass.MethodName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TypeName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetTypeName()
    {
        // Assert
        this._testClass.TypeName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Code property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCode()
    {
        this._testClass.CheckProperty(x => x.Code, _fixture.Create<Uscn>(), _fixture.Create<Uscn>());
    }

    /// <summary>
    /// Checks that the ReturnType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetReturnType()
    {
        // Assert
        this._testClass.ReturnType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Type property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetType()
    {
        // Assert
        this._testClass.Type.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssemblyName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAssemblyName()
    {
        // Assert
        this._testClass.AssemblyName.Should().BeAssignableTo<AssemblyName>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Worker property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetWorker()
    {
        this._testClass.CheckProperty(x => x.Worker, _fixture.Create<Worker>(), _fixture.Create<Worker>());
    }

    /// <summary>
    /// Checks that setting the Aspect property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAspect()
    {
        this._testClass.CheckProperty(x => x.Aspect, _fixture.Create<WorkAspect>(), _fixture.Create<WorkAspect>());
    }

    /// <summary>
    /// Checks that setting the Case property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCase()
    {
        this._testClass.CheckProperty(x => x.Case, _fixture.Create<WorkAspects>(), _fixture.Create<WorkAspects>());
    }

    /// <summary>
    /// Checks that setting the Box property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBox()
    {
        this._testClass.CheckProperty(x => x.Box, _fixture.Create<WorkNoteBox>(), _fixture.Create<WorkNoteBox>());
    }

    /// <summary>
    /// Checks that setting the Arguments property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetArguments()
    {
        this._testClass.CheckProperty(x => x.Arguments, _fixture.Create<Arguments>(), _fixture.Create<Arguments>());
    }

    /// <summary>
    /// Checks that setting the Info property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInfo()
    {
        this._testClass.CheckProperty(x => x.Info, _fixture.Create<MethodInfo>(), _fixture.Create<MethodInfo>());
    }

    /// <summary>
    /// Checks that setting the Parameters property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetParameters()
    {
        this._testClass.CheckProperty(x => x.Parameters, _fixture.Create<ParameterInfo[]>(), _fixture.Create<ParameterInfo[]>());
    }

    /// <summary>
    /// Checks that setting the ValueArray property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValueArray()
    {
        this._testClass.CheckProperty(x => x.ValueArray, _fixture.Create<object[]>(), _fixture.Create<object[]>());
    }

    /// <summary>
    /// Checks that the MethodInvoker property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMethodInvoker()
    {
        // Assert
        this._testClass.MethodInvoker.Should().BeAssignableTo<InvokerDelegate>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Method property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMethod()
    {
        // Assert
        this._testClass.Method.Should().BeAssignableTo<Delegate>();

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
    /// Checks that setting the WorkerName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetWorkerName()
    {
        this._testClass.CheckProperty(x => x.WorkerName);
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
    /// Checks that setting the TargetObject property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTargetObject()
    {
        this._testClass.CheckProperty(x => x.TargetObject, _fixture.Create<object>(), _fixture.Create<object>());
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForString()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }
}