using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Store;
using TEntity = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Store;

/// <summary>
/// Unit tests for the type <see cref="DataStoreContext"/>.
/// </summary>
public class DataStoreContext_1Tests
{
    private class TestDataStoreContext : DataStoreContext<TStore>
    {
        public TestDataStoreContext(DbContextOptions options, IServicer servicer = null) : base(options, servicer)
        {
        }

        public Type PublicStoreType => base.StoreType;
    }

    private TestDataStoreContext _testClass;
    private IFixture _fixture;
    private DbContextOptions _options;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataStoreContext"/>.
    /// </summary>
    public DataStoreContext_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<DbContextOptions>();
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestDataStoreContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestDataStoreContext(this._options, this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestDataStoreContext(default(DbContextOptions), this._servicer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the PublicStoreType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicStoreType()
    {
        // Assert
        this._testClass.PublicStoreType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="DataStoreContext"/>.
/// </summary>
public class DataStoreContextTests
{
    private DataStoreContext _testClass;
    private IFixture _fixture;
    private DbContextOptions _options;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataStoreContext"/>.
    /// </summary>
    public DataStoreContextTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<DbContextOptions>();
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<DataStoreContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DataStoreContext(this._options, this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new DataStoreContext(default(DbContextOptions), this._servicer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("options");
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
    /// Checks that the AttachProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAttachProperty()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var propertyName = _fixture.Create<string>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.AttachProperty(item, propertyName, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AttachProperty method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAttachPropertyWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.AttachProperty(default(object), _fixture.Create<string>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
        var result = await this._testClass.AddAsync<TEntity>(entity, cancellationToken);

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
    /// Checks that the Model property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetModel()
    {
        // Assert
        this._testClass.Model.Should().BeAssignableTo<IModel>();

        Assert.Fail("Create or modify test");
    }
}