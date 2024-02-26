using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Mapper;
using Undersoft.SDK.Service.Data.Remote;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="Repository"/>.
/// </summary>
public class RepositoryTests
{
    private class TestRepository : Repository
    {
        public TestRepository() : base()
        {
        }

        public TestRepository(object context) : base(context)
        {
        }

        public TestRepository(IRepositoryContext context) : base(context)
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public void PublicAuditStateEvent(object sender, EntityEntryEventArgs e)
        {
            base.AuditStateEvent(sender, e);
        }

        protected override Task<int> saveAsTransaction(CancellationToken token)
        {
            return default(Task<int>);
        }

        protected override Task<int> saveChanges(CancellationToken token)
        {
            return default(Task<int>);
        }
    }

    private TestRepository _testClass;
    private IFixture _fixture;
    private object _contextObject;
    private Mock<IRepositoryContext> _contextIRepositoryContext;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Repository"/>.
    /// </summary>
    public RepositoryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._contextObject = _fixture.Create<object>();
        this._contextIRepositoryContext = _fixture.Freeze<Mock<IRepositoryContext>>();
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
        instance = new TestRepository(this._contextObject);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepository(this._contextIRepositoryContext.Object);

        // Assert
        instance.Should().NotBeNull();
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
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Act
        var result = this._testClass.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdBytes()
    {
        // Act
        var result = this._testClass.GetIdBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AreEqually method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAreEqually()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.AreEqually(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AreEqually method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAreEquallyWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.AreEqually(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithDisposing()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithNoParameters()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DisposeAsyncCore method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsyncCoreAsync()
    {
        // Act
        await this._testClass.DisposeAsyncCore();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DisposeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsync()
    {
        // Act
        await this._testClass.DisposeAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetState method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResetState()
    {
        // Act
        this._testClass.ResetState();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetStateAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallResetStateAsync()
    {
        // Arrange
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.ResetStateAsync(cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the Release method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelease()
    {
        // Act
        var result = this._testClass.Release();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallReleaseAsync()
    {
        // Arrange
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.ReleaseAsync(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lease method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLease()
    {
        // Arrange
        var rentContext = _fixture.Create<IRepositoryContext>();

        // Act
        this._testClass.Lease(rentContext);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lease method throws when the rentContext parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLeaseWithNullRentContext()
    {
        FluentActions.Invoking(() => this._testClass.Lease(default(IRepositoryContext))).Should().Throw<ArgumentNullException>().WithParameterName("rentContext");
    }

    /// <summary>
    /// Checks that the LeaseAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLeaseAsync()
    {
        // Arrange
        var destContext = _fixture.Create<IRepositoryContext>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.LeaseAsync(destContext, token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LeaseAsync method throws when the destContext parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLeaseAsyncWithNullDestContextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LeaseAsync(default(IRepositoryContext), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("destContext");
    }

    /// <summary>
    /// Checks that the SnapshotConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSnapshotConfiguration()
    {
        // Act
        this._testClass.SnapshotConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRemotes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadRemotes()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        this._testClass.LoadRemotes(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRemotes method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadRemotesWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.LoadRemotes(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the LoadRemotesAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadRemotesAsync()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        await this._testClass.LoadRemotesAsync(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRemotesAsync method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLoadRemotesAsyncWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LoadRemotesAsync(default(object))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the LoadRelated method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadRelated()
    {
        // Arrange
        var entry = _fixture.Create<EntityEntry>();
        var relatedType = _fixture.Create<RelatedType>();

        // Act
        this._testClass.LoadRelated(entry, relatedType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRelated method throws when the entry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadRelatedWithNullEntry()
    {
        FluentActions.Invoking(() => this._testClass.LoadRelated(default(EntityEntry), _fixture.Create<RelatedType>())).Should().Throw<ArgumentNullException>().WithParameterName("entry");
    }

    /// <summary>
    /// Checks that the LoadRelatedAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadRelatedAsync()
    {
        // Arrange
        var entry = _fixture.Create<EntityEntry>();
        var relatedType = _fixture.Create<RelatedType>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        this._testClass.LoadRelatedAsync(entry, relatedType, token
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadRelatedAsync method throws when the entry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadRelatedAsyncWithNullEntry()
    {
        FluentActions.Invoking(() => this._testClass.LoadRelatedAsync(default(EntityEntry), _fixture.Create<RelatedType>(), _fixture.Create<CancellationToken>())).Should().Throw<ArgumentNullException>().WithParameterName("entry");
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
    /// Checks that the PublicAuditStateEvent method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAuditStateEvent()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var e = _fixture.Create<EntityEntryEventArgs>();

        // Act
        this._testClass.PublicAuditStateEvent(sender, e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicAuditStateEvent method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAuditStateEventWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.PublicAuditStateEvent(default(object), _fixture.Create<EntityEntryEventArgs>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the PublicAuditStateEvent method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAuditStateEventWithNullE()
    {
        FluentActions.Invoking(() => this._testClass.PublicAuditStateEvent(_fixture.Create<object>(), default(EntityEntryEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the TracePatching method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTracePatching()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var propertyName = _fixture.Create<string>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.TracePatching(item, propertyName, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TracePatching method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTracePatchingWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.TracePatching(default(object), _fixture.Create<string>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the TracePatching method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallTracePatchingWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => this._testClass.TracePatching(_fixture.Create<object>(), value, _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the ElementType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetElementType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.ElementType = testValue;

        // Assert
        this._testClass.ElementType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Name property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetName()
    {
        // Assert
        this._testClass.Name.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FullName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFullName()
    {
        // Assert
        this._testClass.FullName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InnerContext property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInnerContext()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.InnerContext = testValue;

        // Assert
        this._testClass.InnerContext.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Site property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSite()
    {
        // Arrange
        var testValue = _fixture.Create<DataSite>();

        // Act
        this._testClass.Site = testValue;

        // Assert
        this._testClass.Site.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ContextType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContextType()
    {
        // Assert
        this._testClass.ContextType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Expression property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExpression()
    {
        // Arrange
        var testValue = _fixture.Create<Expression>();

        // Act
        this._testClass.Expression = testValue;

        // Assert
        this._testClass.Expression.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Provider property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProvider()
    {
        // Arrange
        var testValue = _fixture.Create<IQueryProvider>();

        // Act
        this._testClass.Provider = testValue;

        // Assert
        this._testClass.Provider.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Mapper property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMapper()
    {
        // Assert
        this._testClass.Mapper.Should().BeAssignableTo<IDataMapper>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.As<object>().Should().BeAssignableTo<Uscn>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cancellation property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCancellation()
    {
        // Arrange
        var testValue = _fixture.Create<CancellationToken>();

        // Act
        this._testClass.Cancellation = testValue;

        // Assert
        this._testClass.Cancellation.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the CodeNo property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCodeNo()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.CodeNo = testValue;

        // Assert
        this._testClass.CodeNo.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ContextLease property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetContextLease()
    {
        // Arrange
        var testValue = _fixture.Create<IRepositoryContext>();

        // Act
        this._testClass.ContextLease = testValue;

        // Assert
        this._testClass.ContextLease.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ContextPool property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetContextPool()
    {
        // Arrange
        var testValue = _fixture.Create<IRepositoryContextPool>();

        // Act
        this._testClass.ContextPool = testValue;

        // Assert
        this._testClass.ContextPool.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Pooled property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPooled()
    {
        // Assert
        this._testClass.Pooled.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Leased property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetLeased()
    {
        // Assert
        this._testClass.Leased.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoteProperties property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRemoteProperties()
    {
        // Arrange
        var testValue = _fixture.Create<IEnumerable<IRemoteProperty>>();

        // Act
        this._testClass.RemoteProperties = testValue;

        // Assert
        this._testClass.RemoteProperties.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RemotesCount property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRemotesCount()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.RemotesCount = testValue;

        // Assert
        this._testClass.RemotesCount.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Towards property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTowards()
    {
        // Arrange
        var testValue = _fixture.Create<Towards>();

        // Act
        this._testClass.Towards = testValue;

        // Assert
        this._testClass.Towards.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PatchingEvent property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPatchingEvent()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.PatchingEvent = testValue;

        // Assert
        this._testClass.PatchingEvent.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the CodeNumber property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCodeNumber()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.CodeNumber = testValue;

        // Assert
        this._testClass.CodeNumber.Should().Be(testValue);
    }
}