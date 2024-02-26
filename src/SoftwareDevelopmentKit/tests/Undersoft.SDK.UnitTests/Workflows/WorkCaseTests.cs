using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Workflows;
using TAspect = System.String;
using TRule = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkCase"/>.
/// </summary>
public class WorkCase_1Tests
{
    private WorkCase<TRule> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkCase"/>.
    /// </summary>
    public WorkCase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<WorkCase<TRule>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkCase<TRule>();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Aspect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAspect()
    {
        // Act
        var result = this._testClass.Aspect<TAspect>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="WorkCase"/>.
/// </summary>
public class WorkCaseTests
{
    private WorkCase _testClass;
    private IFixture _fixture;
    private IEnumerable<IInvoker> _methods;
    private WorkAspects _case;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkCase"/>.
    /// </summary>
    public WorkCaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._methods = _fixture.Create<IEnumerable<IInvoker>>();
        this._case = _fixture.Create<WorkAspects>();
        this._testClass = _fixture.Create<WorkCase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkCase(this._methods, this._case);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkCase(this._case);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkCase();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the methods parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethods()
    {
        FluentActions.Invoking(() => new WorkCase(default(IEnumerable<IInvoker>), this._case)).Should().Throw<ArgumentNullException>().WithParameterName("methods");
    }

    /// <summary>
    /// Checks that instance construction throws when the case parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCase()
    {
        FluentActions.Invoking(() => new WorkCase(default(WorkAspects))).Should().Throw<ArgumentNullException>().WithParameterName("case");
    }

    /// <summary>
    /// Checks that the Aspect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAspectWithMethodAndAspect()
    {
        // Arrange
        var @method = _fixture.Create<IInvoker>();
        var aspect = _fixture.Create<WorkAspect>();

        // Act
        var result = this._testClass.Aspect(method, aspect);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Aspect method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAspectWithMethodAndAspectWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Aspect(default(IInvoker), _fixture.Create<WorkAspect>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Aspect method throws when the aspect parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAspectWithMethodAndAspectWithNullAspect()
    {
        FluentActions.Invoking(() => this._testClass.Aspect(_fixture.Create<IInvoker>(), default(WorkAspect))).Should().Throw<ArgumentNullException>().WithParameterName("aspect");
    }

    /// <summary>
    /// Checks that the Aspect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAspectWithMethodAndName()
    {
        // Arrange
        var @method = _fixture.Create<IInvoker>();
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.Aspect(method, name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Aspect method throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAspectWithMethodAndNameWithNullMethod()
    {
        FluentActions.Invoking(() => this._testClass.Aspect(default(IInvoker), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Aspect method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAspectWithMethodAndNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Aspect(_fixture.Create<IInvoker>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Aspect maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AspectWithMethodAndNamePerformsMapping()
    {
        // Arrange
        var @method = _fixture.Create<IInvoker>();
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.Aspect(method, name);

        // Assert
        result.Name.Should().BeSameAs(name);
    }

    /// <summary>
    /// Checks that the Aspect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAspectWithName()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.Aspect(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Aspect method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAspectWithNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Aspect(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Aspect maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AspectWithNamePerformsMapping()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.Aspect(name);

        // Assert
        result.Name.Should().BeSameAs(name);
    }

    /// <summary>
    /// Checks that the Open method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpen()
    {
        // Act
        this._testClass.Open();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Setup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetup()
    {
        // Act
        this._testClass.Setup();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithWorkNameAndInput()
    {
        // Arrange
        var workName = _fixture.Create<string>();
        var input = _fixture.Create<object[]>();

        // Act
        this._testClass.Run(workName, input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithWorkNameAndInputWithNullInput()
    {
        FluentActions.Invoking(() => this._testClass.Run(_fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method throws when the workName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRunWithWorkNameAndInputWithInvalidWorkName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Run(value, _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("workName");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithWorksAndParams()
    {
        // Arrange
        var worksAndParams = _fixture.Create<IDictionary<string, object[]>>();

        // Act
        this._testClass.Run(worksAndParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the worksAndParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithWorksAndParamsWithNullWorksAndParams()
    {
        FluentActions.Invoking(() => this._testClass.Run(default(IDictionary<string, object[]>))).Should().Throw<ArgumentNullException>().WithParameterName("worksAndParams");
    }
}

/// <summary>
/// Unit tests for the type <see cref="InvalidWorkException"/>.
/// </summary>
public class InvalidWorkExceptionTests
{
    private InvalidWorkException _testClass;
    private IFixture _fixture;
    private string _message;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InvalidWorkException"/>.
    /// </summary>
    public InvalidWorkExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._testClass = _fixture.Create<InvalidWorkException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InvalidWorkException(this._message);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => new InvalidWorkException(value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}