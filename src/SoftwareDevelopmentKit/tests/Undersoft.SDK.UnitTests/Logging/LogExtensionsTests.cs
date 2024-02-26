using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Events;
using Undersoft.SDK.Logging;
using T = System.String;
using TEx = System.String;

namespace Undersoft.SDK.UnitTests.Logging;

/// <summary>
/// Unit tests for the type <see cref="Log"/>.
/// </summary>
public partial class LogTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Error method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallErrorWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Error<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Error method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallErrorWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Error<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Error method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallErrorWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Error<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Critical method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCriticalWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Critical<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Critical method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCriticalWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Critical<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Critical method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCriticalWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Critical<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Info method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInfoWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Info<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Info method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInfoWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Info<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Info method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallInfoWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Info<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Failure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFailureWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Failure<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Failure method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFailureWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Failure<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Failure method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFailureWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Failure<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Success method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSuccessWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Success<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Success method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSuccessWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Success<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Success method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSuccessWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Success<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Warning method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWarningWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Warning<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Warning method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWarningWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Warning<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Warning method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallWarningWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Warning<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Security method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSecurityWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Security<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Security method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSecurityWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Security<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Security method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSecurityWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Security<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Alert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAlertWithTAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Alert<T>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Alert method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAlertWithTAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Alert<T>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Alert method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAlertWithTAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Alert<T>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Error method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallErrorWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Error<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Error method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallErrorWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Error<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Error method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallErrorWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Error<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Critical method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCriticalWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Critical<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Critical method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCriticalWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Critical<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Critical method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCriticalWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Critical<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Info method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInfoWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Info<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Info method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInfoWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Info<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Info method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallInfoWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Info<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Failure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFailureWithSenderAndMessageAndDataAndExAndWithThrow()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();
        var withThrow = _fixture.Create<bool>();

        // Act
        sender.Failure<T, TEx>(message, data, ex, withThrow);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Failure method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFailureWithSenderAndMessageAndDataAndExAndWithThrowWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Failure<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Failure method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFailureWithSenderAndMessageAndDataAndExAndWithThrowWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Failure<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Success method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSuccessWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Success<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Success method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSuccessWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Success<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Success method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSuccessWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Success<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Warning method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWarningWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Warning<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Warning method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWarningWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Warning<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Warning method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallWarningWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Warning<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Security method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSecurityWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Security<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Security method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSecurityWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Security<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Security method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSecurityWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Security<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Alert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAlertWithTAndTExAndObjectAndStringAndObjectAndException()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var message = _fixture.Create<string>();
        var data = _fixture.Create<object>();
        var ex = _fixture.Create<Exception>();

        // Act
        sender.Alert<T, TEx>(message, data, ex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Alert method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAlertWithTAndTExAndObjectAndStringAndObjectAndExceptionWithNullSender()
    {
        FluentActions.Invoking(() => default(object).Alert<T, TEx>(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the Alert method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAlertWithTAndTExAndObjectAndStringAndObjectAndExceptionWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().Alert<T, TEx>(value, _fixture.Create<object>(), _fixture.Create<Exception>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}

/// <summary>
/// Unit tests for the type <see cref="Starlog"/>.
/// </summary>
public class StarlogTests
{
    private class TestStarlog : Starlog
    {
        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestStarlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Starlog"/>.
    /// </summary>
    public StarlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestStarlog>();
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithDisposing()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithNoParameters()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Message property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMessage()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Message = testValue;

        // Assert
        this._testClass.Message.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Created property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreated()
    {
        // Arrange
        var testValue = _fixture.Create<DateTime>();

        // Act
        this._testClass.Created = testValue;

        // Assert
        this._testClass.Created.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Group property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetGroup()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Group = testValue;

        // Assert
        this._testClass.Group.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Sender property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSender()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Sender = testValue;

        // Assert
        this._testClass.Sender.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Id property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetId()
    {
        // Assert
        this._testClass.Id.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Level property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLevel()
    {
        // Arrange
        var testValue = _fixture.Create<LogEventLevel>();

        // Act
        this._testClass.Level = testValue;

        // Assert
        this._testClass.Level.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the State property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetState()
    {
        // Arrange
        var testValue = _fixture.Create<ILogSate>();

        // Act
        this._testClass.State = testValue;

        // Assert
        this._testClass.State.Should().BeSameAs(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="Runlog"/>.
/// </summary>
public class RunlogTests
{
    private Runlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Runlog"/>.
    /// </summary>
    public RunlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Runlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Datalog"/>.
/// </summary>
public class DatalogTests
{
    private Datalog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Datalog"/>.
    /// </summary>
    public DatalogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Datalog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Netlog"/>.
/// </summary>
public class NetlogTests
{
    private Netlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Netlog"/>.
    /// </summary>
    public NetlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Netlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Applog"/>.
/// </summary>
public class ApplogTests
{
    private Applog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Applog"/>.
    /// </summary>
    public ApplogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Applog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Instantlog"/>.
/// </summary>
public class InstantlogTests
{
    private Instantlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Instantlog"/>.
    /// </summary>
    public InstantlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Instantlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Eventlog"/>.
/// </summary>
public class EventlogTests
{
    private Eventlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Eventlog"/>.
    /// </summary>
    public EventlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Eventlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Domainlog"/>.
/// </summary>
public class DomainlogTests
{
    private Domainlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Domainlog"/>.
    /// </summary>
    public DomainlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Domainlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Infralog"/>.
/// </summary>
public class InfralogTests
{
    private Infralog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Infralog"/>.
    /// </summary>
    public InfralogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Infralog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Weblog"/>.
/// </summary>
public class WeblogTests
{
    private Weblog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Weblog"/>.
    /// </summary>
    public WeblogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Weblog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Apilog"/>.
/// </summary>
public class ApilogTests
{
    private Apilog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Apilog"/>.
    /// </summary>
    public ApilogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Apilog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Healthlog"/>.
/// </summary>
public class HealthlogTests
{
    private Healthlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Healthlog"/>.
    /// </summary>
    public HealthlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Healthlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Metriclog"/>.
/// </summary>
public class MetriclogTests
{
    private Metriclog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Metriclog"/>.
    /// </summary>
    public MetriclogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Metriclog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Servicelog"/>.
/// </summary>
public class ServicelogTests
{
    private Servicelog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Servicelog"/>.
    /// </summary>
    public ServicelogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Servicelog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Agentlog"/>.
/// </summary>
public class AgentlogTests
{
    private Agentlog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Agentlog"/>.
    /// </summary>
    public AgentlogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Agentlog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Accesslog"/>.
/// </summary>
public class AccesslogTests
{
    private Accesslog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Accesslog"/>.
    /// </summary>
    public AccesslogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Accesslog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Emaillog"/>.
/// </summary>
public class EmaillogTests
{
    private Emaillog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Emaillog"/>.
    /// </summary>
    public EmaillogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Emaillog>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="Baselog"/>.
/// </summary>
public class BaselogTests
{
    private Baselog _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Baselog"/>.
    /// </summary>
    public BaselogTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Baselog>();
    }

    /// <summary>
    /// Checks that the DataObject property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDataObject()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.DataObject = testValue;

        // Assert
        this._testClass.DataObject.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Exception property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetException()
    {
        // Arrange
        var testValue = _fixture.Create<Exception>();

        // Act
        this._testClass.Exception = testValue;

        // Assert
        this._testClass.Exception.Should().BeSameAs(testValue);
    }
}