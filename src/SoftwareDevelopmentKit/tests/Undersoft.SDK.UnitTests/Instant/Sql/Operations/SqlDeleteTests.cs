using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlDeleteException"/>.
/// </summary>
public class SqlDeleteExceptionTests
{
    private SqlDeleteException _testClass;
    private IFixture _fixture;
    private string _message;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlDeleteException"/>.
    /// </summary>
    public SqlDeleteExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlDeleteException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlDeleteException(this._message);

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
        FluentActions.Invoking(() => new SqlDeleteException(value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}