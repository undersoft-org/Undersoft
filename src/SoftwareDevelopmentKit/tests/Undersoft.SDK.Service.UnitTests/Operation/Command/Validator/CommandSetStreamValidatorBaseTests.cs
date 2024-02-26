using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Command.Validator;
using TCommand = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Validator;

/// <summary>
/// Unit tests for the type <see cref="CommandSetStreamValidatorBase"/>.
/// </summary>
public class CommandSetStreamValidatorBase_1Tests
{
    private class TestCommandSetStreamValidatorBase : CommandSetStreamValidatorBase<TCommand>
    {
        public TestCommandSetStreamValidatorBase(IServicer servicer) : base(servicer)
        {
        }
    }

    private TestCommandSetStreamValidatorBase _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandSetStreamValidatorBase"/>.
    /// </summary>
    public CommandSetStreamValidatorBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestCommandSetStreamValidatorBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestCommandSetStreamValidatorBase(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestCommandSetStreamValidatorBase(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }
}