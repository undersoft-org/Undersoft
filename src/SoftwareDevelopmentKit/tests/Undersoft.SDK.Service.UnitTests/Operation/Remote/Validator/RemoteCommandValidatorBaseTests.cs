using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Operation.Remote.Validator;
using TCommand = Undersoft.SDK.Service.Operation.Remote.Command.RemoteCommand;
using TEntity = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Validator;

/// <summary>
/// Unit tests for the type <see cref="RemoteCommandValidatorBase"/>.
/// </summary>
public class RemoteCommandValidatorBase_1Tests
{
    private class TestRemoteCommandValidatorBase : RemoteCommandValidatorBase<TCommand>
    {
        public TestRemoteCommandValidatorBase(IServicer ultimateService) : base(ultimateService)
        {
        }

        public void PublicValidateRequired(string[] propertyNames)
        {
            base.ValidateRequired(propertyNames);
        }

        public void PublicValidateLanguage(string[] propertyNames)
        {
            base.ValidateLanguage(propertyNames);
        }

        public void PublicValidateNotEqual(object item, string[] propertyNames)
        {
            base.ValidateNotEqual(item, propertyNames);
        }

        public void PublicValidateEqual(object item, string[] propertyNames)
        {
            base.ValidateEqual(item, propertyNames);
        }

        public void PublicValidateLength(int min, int max, string[] propertyNames)
        {
            base.ValidateLength(min, max, propertyNames);
        }

        public void PublicValidateEnum(string[] propertyNames)
        {
            base.ValidateEnum(propertyNames);
        }

        public void PublicValidateEmail(string[] emailPropertyNames)
        {
            base.ValidateEmail(emailPropertyNames);
        }

        public void PublicValidateExist<TStore, TEntity>(LogicOperand operand, string[] propertyNames)
        {
            base.ValidateExist<TStore, TEntity>(operand, propertyNames
                                                                         );
        }

        public void PublicValidateNotExist<TStore, TEntity>(LogicOperand operand, string[] propertyNames)
        {
            base.ValidateNotExist<TStore, TEntity>(operand, propertyNames
                                                                         );
        }
    }

    private TestRemoteCommandValidatorBase _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _ultimateService;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteCommandValidatorBase"/>.
    /// </summary>
    public RemoteCommandValidatorBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._ultimateService = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestRemoteCommandValidatorBase>();
    }

    /// <summary>
    /// Checks that instance construction throws when the ultimateService parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullUltimateService()
    {
        FluentActions.Invoking(() => new TestRemoteCommandValidatorBase(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("ultimateService");
    }

    /// <summary>
    /// Checks that the PublicValidateRequired method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateRequired()
    {
        // Arrange
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateRequired(propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateRequired method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateRequiredWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateRequired(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateLanguage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateLanguage()
    {
        // Arrange
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateLanguage(propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateLanguage method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateLanguageWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateLanguage(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateNotEqual()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateNotEqual(item, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotEqualWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotEqual(default(object), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotEqualWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotEqual(_fixture.Create<object>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEqual()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateEqual(item, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEqualWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEqual(default(object), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEqualWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEqual(_fixture.Create<object>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateLength method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateLength()
    {
        // Arrange
        var min = _fixture.Create<int>();
        var max = _fixture.Create<int>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateLength(min, max, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateLength method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateLengthWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateLength(_fixture.Create<int>(), _fixture.Create<int>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateEnum method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEnum()
    {
        // Arrange
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateEnum(propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateEnum method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEnumWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEnum(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateEmail method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEmail()
    {
        // Arrange
        var emailPropertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateEmail(emailPropertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateEmail method throws when the emailPropertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEmailWithNullEmailPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEmail(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("emailPropertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateExist()
    {
        // Arrange
        var operand = _fixture.Create<LogicOperand>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateExist<TStore, TEntity>(operand, propertyNames
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateExistWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateExist<TStore, TEntity>(_fixture.Create<LogicOperand>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateNotExist()
    {
        // Arrange
        var operand = _fixture.Create<LogicOperand>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        this._testClass.PublicValidateNotExist<TStore, TEntity>(operand, propertyNames
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotExistWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotExist<TStore, TEntity>(_fixture.Create<LogicOperand>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }
}