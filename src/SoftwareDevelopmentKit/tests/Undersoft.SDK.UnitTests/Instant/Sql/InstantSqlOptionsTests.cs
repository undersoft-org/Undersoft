using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="InstantSqlOptions"/>.
/// </summary>
public class InstantSqlOptionsTests
{
    private InstantSqlOptions _testClass;
    private IFixture _fixture;
    private string _connectionString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSqlOptions"/>.
    /// </summary>
    public InstantSqlOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._connectionString = _fixture.Create<string>();
        this._testClass = _fixture.Create<InstantSqlOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSqlOptions();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSqlOptions(this._connectionString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the connectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidConnectionString(string value)
    {
        FluentActions.Invoking(() => new InstantSqlOptions(value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }

    /// <summary>
    /// Checks that the ConnectionString property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConnectionString()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ConnectionString = testValue;

        // Assert
        this._testClass.ConnectionString.Should().Be(testValue);
    }
}