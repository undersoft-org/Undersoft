using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;
using TContext = Microsoft.EntityFrameworkCore.DbContext;
using TEntity = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountStore"/>.
/// </summary>
[TestClass]
public partial class AccountStore_2Tests
{
    private AccountStore<TStore, TContext> _testClass;
    private IFixture _fixture;
    private DbContextOptions<TContext> _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountStore"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<DbContextOptions<TContext>>();
        this._testClass = _fixture.Create<AccountStore<TStore, TContext>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountStore<TStore, TContext>(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new AccountStore<TStore, TContext>(default(DbContextOptions<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountStoreContext"/>.
/// </summary>
[TestClass]
public partial class AccountStoreContext_1Tests
{
    private class TestAccountStoreContext : AccountStoreContext<TStore>
    {
        public TestAccountStoreContext(DbContextOptions options) : base(options)
        {
        }

        public void PublicOnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    private TestAccountStoreContext _testClass;
    private IFixture _fixture;
    private DbContextOptions _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountStoreContext"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<DbContextOptions>();
        this._testClass = _fixture.Create<TestAccountStoreContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestAccountStoreContext(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestAccountStoreContext(default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the PublicOnModelCreating method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnModelCreating()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();

        // Act
        this._testClass.PublicOnModelCreating(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnModelCreating method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnModelCreatingWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnModelCreating(default(ModelBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the EntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEntitySetWithTEntity()
    {
        // Act
        var result = this._testClass.EntitySet<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEntitySetWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.EntitySet(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EntitySet method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEntitySetWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.EntitySet(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQuery()
    {
        // Act
        var result = this._testClass.Query<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTEntityAndTEntity()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Add<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTEntityAndTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add<TEntity>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddAsync()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.AddAsync<TEntity>(entity, cancellationToken
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallAddAsyncWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.AddAsync<TEntity>(default(TEntity), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObject()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        var result = this._testClass.Add(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
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
        var result = this._testClass.Update<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Update<TEntity>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Remove<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Remove<TEntity>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Attach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAttachWithObject()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        var result = this._testClass.Attach(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Attach method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAttachWithObjectWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Attach(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Attach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAttachWithTEntityAndTEntity()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Attach<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Attach method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAttachWithTEntityAndTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Attach<TEntity>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AttachProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAttachProperty()
    {
        // Arrange
        var entity = _fixture.Create<object>();
        var propertyName = _fixture.Create<string>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.AttachProperty(entity, propertyName, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AttachProperty method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAttachPropertyWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.AttachProperty(default(object), _fixture.Create<string>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AttachProperty method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAttachPropertyWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => this._testClass.AttachProperty(_fixture.Create<object>(), value, _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the Save method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var asTransaction = _fixture.Create<bool>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Save(asTransaction, token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Accounts property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccounts()
    {
        // Arrange
        var testValue = _fixture.Create<DbSet<Account>>();

        // Act
        this._testClass.Accounts = testValue;

        // Assert
        this._testClass.Accounts.Should().BeSameAs(testValue);
    }
}