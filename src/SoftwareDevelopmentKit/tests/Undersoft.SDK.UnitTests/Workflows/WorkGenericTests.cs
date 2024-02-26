using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="Work"/>.
/// </summary>
public class Work_1Tests
{
    private Work<T> _testClass;
    private IFixture _fixture;
    private Func<T, string> _method;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Work"/>.
    /// </summary>
    public Work_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._method = x => _fixture.Create<string>();
        this._testClass = _fixture.Create<Work<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Work<T>(this._method);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethod()
    {
        FluentActions.Invoking(() => new Work<T>(default(Func<T, string>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }
}