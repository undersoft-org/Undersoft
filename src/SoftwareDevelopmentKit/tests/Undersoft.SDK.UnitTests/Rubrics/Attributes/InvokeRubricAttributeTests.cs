using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="InvokeAttribute"/>.
/// </summary>
public class InvokeAttributeTests
{
    private InvokeAttribute _testClass;
    private IFixture _fixture;
    private string _targetName;
    private string _method;
    private Type _targetType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InvokeAttribute"/>.
    /// </summary>
    public InvokeAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._targetName = _fixture.Create<string>();
        this._method = _fixture.Create<string>();
        this._targetType = _fixture.Create<Type>();
        this._testClass = _fixture.Create<InvokeAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InvokeAttribute();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InvokeAttribute(this._targetName, this._method);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InvokeAttribute(this._targetType, this._method);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the targetType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetType()
    {
        FluentActions.Invoking(() => new InvokeAttribute(default(Type), this._method)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
    }

    /// <summary>
    /// Checks that the constructor throws when the targetName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidTargetName(string value)
    {
        FluentActions.Invoking(() => new InvokeAttribute(value, this._method)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
    }

    /// <summary>
    /// Checks that the constructor throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => new InvokeAttribute(this._targetName, value)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new InvokeAttribute(this._targetType, value)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }
}