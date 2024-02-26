using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Response;

namespace Undersoft.SDK.Service.UnitTests.Data.Response;

/// <summary>
/// Unit tests for the type <see cref="ResultString"/>.
/// </summary>
public class ResultStringTests
{
    private ResultString _testClass;
    private IFixture _fixture;
    private string _value;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ResultString"/>.
    /// </summary>
    public ResultStringTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._value = _fixture.Create<string>();
        this._testClass = _fixture.Create<ResultString>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ResultString();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ResultString(this._value);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the value parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidValue(string value)
    {
        FluentActions.Invoking(() => new ResultString(value)).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that setting the Value property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        this._testClass.CheckProperty(x => x.Value);
    }
}