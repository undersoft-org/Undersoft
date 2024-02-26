using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;
using TDto = System.String;
using TEntity = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="Repository"/>.
/// </summary>
public partial class Repository_1Tests
{
    private Repository<TEntity> _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryClient> _repositorySourceIRepositoryClient;
    private Mock<IRepositorySource> _repositorySourceIRepositorySource;
    private object _contextObject;
    private Mock<IRepositoryContext> _contextIRepositoryContext;
    private Mock<IQueryProvider> _provider;
    private Expression _expression;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Repository"/>.
    /// </summary>
    public Repository_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repositorySourceIRepositoryClient = _fixture.Freeze<Mock<IRepositoryClient>>();
        this._repositorySourceIRepositorySource = _fixture.Freeze<Mock<IRepositorySource>>();
        this._contextObject = _fixture.Create<object>();
        this._contextIRepositoryContext = _fixture.Freeze<Mock<IRepositoryContext>>();
        this._provider = _fixture.Freeze<Mock<IQueryProvider>>();
        this._expression = _fixture.Create<Expression>();
        this._testClass = _fixture.Create<Repository<TEntity>>();
    }

    /// <summary>
    /// Checks that the AddBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddByWithTDtoAndTDto()
    {
        // Arrange
        var model = _fixture.Create<TDto>();

        // Act
        var result = this._testClass.AddBy<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddByWithTDtoAndTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.AddBy<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddBy method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByWithTDtoAndTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.AddBy<TDto>(_fixture.Create<TDto>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the AddByAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddByAsyncWithTDtoAndTDtoAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.AddByAsync<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddByAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddByAsyncWithTDtoAndTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.AddByAsync<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddByAsync method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallAddByAsyncWithTDtoAndTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.AddByAsync<TDto>(_fixture.Create<TDto>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the AddBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddByWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.AddBy<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddBy method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByWithTDtoAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.AddBy<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the AddBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TDto>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.AddBy<TDto>(models, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddBy method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.AddBy<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the AddBy method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.AddBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the AddByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddByAsyncWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.AddByAsync<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddByAsync method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByAsyncWithTDtoAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.AddByAsync<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the AddByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TDto>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.AddByAsync<TDto>(models, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddByAsync method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.AddByAsync<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the AddByAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.AddByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the DeleteBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteByWithTDtoAndTDtoAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.DeleteBy<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.DeleteBy<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteBy method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallDeleteByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.DeleteBy<TDto>(_fixture.Create<TDto>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the DeleteBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteByWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.DeleteBy<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteBy method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteByWithTDtoAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.DeleteBy<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the DeleteBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.DeleteBy<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteBy method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.DeleteBy<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the DeleteBy method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.DeleteBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the DeleteByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteByAsyncWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.DeleteByAsync<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteByAsync method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteByAsyncWithTDtoAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.DeleteByAsync<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the DeleteByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.DeleteByAsync<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteByAsync method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.DeleteByAsync<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the DeleteByAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.DeleteByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetByWithTDtoAndTDtoAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.SetBy<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndTDtoWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the SetBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetByWithTDtoAndTDtoAndArrayOfObjectAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        var keys = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.SetBy<TDto>(model, keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndTDtoAndArrayOfObjectWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(default(TDto), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndTDtoAndArrayOfObjectWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(_fixture.Create<TDto>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the SetBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetByWithTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = await this._testClass.SetBy<TDto>(model, predicate, conditions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(default(TDto), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(_fixture.Create<TDto>(), default(Func<TDto, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the conditions parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullConditionsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(_fixture.Create<TDto>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the SetBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetByWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.SetBy<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByWithTDtoAndIEnumerableOfTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.SetBy<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the SetBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.SetBy<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(default(TDto), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetBy<TDto>(_fixture.Create<TDto>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TDto>>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.SetBy<TDto>(models, predicate, conditions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.SetBy<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.SetBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetBy method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.SetBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the SetByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetByAsyncWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.SetByAsync<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetByAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByAsyncWithTDtoAndIEnumerableOfTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.SetByAsync<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the SetByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TDto>>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.SetByAsync<TDto>(models, predicate, conditions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetByAsync method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.SetByAsync<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the SetByAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.SetByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TDto, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetByAsync method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.SetByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the PutBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutByWithTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = await this._testClass.PutBy<TDto>(model, predicate, conditions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutBy method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutByWithTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PutBy<TDto>(_fixture.Create<TDto>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PutBy method throws when the conditions parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutByWithTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullConditionsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PutBy<TDto>(_fixture.Create<TDto>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the PutBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.PutBy<TDto>(model, predicate, conditions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutBy method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.PutBy<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the PutBy method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PutBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PutBy method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutByWithTDtoAndIEnumerableOfTDtoAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.PutBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the PutByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutByAsync()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.PutByAsync<TDto>(model, predicate, conditions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutByAsync method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutByAsyncWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.PutByAsync<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the PutByAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutByAsyncWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PutByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PutByAsync method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutByAsyncWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.PutByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the PatchBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchByWithTDtoAndTDtoAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.PatchBy<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchByWithTDtoAndTDtoWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the PatchBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchByWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.PatchBy<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchByWithTDtoAndIEnumerableOfTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the PatchBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchByWithTDtoAndTDtoAndArrayOfObjectAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        var keys = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.PatchBy<TDto>(model, keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchByWithTDtoAndTDtoAndArrayOfObjectWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(default(TDto), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchByWithTDtoAndTDtoAndArrayOfObjectWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(_fixture.Create<TDto>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the PatchBy method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.PatchBy<TDto>(model, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(default(TDto), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchByWithTDtoAndTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(_fixture.Create<TDto>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PatchBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TDto>>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.PatchBy<TDto>(models, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the PatchBy method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchByWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PatchBy<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PatchByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchByAsyncWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.PatchByAsync<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchByAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchByAsyncWithTDtoAndIEnumerableOfTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.PatchByAsync<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the PatchByAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TDto>>();
        Func<TDto, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.PatchByAsync<TDto>(models, predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchByAsync method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.PatchByAsync<TDto>(default(IEnumerable<TDto>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the PatchByAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchByAsyncWithTDtoAndIEnumerableOfTDtoAndFuncOfTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PatchByAsync<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}