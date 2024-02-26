using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;
using TEntity = Undersoft.SDK.Stocks.StockContext;

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
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRepository();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepository(this._repositorySourceIRepositoryClient.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepository(this._repositorySourceIRepositorySource.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepository(this._contextObject);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepository(this._contextIRepositoryContext.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepository(this._provider.Object, this._expression);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repositorySource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepositorySource()
    {
        FluentActions.Invoking(() => new TestRepository(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("repositorySource");
        FluentActions.Invoking(() => new TestRepository(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("repositorySource");
    }

    /// <summary>
    /// Checks that instance construction throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContext()
    {
        FluentActions.Invoking(() => new TestRepository(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("context");
        FluentActions.Invoking(() => new TestRepository(default(IRepositoryContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that instance construction throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProvider()
    {
        FluentActions.Invoking(() => new TestRepository(default(IQueryProvider), this._expression)).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that instance construction throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpression()
    {
        FluentActions.Invoking(() => new TestRepository(this._provider.Object, default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorWithNoParameters()
    {
        // Act
        var result = this._testClass.GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRemotesEvent method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadRemotesEvent()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var e = _fixture.Create<EntityEntryEventArgs>();

        // Act
        this._testClass.LoadRemotesEvent(sender, e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRemotesEvent method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadRemotesEventWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.LoadRemotesEvent(default(object), _fixture.Create<EntityEntryEventArgs>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the LoadRemotesEvent method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadRemotesEventWithNullE()
    {
        FluentActions.Invoking(() => this._testClass.LoadRemotesEvent(_fixture.Create<object>(), default(EntityEntryEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the Sign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSign()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Sign(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sign method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSignWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Sign(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Stamp method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStamp()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Stamp(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Stamp method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStampWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Stamp(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorForIEnumerableWithNoParameters()
    {
        // Act
        var result = ((IEnumerable)this._testClass).GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HasNextPage property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHasNextPage()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.HasNextPage = testValue;

        // Assert
        this._testClass.HasNextPage.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the HasPreviousPage property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHasPreviousPage()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.HasPreviousPage = testValue;

        // Assert
        this._testClass.HasPreviousPage.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the IndexFrom property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexFrom()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.IndexFrom = testValue;

        // Assert
        this._testClass.IndexFrom.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Items property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItems()
    {
        // Arrange
        var testValue = _fixture.Create<IList<TEntity>>();

        // Act
        this._testClass.Items = testValue;

        // Assert
        this._testClass.Items.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the PageIndex property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPageIndex()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.PageIndex = testValue;

        // Assert
        this._testClass.PageIndex.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PageSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPageSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.PageSize = testValue;

        // Assert
        this._testClass.PageSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TotalCount property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTotalCount()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.TotalCount = testValue;

        // Assert
        this._testClass.TotalCount.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TotalPages property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTotalPages()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.TotalPages = testValue;

        // Assert
        this._testClass.TotalPages.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Query property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetQuery()
    {
        // Assert
        this._testClass.Query.Should().BeAssignableTo<IQueryable<TEntity>>();

        Assert.Fail("Create or modify test");
    }
}