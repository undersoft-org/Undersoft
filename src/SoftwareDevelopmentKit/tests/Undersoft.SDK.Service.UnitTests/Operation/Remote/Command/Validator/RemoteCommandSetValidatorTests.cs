using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Remote.Command.Validator;
using T = System.String;
using TDto = System.String;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command.Validator;

/// <summary>
/// Unit tests for the type <see cref="RemoteCommandSetValidator"/>.
/// </summary>
public class RemoteCommandSetValidator_1Tests
{
    private class TestRemoteCommandSetValidator : RemoteCommandSetValidator<TModel>
    {
        public TestRemoteCommandSetValidator(IServicer ultimateService) : base(ultimateService)
        {
        }

        public void PublicValidationScope<T>(OperationType commandMode, Action validations)
        {
            base.ValidationScope<T>(commandMode, validations);
        }

        public void PublicValidationScope(Type @type, OperationType commandMode, Action validations)
        {
            base.ValidationScope(type, commandMode, validations);
        }

        public void PublicValidationScope(OperationType commandMode, Action validations)
        {
            base.ValidationScope(commandMode, validations);
        }

        public void PublicValidateLimit(int min, int max)
        {
            base.ValidateLimit(min, max);
        }

        public void PublicValidateRequired(Expression<Func<RemoteCommand<TModel>, object>>[] members)
        {
            base.ValidateRequired(members);
        }

        public void PublicValidateEmail(Expression<Func<RemoteCommand<TModel>, string>>[] members)
        {
            base.ValidateEmail(members);
        }

        public void PublicValidateLength(int min, int max, Expression<Func<RemoteCommand<TModel>, object>>[] members)
        {
            base.ValidateLength(min, max, members
);
        }

        public void PublicValidateCount(int min, int max, Expression<Func<RemoteCommand<TModel>, object>>[] members)
        {
            base.ValidateCount(min, max, members
);
        }

        public void PublicValidateEnum(Expression<Func<RemoteCommand<TModel>, string>>[] members)
        {
            base.ValidateEnum(members);
        }

        public void PublicValidateNotEqual(object item, Expression<Func<RemoteCommand<TModel>, object>>[] members)
        {
            base.ValidateNotEqual(item, members
);
        }

        public void PublicValidateEqual(object item, Expression<Func<RemoteCommand<TModel>, object>>[] members)
        {
            base.ValidateEqual(item, members
);
        }

        public void PublicValidateLanguage(Expression<Func<RemoteCommand<TModel>, object>>[] members)
        {
            base.ValidateLanguage(members);
        }

        public void PublicValidateExist<TStore, TDto>(Func<TModel, Expression<Func<TDto, bool>>> command, string message)
        {
            base.ValidateExist<TStore, TDto>(command, message);
        }

        public void PublicValidateNotExist<TStore, TDto>(Func<TModel, Expression<Func<TDto, bool>>> command, string message)
        {
            base.ValidateNotExist<TStore, TDto>(command, message);
        }
    }

    private TestRemoteCommandSetValidator _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _ultimateService;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteCommandSetValidator"/>.
    /// </summary>
    public RemoteCommandSetValidator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._ultimateService = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestRemoteCommandSetValidator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRemoteCommandSetValidator(this._ultimateService.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the ultimateService parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullUltimateService()
    {
        FluentActions.Invoking(() => new TestRemoteCommandSetValidator(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("ultimateService");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidationScopeWithTAndOperationTypeAndAction()
    {
        // Arrange
        var commandMode = _fixture.Create<OperationType>();
        Action validations = () => { };

        // Act
        this._testClass.PublicValidationScope<T>(commandMode, validations);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the validations parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithTAndOperationTypeAndActionWithNullValidations()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope<T>(_fixture.Create<OperationType>(), default(Action))).Should().Throw<ArgumentNullException>().WithParameterName("validations");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidationScopeWithTypeAndCommandModeAndValidations()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var commandMode = _fixture.Create<OperationType>();
        Action validations = () => { };

        // Act
        this._testClass.PublicValidationScope(type, commandMode, validations);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithTypeAndCommandModeAndValidationsWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope(default(Type), _fixture.Create<OperationType>(), () => { })).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the validations parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithTypeAndCommandModeAndValidationsWithNullValidations()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope(_fixture.Create<Type>(), _fixture.Create<OperationType>(), default(Action))).Should().Throw<ArgumentNullException>().WithParameterName("validations");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidationScopeWithOperationTypeAndAction()
    {
        // Arrange
        var commandMode = _fixture.Create<OperationType>();
        Action validations = () => { };

        // Act
        this._testClass.PublicValidationScope(commandMode, validations);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the validations parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithOperationTypeAndActionWithNullValidations()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope(_fixture.Create<OperationType>(), default(Action))).Should().Throw<ArgumentNullException>().WithParameterName("validations");
    }

    /// <summary>
    /// Checks that the PublicValidateLimit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateLimit()
    {
        // Arrange
        var min = _fixture.Create<int>();
        var max = _fixture.Create<int>();

        // Act
        this._testClass.PublicValidateLimit(min, max);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateRequired method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateRequired()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>();

        // Act
        this._testClass.PublicValidateRequired(members);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateRequired method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateRequiredWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateRequired(default(Expression<Func<RemoteCommand<TModel>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateEmail method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEmail()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, string>>[]>();

        // Act
        this._testClass.PublicValidateEmail(members);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateEmail method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEmailWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEmail(default(Expression<Func<RemoteCommand<TModel>, string>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
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
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>();

        // Act
        this._testClass.PublicValidateLength(min, max, members
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateLength method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateLengthWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateLength(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<RemoteCommand<TModel>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateCount()
    {
        // Arrange
        var min = _fixture.Create<int>();
        var max = _fixture.Create<int>();
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>();

        // Act
        this._testClass.PublicValidateCount(min, max, members
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateCount method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateCountWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateCount(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<RemoteCommand<TModel>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateEnum method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEnum()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, string>>[]>();

        // Act
        this._testClass.PublicValidateEnum(members);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateEnum method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEnumWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEnum(default(Expression<Func<RemoteCommand<TModel>, string>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateNotEqual()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>();

        // Act
        this._testClass.PublicValidateNotEqual(item, members
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotEqualWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotEqual(default(object), _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotEqualWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotEqual(_fixture.Create<object>(), default(Expression<Func<RemoteCommand<TModel>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEqual()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>();

        // Act
        this._testClass.PublicValidateEqual(item, members
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEqualWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEqual(default(object), _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEqualWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEqual(_fixture.Create<object>(), default(Expression<Func<RemoteCommand<TModel>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateLanguage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateLanguage()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<RemoteCommand<TModel>, object>>[]>();

        // Act
        this._testClass.PublicValidateLanguage(members);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateLanguage method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateLanguageWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateLanguage(default(Expression<Func<RemoteCommand<TModel>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateExist()
    {
        // Arrange
        Func<TModel, Expression<Func<TDto, bool>>> command = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        var message = _fixture.Create<string>();

        // Act
        this._testClass.PublicValidateExist<TStore, TDto>(command, message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateExistWithNullCommand()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateExist<TStore, TDto>(default(Func<TModel, Expression<Func<TDto, bool>>>), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValidateExistWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateExist<TStore, TDto>(x => _fixture.Create<Expression<Func<TDto, bool>>>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateNotExist()
    {
        // Arrange
        Func<TModel, Expression<Func<TDto, bool>>> command = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        var message = _fixture.Create<string>();

        // Act
        this._testClass.PublicValidateNotExist<TStore, TDto>(command, message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotExistWithNullCommand()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotExist<TStore, TDto>(default(Func<TModel, Expression<Func<TDto, bool>>>), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValidateNotExistWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotExist<TStore, TDto>(x => _fixture.Create<Expression<Func<TDto, bool>>>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}