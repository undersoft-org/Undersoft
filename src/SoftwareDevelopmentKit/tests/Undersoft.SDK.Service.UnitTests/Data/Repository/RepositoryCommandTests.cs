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
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TModel = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="Repository"/>.
/// </summary>
public partial class Repository_1Tests
{
    private class TestRepository : Repository<TEntity>
    {
        public TestRepository() : base()
        {
        }

        public TestRepository(IRepositoryClient repositorySource) : base(repositorySource)
        {
        }

        public TestRepository(IRepositorySource repositorySource) : base(repositorySource)
        {
        }

        public TestRepository(object context) : base(context)
        {
        }

        public TestRepository(IRepositoryContext context) : base(context)
        {
        }

        public TestRepository(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        public TEntity PublicInnerSet(TEntity entity)
        {
            return base.InnerSet(entity);
        }

        protected override Task<int> saveAsTransaction(CancellationToken token)
        {
            return default(Task<int>);
        }

        protected override Task<int> saveChanges(CancellationToken token)
        {
            return default(Task<int>);
        }

        public override TEntity NewEntry(object[] parameters)
        {
            return default(TEntity);
        }

        public override TEntity Add(TEntity entity)
        {
            return default(TEntity);
        }

        public override TEntity Delete(TEntity entity)
        {
            return default(TEntity);
        }

        public override IQueryable<TEntity> AsQueryable()
        {
            return default(IQueryable<TEntity>);
        }

        public override TEntity this[] { get; set; }
        public override TEntity this[] { get; set; }
        public override object this[] { get; set; }
        public override IQueryable<TEntity> Query { get; }
    }

    private TestRepository _testClass;
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
        this._testClass = _fixture.Create<TestRepository>();
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.Add(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Add(entities, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<TEntity>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the Add method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<IEnumerable<TEntity>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAsyncWithIEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.AddAsync(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddAsyncWithIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.AddAsync(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAsyncWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.AddAsync(entities, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddAsyncWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.AddAsync(default(IEnumerable<TEntity>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the AddAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddAsyncWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.AddAsync(_fixture.Create<IEnumerable<TEntity>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAsyncWithIAsyncEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IAsyncEnumerable<TEntity>>();

        // Act
        var result = this._testClass.AddAsync(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddAsyncWithIAsyncEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.AddAsync(default(IAsyncEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Add(entity, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(TEntity), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Add method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<TEntity>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithIEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.Delete(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithIds()
    {
        // Arrange
        var ids = _fixture.Create<long[]>();

        // Act
        var result = this._testClass.Delete(ids);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the ids parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithIdsWithNullIds()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(long[]))).Should().Throw<ArgumentNullException>().WithParameterName("ids");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteWithKeyAsync()
    {
        // Arrange
        var key = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Delete(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the key parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallDeleteWithKeyWithNullKeyAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Delete(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithPredicate()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Delete(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithPredicateWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Delete(entity, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(TEntity), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Delete method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Delete(_fixture.Create<TEntity>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Delete(entities, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(IEnumerable<TEntity>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the Delete method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Delete(_fixture.Create<IEnumerable<TEntity>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the DeleteAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteAsyncWithIEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.DeleteAsync(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteAsyncWithIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.DeleteAsync(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the DeleteAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteAsyncWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.DeleteAsync(entities, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteAsync method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteAsyncWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.DeleteAsync(default(IEnumerable<TEntity>), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the DeleteAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteAsyncWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.DeleteAsync(_fixture.Create<IEnumerable<TEntity>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PublicInnerSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerSet()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.PublicInnerSet(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerSet method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerSetWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerSet(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdate()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Update(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Update(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetWithEntityAndKeyAsync()
    {
        // Arrange
        var entity = _fixture.Create<TModel>();
        var key = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Set<TModel>(entity, key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithEntityAndKeyWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(default(TModel), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithEntityAndKeyWithNullKeyAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<TModel>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetWithEntityAndKeyAndConditionAsync()
    {
        // Arrange
        var entity = _fixture.Create<TModel>();
        var key = _fixture.Create<object>();
        Func<TEntity, Expression<Func<TEntity, bool>>> condition = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.Set<TModel>(entity, key, condition
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithEntityAndKeyAndConditionWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(default(TModel), _fixture.Create<object>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithEntityAndKeyAndConditionWithNullKeyAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<TModel>(), default(object), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method throws when the condition parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithEntityAndKeyAndConditionWithNullConditionAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<TModel>(), _fixture.Create<object>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetWithTModelAndTModelAsync()
    {
        // Arrange
        var entity = _fixture.Create<TModel>();

        // Act
        var result = await this._testClass.Set<TModel>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithTModelAndTModelWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithTModelAndIEnumerableOfTModel()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TModel>>();

        // Act
        var result = this._testClass.Set<TModel>(models);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithTModelAndIEnumerableOfTModelWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.Set<TModel>(default(IEnumerable<TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetWithTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var entity = _fixture.Create<TModel>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = await this._testClass.Set<TModel>(entity, predicate, conditions
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(default(TModel), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Set method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<TModel>(), default(Func<TModel, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Set method throws when the conditions parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullConditionsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<TModel>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.Set<TModel>(entities, predicate, conditions
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.Set<TModel>(default(IEnumerable<TModel>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the Set method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<IEnumerable<TModel>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Set method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<IEnumerable<TModel>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the SetAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.SetAsync<TModel>(entities, predicate, conditions
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetAsync method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.SetAsync<TModel>(default(IEnumerable<TModel>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the SetAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.SetAsync<TModel>(_fixture.Create<IEnumerable<TModel>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TModel, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetAsync method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.SetAsync<TModel>(_fixture.Create<IEnumerable<TModel>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetWithTModelAndTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var delta = _fixture.Create<TModel>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.Set<TModel>(delta, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the delta parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithTModelAndTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullDeltaAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(default(TModel), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("delta");
    }

    /// <summary>
    /// Checks that the Set method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetWithTModelAndTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Set<TModel>(_fixture.Create<TModel>(), default(Func<TModel, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the SetAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetAsyncWithTModelAndIEnumerableOfTModel()
    {
        // Arrange
        var models = _fixture.Create<IEnumerable<TModel>>();

        // Act
        var result = this._testClass.SetAsync<TModel>(models);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetAsync method throws when the models parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetAsyncWithTModelAndIEnumerableOfTModelWithNullModels()
    {
        FluentActions.Invoking(() => this._testClass.SetAsync<TModel>(default(IEnumerable<TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("models");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithDeltaAsync()
    {
        // Arrange
        var delta = _fixture.Create<TModel>();

        // Act
        var result = await this._testClass.Patch<TModel>(delta);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the delta parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithDeltaWithNullDeltaAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch<TModel>(default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("delta");
    }

    /// <summary>
    /// Checks that the lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCalllookupWithEntities()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();

        // Act
        var result = this._testClass.lookup<TModel>(entities);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the lookup method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCalllookupWithEntitiesWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.lookup<TModel>(default(IEnumerable<TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCalllookupWithTModelAndTModel()
    {
        // Arrange
        var entity = _fixture.Create<TModel>();

        // Act
        var result = this._testClass.lookup<TModel>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the lookup method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCalllookupWithTModelAndTModelWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.lookup<TModel>(default(TModel))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchWithTModelAndIEnumerableOfTModelAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Patch<TModel>(entities, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithTModelAndIEnumerableOfTModelAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.Patch<TModel>(default(IEnumerable<TModel>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the Patch method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithTModelAndIEnumerableOfTModelAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Patch<TModel>(_fixture.Create<IEnumerable<TModel>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithDeltaAndKeysAsync()
    {
        // Arrange
        var delta = _fixture.Create<TModel>();
        var keys = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Patch<TModel>(delta, keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the delta parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithDeltaAndKeysWithNullDeltaAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch<TModel>(default(TModel), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("delta");
    }

    /// <summary>
    /// Checks that the Patch method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithDeltaAndKeysWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch<TModel>(_fixture.Create<TModel>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithTModelAndTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var delta = _fixture.Create<TModel>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.Patch<TModel>(delta, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the delta parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithTModelAndTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullDeltaAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch<TModel>(default(TModel), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("delta");
    }

    /// <summary>
    /// Checks that the Patch method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithTModelAndTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch<TModel>(_fixture.Create<TModel>(), default(Func<TModel, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Patch<TModel>(entities, predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.Patch<TModel>(default(IEnumerable<TModel>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the Patch method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Patch<TModel>(_fixture.Create<IEnumerable<TModel>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Patch method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Patch<TModel>(_fixture.Create<IEnumerable<TModel>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PatchAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchAsyncWithTModelAndIEnumerableOfTModelAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.PatchAsync<TModel>(entities, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchAsync method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchAsyncWithTModelAndIEnumerableOfTModelAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.PatchAsync<TModel>(default(IEnumerable<TModel>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the PatchAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchAsyncWithTModelAndIEnumerableOfTModelAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.PatchAsync<TModel>(_fixture.Create<IEnumerable<TModel>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PatchAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();
        Func<TModel, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.PatchAsync<TModel>(entities, predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchAsync method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.PatchAsync<TModel>(default(IEnumerable<TModel>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the PatchAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PatchAsync<TModel>(_fixture.Create<IEnumerable<TModel>>(), default(Func<TModel, Expression<Func<TEntity, bool>>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PatchAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchAsyncWithTModelAndIEnumerableOfTModelAndFuncOfTModelAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.PatchAsync<TModel>(_fixture.Create<IEnumerable<TModel>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = await this._testClass.Put(entity, predicate, conditions
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(default(TEntity), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Put method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<TEntity>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Put method throws when the conditions parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullConditionsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<TEntity>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.Put(entities, predicate, conditions
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IEnumerable<TEntity>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the Put method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<IEnumerable<TEntity>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Put method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAndArrayOfFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<IEnumerable<TEntity>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }

    /// <summary>
    /// Checks that the PutAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutAsync()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        var conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        // Act
        var result = this._testClass.PutAsync(entities, predicate, conditions
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutAsync method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutAsyncWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.PutAsync(default(IEnumerable<TEntity>), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the PutAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutAsyncWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PutAsync(_fixture.Create<IEnumerable<TEntity>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>), _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PutAsync method throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutAsyncWithNullConditions()
    {
        FluentActions.Invoking(() => this._testClass.PutAsync(_fixture.Create<IEnumerable<TEntity>>(), x => _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }
}