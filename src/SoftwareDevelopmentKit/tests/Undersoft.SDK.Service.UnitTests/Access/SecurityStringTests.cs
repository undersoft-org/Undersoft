using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.UnitTests.Access;

/// <summary>
/// Unit tests for the type <see cref="SecurityString"/>.
/// </summary>
public class SecurityStringTests
{
    private SecurityString _testClass;
    private IFixture _fixture;
    private string _value;
    private string _prefix;
    private string _type;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SecurityString"/>.
    /// </summary>
    public SecurityStringTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._value = _fixture.Create<string>();
        this._prefix = _fixture.Create<string>();
        this._type = _fixture.Create<string>();
        this._testClass = _fixture.Create<SecurityString>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SecurityString();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SecurityString(this._value, this._prefix, this._type);

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
        FluentActions.Invoking(() => new SecurityString(value, this._prefix, this._type)).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the constructor throws when the prefix parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidPrefix(string value)
    {
        FluentActions.Invoking(() => new SecurityString(this._value, value, this._type)).Should().Throw<ArgumentNullException>().WithParameterName("prefix");
    }

    /// <summary>
    /// Checks that the constructor throws when the type parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidType(string value)
    {
        FluentActions.Invoking(() => new SecurityString(this._value, this._prefix, value)).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Decoded property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDecoded()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Decoded = testValue;

        // Assert
        this._testClass.Decoded.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Encoded property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEncoded()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Encoded = testValue;

        // Assert
        this._testClass.Encoded.Should().Be(testValue);
    }
}