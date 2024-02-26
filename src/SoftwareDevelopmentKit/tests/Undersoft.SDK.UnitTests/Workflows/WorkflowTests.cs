using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;
using TAspect = System.String;
using TCase = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="Workflow"/>.
/// </summary>
public class Workflow_1Tests
{
    private Workflow<TCase> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Workflow"/>.
    /// </summary>
    public Workflow_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Workflow<TCase>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Workflow<TCase>();

        // Assert
        instance.Should().NotBeNull();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Workflow"/>.
/// </summary>
public class WorkflowTests
{
    private Workflow _testClass;
    private IFixture _fixture;
    private string _name;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Workflow"/>.
    /// </summary>
    public WorkflowTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._testClass = _fixture.Create<Workflow>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Workflow();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workflow(this._name);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new Workflow(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
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