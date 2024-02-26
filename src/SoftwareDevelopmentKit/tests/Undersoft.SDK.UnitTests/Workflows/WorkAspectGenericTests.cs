using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;
using TAspect = System.String;
using TEvent = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkAspect"/>.
/// </summary>
public class WorkAspect_1Tests
{
    private WorkAspect<TAspect> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkAspect"/>.
    /// </summary>
    public WorkAspect_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<WorkAspect<TAspect>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkAspect<TAspect>();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithMethodname()
    {
        // Arrange
        var methodname = _fixture.Create<string>();

        // Act
        var result = this._testClass.Work<TEvent>(methodname);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallWorkWithMethodnameWithInvalidMethodname(string value)
    {
        FluentActions.Invoking(() => this._testClass.Work<TEvent>(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithMethodnamePerformsMapping()
    {
        // Arrange
        var methodname = _fixture.Create<string>();

        // Act
        var result = this._testClass.Work<TEvent>(methodname);

        // Assert
        result.MethodName.Should().BeSameAs(methodname);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithArguments()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.Work<TEvent>(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithArgumentsWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<TEvent>(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithArgumentsPerformsMapping()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.Work<TEvent>(arguments);

        // Assert
        result.Arguments.Should().BeSameAs(arguments);
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithConsrtuctorParams()
    {
        // Arrange
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<TEvent>(consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithConsrtuctorParamsWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<TEvent>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the Work method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWorkWithArgumentsAndConsrtuctorParams()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<TEvent>(arguments, consrtuctorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Work method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithArgumentsAndConsrtuctorParamsWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.Work<TEvent>(default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Work method throws when the consrtuctorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWorkWithArgumentsAndConsrtuctorParamsWithNullConsrtuctorParams()
    {
        FluentActions.Invoking(() => this._testClass.Work<TEvent>(_fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("consrtuctorParams");
    }

    /// <summary>
    /// Checks that the Work maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WorkWithArgumentsAndConsrtuctorParamsPerformsMapping()
    {
        // Arrange
        var arguments = _fixture.Create<Type[]>();
        var consrtuctorParams = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Work<TEvent>(arguments, consrtuctorParams);

        // Assert
        result.Arguments.Should().BeSameAs(arguments);
    }
}