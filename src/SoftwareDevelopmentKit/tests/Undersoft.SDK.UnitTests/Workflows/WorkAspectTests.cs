using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Workflows;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkAspect"/>.
/// </summary>
public class WorkAspectTests
{
    private WorkAspect _testClass;
    private IFixture _fixture;
    private string _name;
    private IEnumerable<WorkItem> _workList;
    private IEnumerable<IInvoker> _methodList;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkAspect"/>.
    /// </summary>
    public WorkAspectTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._workList = _fixture.Create<IEnumerable<WorkItem>>();
        this._methodList = _fixture.Create<IEnumerable<IInvoker>>();
        this._testClass = _fixture.Create<WorkAspect>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkAspect(this._name);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkAspect(this._name, this._workList);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkAspect(this._name, this._methodList);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the WorkList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullWorkList()
    {
        FluentActions.Invoking(() => new WorkAspect(this._name, default(IEnumerable<WorkItem>))).Should().Throw<ArgumentNullException>().WithParameterName("WorkList");
    }

    /// <summary>
    /// Checks that instance construction throws when the MethodList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethodList()
    {
        FluentActions.Invoking(() => new WorkAspect(this._name, default(IEnumerable<IInvoker>))).Should().Throw<ArgumentNullException>().WithParameterName("MethodList");
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
        FluentActions.Invoking(() => new WorkAspect(value)).Should().Throw<ArgumentNullException>().WithParameterName("Name");
        FluentActions.Invoking(() => new WorkAspect(value, this._workList)).Should().Throw<ArgumentNullException>().WithParameterName("Name");
        FluentActions.Invoking(() => new WorkAspect(value, this._methodList)).Should().Throw<ArgumentNullException>().WithParameterName("Name");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithWorkItem()
    {
        // Arrange
        var labor = _fixture.Create<WorkItem>();

        // Act
        var result = this._testClass.AddWork(labor);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the labor parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithWorkItemWithNullLabor()
    {
        FluentActions.Invoking(() => this._testClass.AddWork(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("labor");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithDeputy()
    {
        // Arrange
        var deputy = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.AddWork(deputy);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the deputy parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithDeputyWithNullDeputy()
    {
        FluentActions.Invoking(() => this._testClass.AddWork(default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("deputy");
    }

    /// <summary>
    /// Checks that the AddWork maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddWorkWithDeputyPerformsMapping()
    {
        // Arrange
        var deputy = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.AddWork(deputy);

        // Assert
        result.TargetObject.Should().BeSameAs(deputy.TargetObject);
        result.Parameters.Should().BeSameAs(deputy.Parameters);
        result.MethodInvoker.Should().BeSameAs(deputy.MethodInvoker);
        result.Method.Should().BeSameAs(deputy.Method);
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithLabors()
    {
        // Arrange
        var labors = _fixture.Create<IEnumerable<WorkItem>>();

        // Act
        var result = this._testClass.AddWork(labors);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the labors parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithLaborsWithNullLabors()
    {
        FluentActions.Invoking(() => this._testClass.AddWork(default(IEnumerable<WorkItem>))).Should().Throw<ArgumentNullException>().WithParameterName("labors");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithMethods()
    {
        // Arrange
        var methods = _fixture.Create<IEnumerable<IInvoker>>();

        // Act
        var result = this._testClass.AddWork(methods);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the methods parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithMethodsWithNullMethods()
    {
        FluentActions.Invoking(() => this._testClass.AddWork(default(IEnumerable<IInvoker>))).Should().Throw<ArgumentNullException>().WithParameterName("methods");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndString()
    {
        // Arrange
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.AddWork<T>(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAddWorkWithTAndStringWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
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
    public void CanCallAddWorkWithArgumentsAndConsrtuctorParams()
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
    public void CannotCallAddWorkWithArgumentsAndConsrtuctorParamsWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithArgumentsAndConsrtuctorParamsWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(_fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndFuncOfTAndDelegate()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();

        // Act
        var result = this._testClass.AddWork<T>(method);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndDelegateWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Func<T, Delegate>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndFuncOfTAndDelegateAndArrayOfType()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();
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
    public void CannotCallAddWorkWithTAndFuncOfTAndDelegateAndArrayOfTypeWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Func<T, Delegate>), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndDelegateAndArrayOfTypeWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(x => _fixture.Create<Delegate>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the AddWork method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWorkWithTAndFuncOfTAndDelegateAndArrayOfObject()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.AddWork<T>(method, consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndDelegateAndArrayOfObjectWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(default(Func<T, Delegate>), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the AddWork method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWorkWithTAndFuncOfTAndDelegateAndArrayOfObjectWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.AddWork<T>(x => _fixture.Create<Delegate>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndString()
    {
        // Arrange
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Work<T>(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallWorkWithTAndStringWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndStringPerformsMapping()
    {
        // Arrange
        var methodName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Work<T>(methodName);

        // Assert
        result.MethodName.Should().BeSameAs(methodName);
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
    public void CanCallWorkWithArgumentsAndConstructorParams()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var constructorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(arguments, constructorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithArgumentsAndConstructorParamsWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithArgumentsAndConstructorParamsWithNullConstructorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(_fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithArgumentsAndConstructorParamsPerformsMapping()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var constructorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(arguments, constructorParams);

        // Assert
        result.Arguments.Should().BeSameAs(arguments);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndFuncOfTAndDelegate()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();

        // Act
        var result = this._testClass.Work<T>(method);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndDelegateWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Func<T, Delegate>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndFuncOfTAndDelegatePerformsMapping()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();

        // Act
        var result = this._testClass.Work<T>(method);

        // Assert
        result.Method.Should().BeSameAs(method);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithTAndFuncOfTAndDelegateAndArrayOfType()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();
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
    public void CannotCallWorkWithTAndFuncOfTAndDelegateAndArrayOfTypeWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Func<T, Delegate>), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndDelegateAndArrayOfTypeWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(x => _fixture.Create<Delegate>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndFuncOfTAndDelegateAndArrayOfTypePerformsMapping()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();
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
    public void CanCallWorkWithTAndFuncOfTAndDelegateAndArrayOfObject()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(method, consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndDelegateAndArrayOfObjectWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(default(Func<T, Delegate>), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Work method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithTAndFuncOfTAndDelegateAndArrayOfObjectWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<T>(x => _fixture.Create<Delegate>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithTAndFuncOfTAndDelegateAndArrayOfObjectPerformsMapping()
    {
        // Arrange
        Func<T, Delegate> @method = x => _fixture.Create<Delegate>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<T>(method, consrtuctorParams);

        // Assert
        result.Method.Should().BeSameAs(method);
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
        var labor = _fixture.Create<WorkItem>();

        // Act
        this._testClass.Run(labor);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the labor parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithNullLabor()
    {
        FluentActions.Invoking(() => this._testClass.Run(default(WorkItem))).Should().Throw<ArgumentNullException>().WithParameterName("labor");
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
    /// Checks that setting the Case property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCase()
    {
        this._testClass.CheckProperty(x => x.Case, _fixture.Create<WorkAspects>(), _fixture.Create<WorkAspects>());
    }

    /// <summary>
    /// Checks that setting the WorkersCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetWorkersCount()
    {
        this._testClass.CheckProperty(x => x.WorkersCount);
    }

    /// <summary>
    /// Checks that setting the Workspace property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetWorkspace()
    {
        this._testClass.CheckProperty(x => x.Workspace, _fixture.Create<Workspace>(), _fixture.Create<Workspace>());
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
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<WorkItem>();
        this._testClass[_fixture.Create<object>()].Should().BeAssignableTo<WorkItem>();
        this._testClass[_fixture.Create<object>()] = testValue;
        this._testClass[_fixture.Create<object>()].Should().BeSameAs(testValue);
    }
}