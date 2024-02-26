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
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTDtoAndTEntity()
    {
        // Arrange
        var model = _fixture.Create<TDto>();
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Map<TDto>(model, entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTDtoAndTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDto>(_fixture.Create<TDto>(), default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTEntityAndTDto()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        var model = _fixture.Create<TDto>();

        // Act
        var result = this._testClass.Map<TDto>(entity, model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTEntityAndTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDto>(default(TEntity), _fixture.Create<TDto>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTDtoAndIEnumerableOfTDtoAndIEnumerableOfTEntity()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.Map<TDto>(model, entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTDtoAndIEnumerableOfTDtoAndIEnumerableOfTEntityWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDto>(default(IEnumerable<TDto>), _fixture.Create<IEnumerable<TEntity>>())).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the Map method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTDtoAndIEnumerableOfTDtoAndIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTDtoAndIEnumerableOfTEntityAndIEnumerableOfTDto()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.Map<TDto>(entity, model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTDtoAndIEnumerableOfTEntityAndIEnumerableOfTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDto>(default(IEnumerable<TEntity>), _fixture.Create<IEnumerable<TDto>>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Map method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTDtoAndIEnumerableOfTEntityAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDto>(_fixture.Create<IEnumerable<TEntity>>(), default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the HashMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHashMapWithTDtoAndIEnumerableOfTDtoAndIEnumerableOfTEntity()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.HashMap<TDto>(model, entity
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HashMap method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHashMapWithTDtoAndIEnumerableOfTDtoAndIEnumerableOfTEntityWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.HashMap<TDto>(default(IEnumerable<TDto>), _fixture.Create<IEnumerable<TEntity>>())).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the HashMap method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHashMapWithTDtoAndIEnumerableOfTDtoAndIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.HashMap<TDto>(_fixture.Create<IEnumerable<TDto>>(), default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the HashMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHashMapWithTDtoAndIEnumerableOfTEntityAndIEnumerableOfTDto()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.HashMap<TDto>(entity, model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HashMap method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHashMapWithTDtoAndIEnumerableOfTEntityAndIEnumerableOfTDtoWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.HashMap<TDto>(default(IEnumerable<TEntity>), _fixture.Create<IEnumerable<TDto>>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the HashMap method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHashMapWithTDtoAndIEnumerableOfTEntityAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.HashMap<TDto>(_fixture.Create<IEnumerable<TEntity>>(), default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the MapTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapToWithTEntity()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.MapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapTo method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapToWithTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.MapTo<TDto>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the MapTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapToWithObject()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        var result = this._testClass.MapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapTo method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapToWithObjectWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.MapTo<TDto>(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the MapFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapFromWithTDto()
    {
        // Arrange
        var model = _fixture.Create<TDto>();

        // Act
        var result = this._testClass.MapFrom<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapFromWithObject()
    {
        // Arrange
        var model = _fixture.Create<object>();

        // Act
        var result = this._testClass.MapFrom<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapFrom method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapFromWithObjectWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.MapFrom<TDto>(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the MapTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapToWithTDtoAndIEnumerableOfObject()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<object>>();

        // Act
        var result = this._testClass.MapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapTo method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapToWithTDtoAndIEnumerableOfObjectWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.MapTo<TDto>(default(IEnumerable<object>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the MapTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapToWithTDtoAndIEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.MapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapTo method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapToWithTDtoAndIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.MapTo<TDto>(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the MapToAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapToAsync()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.MapToAsync<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapToAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapToAsyncWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.MapToAsync<TDto>(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the MapFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapFromWithTDtoAndIEnumerableOfTDto()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.MapFrom<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapFrom method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapFromWithTDtoAndIEnumerableOfTDtoWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.MapFrom<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the MapFromAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapFromAsync()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = this._testClass.MapFromAsync<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapFromAsync method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapFromAsyncWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.MapFromAsync<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the HashMapTo method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHashMapToWithTDtoAndIEnumerableOfObjectAsync()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<object>>();

        // Act
        var result = await this._testClass.HashMapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HashMapTo method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHashMapToWithTDtoAndIEnumerableOfObjectWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.HashMapTo<TDto>(default(IEnumerable<object>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the YieldMapTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallYieldMapTo()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.YieldMapTo<TDto>(entities);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the YieldMapTo method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallYieldMapToWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.YieldMapTo<TDto>(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the HashMapTo method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHashMapToWithTDtoAndIEnumerableOfTEntityAsync()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = await this._testClass.HashMapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HashMapTo method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHashMapToWithTDtoAndIEnumerableOfTEntityWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.HashMapTo<TDto>(default(IEnumerable<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the HashMapFrom method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHashMapFromAsync()
    {
        // Arrange
        var model = _fixture.Create<IEnumerable<TDto>>();

        // Act
        var result = await this._testClass.HashMapFrom<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HashMapFrom method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHashMapFromWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.HashMapFrom<TDto>(default(IEnumerable<TDto>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the QueryMapAsyncTo method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallQueryMapAsyncToAsync()
    {
        // Arrange
        var entity = _fixture.Create<IQueryable<TEntity>>();

        // Act
        var result = await this._testClass.QueryMapAsyncTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the QueryMapAsyncTo method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallQueryMapAsyncToWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.QueryMapAsyncTo<TDto>(default(IQueryable<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the QueryMapTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryMapTo()
    {
        // Arrange
        var entity = _fixture.Create<IQueryable<TEntity>>();

        // Act
        var result = this._testClass.QueryMapTo<TDto>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the QueryMapTo method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryMapToWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.QueryMapTo<TDto>(default(IQueryable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the QueryMapFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryMapFrom()
    {
        // Arrange
        var model = _fixture.Create<IQueryable<TDto>>();

        // Act
        var result = this._testClass.QueryMapFrom<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the QueryMapFrom method throws when the model parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryMapFromWithNullModel()
    {
        FluentActions.Invoking(() => this._testClass.QueryMapFrom<TDto>(default(IQueryable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("model");
    }

    /// <summary>
    /// Checks that the QueryMapAsyncFrom method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallQueryMapAsyncFromAsync()
    {
        // Arrange
        var model = _fixture.Create<IQueryable<TDto>>();

        // Act
        var result = await this._testClass.QueryMapAsyncFrom<TDto>(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the QueryMapAsyncFrom method throws when the model parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallQueryMapAsyncFromWithNullModelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.QueryMapAsyncFrom<TDto>(default(IQueryable<TDto>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("model");
    }
}