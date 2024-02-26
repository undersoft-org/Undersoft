using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Command.Validator;
using T = System.String;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Validator;

/// <summary>
/// Unit tests for the type <see cref="CommandValidator"/>.
/// </summary>
public class CommandValidator_1Tests
{
    private class TestCommandValidator : CommandValidator<TDto>
    {
        public TestCommandValidator(IServicer ultimateService) : base(ultimateService)
        {
        }

        public void PublicValidationScope<T>(OperationType commandMode, Action actions)
        {
            base.ValidationScope<T>(commandMode, actions);
        }

        public void PublicValidationScope(Type @type, OperationType commandMode, Action actions)
        {
            base.ValidationScope(type, commandMode, actions);
        }

        public void PublicValidationScope(OperationType commandMode, Action actions)
        {
            base.ValidationScope(commandMode, actions);
        }

        public void PublicValidateRequired(Expression<Func<Command<TDto>, object>>[] members)
        {
            base.ValidateRequired(members);
        }

        public void PublicValidateEmail(Expression<Func<Command<TDto>, string>>[] members)
        {
            base.ValidateEmail(members);
        }

        public void PublicValidateLength(int min, int max, Expression<Func<Command<TDto>, string>>[] members)
        {
            base.ValidateLength(min, max, members
);
        }

        public void PublicValidateCount(int min, int max, Expression<Func<Command<TDto>, ICollection>>[] members)
        {
            base.ValidateCount(min, max, members
);
        }

        public void PublicValidateEnum(Expression<Func<Command<TDto>, string>>[] members)
        {
            base.ValidateEnum(members);
        }

        public void PublicValidateNotEqual(object item, Expression<Func<Command<TDto>, object>>[] members)
        {
            base.ValidateNotEqual(item, members
);
        }

        public void PublicValidateEqual(object item, Expression<Func<Command<TDto>, object>>[] members)
        {
            base.ValidateEqual(item, members
);
        }

        public void PublicValidateLanguage(Expression<Func<Command<TDto>, object>>[] members)
        {
            base.ValidateLanguage(members);
        }

        public void PublicValidateExist<TStore, TEntity>(Func<TDto, Expression<Func<TEntity, bool>>> command)
        {
            base.ValidateExist<TStore, TEntity>(command
);
        }

        public void PublicValidateNotExist<TStore, TEntity>(Func<TDto, Expression<Func<TEntity, bool>>> command)
        {
            base.ValidateNotExist<TStore, TEntity>(command
);
        }
    }

    private TestCommandValidator _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _ultimateService;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandValidator"/>.
    /// </summary>
    public CommandValidator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._ultimateService = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestCommandValidator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestCommandValidator(this._ultimateService.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the ultimateService parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullUltimateService()
    {
        FluentActions.Invoking(() => new TestCommandValidator(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("ultimateService");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidationScopeWithTAndOperationTypeAndAction()
    {
        // Arrange
        var commandMode = _fixture.Create<OperationType>();
        Action actions = () => { };

        // Act
        this._testClass.PublicValidationScope<T>(commandMode, actions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the actions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithTAndOperationTypeAndActionWithNullActions()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope<T>(_fixture.Create<OperationType>(), default(Action))).Should().Throw<ArgumentNullException>().WithParameterName("actions");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidationScopeWithTypeAndCommandModeAndActions()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var commandMode = _fixture.Create<OperationType>();
        Action actions = () => { };

        // Act
        this._testClass.PublicValidationScope(type, commandMode, actions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithTypeAndCommandModeAndActionsWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope(default(Type), _fixture.Create<OperationType>(), () => { })).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the actions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithTypeAndCommandModeAndActionsWithNullActions()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope(_fixture.Create<Type>(), _fixture.Create<OperationType>(), default(Action))).Should().Throw<ArgumentNullException>().WithParameterName("actions");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidationScopeWithOperationTypeAndAction()
    {
        // Arrange
        var commandMode = _fixture.Create<OperationType>();
        Action actions = () => { };

        // Act
        this._testClass.PublicValidationScope(commandMode, actions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidationScope method throws when the actions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidationScopeWithOperationTypeAndActionWithNullActions()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidationScope(_fixture.Create<OperationType>(), default(Action))).Should().Throw<ArgumentNullException>().WithParameterName("actions");
    }

    /// <summary>
    /// Checks that the PublicValidateRequired method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateRequired()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<Command<TDto>, object>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateRequired(default(Expression<Func<Command<TDto>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateEmail method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEmail()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<Command<TDto>, string>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateEmail(default(Expression<Func<Command<TDto>, string>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
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
        var members = _fixture.Create<Expression<Func<Command<TDto>, string>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateLength(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<Command<TDto>, string>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
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
        var members = _fixture.Create<Expression<Func<Command<TDto>, ICollection>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateCount(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<Command<TDto>, ICollection>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateEnum method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEnum()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<Command<TDto>, string>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateEnum(default(Expression<Func<Command<TDto>, string>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateNotEqual()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var members = _fixture.Create<Expression<Func<Command<TDto>, object>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateNotEqual(default(object), _fixture.Create<Expression<Func<Command<TDto>, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicValidateNotEqual method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotEqualWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotEqual(_fixture.Create<object>(), default(Expression<Func<Command<TDto>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateEqual()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var members = _fixture.Create<Expression<Func<Command<TDto>, object>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateEqual(default(object), _fixture.Create<Expression<Func<Command<TDto>, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicValidateEqual method throws when the members parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateEqualWithNullMembers()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateEqual(_fixture.Create<object>(), default(Expression<Func<Command<TDto>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateLanguage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateLanguage()
    {
        // Arrange
        var members = _fixture.Create<Expression<Func<Command<TDto>, object>>[]>();

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
        FluentActions.Invoking(() => this._testClass.PublicValidateLanguage(default(Expression<Func<Command<TDto>, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("members");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateExist()
    {
        // Arrange
        Func<TDto, Expression<Func<TEntity, bool>>> command = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        this._testClass.PublicValidateExist<TStore, TEntity>(command
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateExist method throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateExistWithNullCommand()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateExist<TStore, TEntity>(default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValidateNotExist()
    {
        // Arrange
        Func<TDto, Expression<Func<TEntity, bool>>> command = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        this._testClass.PublicValidateNotExist<TStore, TEntity>(command
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicValidateNotExist method throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValidateNotExistWithNullCommand()
    {
        FluentActions.Invoking(() => this._testClass.PublicValidateNotExist<TStore, TEntity>(default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}