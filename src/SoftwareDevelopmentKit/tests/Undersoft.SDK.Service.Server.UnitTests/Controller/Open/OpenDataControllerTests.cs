using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Server.Controller.Open;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TKey = System.String;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Open;

/// <summary>
/// Unit tests for the type <see cref="OpenDataController"/>.
/// </summary>
[TestClass]
public class OpenDataController_5Tests
{
    private class TestOpenDataController : OpenDataController<TKey, TStore, TEntity, TDto, TService>
    {
        public TestOpenDataController() : base()
        {
        }

        public TestOpenDataController(IServicer servicer) : base(servicer)
        {
        }

        public TestOpenDataController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, publishMode)
        {
        }

        public TestOpenDataController(
        IServicer servicer,
        Func<TDto, Expression<Func<TEntity, bool>>> predicate,
        Func<TKey, Func<TDto, object>> keysetter,
        Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, predicate, keysetter, keymatcher, publishMode)
        {
        }
    }

    private TestOpenDataController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private EventPublishMode _publishMode;
    private Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    private Func<TKey, Func<TDto, object>> _keysetter;
    private Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenDataController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._keysetter = x => x => _fixture.Create<object>();
        this._keymatcher = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<TestOpenDataController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestOpenDataController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenDataController(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenDataController(this._servicer.Object, this._publishMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenDataController(this._servicer.Object, this._predicate, this._keysetter, this._keymatcher, this._publishMode);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestOpenDataController(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestOpenDataController(default(IServicer), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestOpenDataController(default(IServicer), this._predicate, this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestOpenDataController(this._servicer.Object, default(Func<TDto, Expression<Func<TEntity, bool>>>), this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the keysetter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeysetter()
    {
        FluentActions.Invoking(() => new TestOpenDataController(this._servicer.Object, this._predicate, default(Func<TKey, Func<TDto, object>>), this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keysetter");
    }

    /// <summary>
    /// Checks that instance construction throws when the keymatcher parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeymatcher()
    {
        FluentActions.Invoking(() => new TestOpenDataController(this._servicer.Object, this._predicate, this._keysetter, default(Func<TKey, Expression<Func<TEntity, bool>>>), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keymatcher");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithNoParametersAsync()
    {
        // Act
        var result = await this._testClass.Get();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithTKeyAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();

        // Act
        var result = await this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPostAsync()
    {
        // Arrange
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Post(dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPostWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Patch(key, dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch(_fixture.Create<TKey>(), default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Put(key, dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<TKey>(), default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();

        // Act
        var result = await this._testClass.Delete(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Transformations property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTransformations()
    {
        // Arrange
        Func<IRepository<TEntity>, IQueryable<TEntity>> testValue = x => _fixture.Create<IQueryable<TEntity>>();

        // Act
        this._testClass.Transformations = testValue;

        // Assert
        this._testClass.Transformations.Should().BeSameAs(testValue);
    }
}