using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobAlreadyExistsException"/>.
/// </summary>
public class BlobAlreadyExistsExceptionTests
{
    private BlobAlreadyExistsException _testClass;
    private IFixture _fixture;
    private string _message;
    private Exception _innerException;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobAlreadyExistsException"/>.
    /// </summary>
    public BlobAlreadyExistsExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._innerException = _fixture.Create<Exception>();
        this._testClass = _fixture.Create<BlobAlreadyExistsException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobAlreadyExistsException();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new BlobAlreadyExistsException(this._message);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new BlobAlreadyExistsException(this._message, this._innerException);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the innerException parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInnerException()
    {
        FluentActions.Invoking(() => new BlobAlreadyExistsException(this._message, default(Exception))).Should().Throw<ArgumentNullException>().WithParameterName("innerException");
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
        FluentActions.Invoking(() => new BlobAlreadyExistsException(value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
        FluentActions.Invoking(() => new BlobAlreadyExistsException(value, this._innerException)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}