using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Uniques;
using Undersoft.SDK.Updating;
using E = System.String;

namespace Undersoft.SDK.UnitTests.Updating;

/// <summary>
/// Unit tests for the type <see cref="Updater"/>.
/// </summary>
public class UpdaterTests
{
    private class TestUpdater : Updater
    {
        public TestUpdater() : base()
        {
        }

        public TestUpdater(object item, IInvoker traceChanges) : base(item, traceChanges)
        {
        }

        public TestUpdater(object item) : base(item)
        {
        }

        public TestUpdater(IProxy proxy) : base(proxy)
        {
        }

        public TestUpdater(Type type) : base(type)
        {
        }

        public void PublicCombine(IProxy proxy)
        {
            base.Combine(proxy);
        }

        public void PublicCombine(object item)
        {
            base.Combine(item);
        }

        public void PublicSetBy(IProxy target, UpdatedItem[] updates, int count)
        {
            base.SetBy(target, updates, count);
        }

        public void PublicSet(IProxy target, UpdatedItem[] updates, int count)
        {
            base.Set(target, updates, count);
        }

        public UpdatedItem[] PublicPatchEqualTypes(IProxy target)
        {
            return base.PatchEqualTypes(target);
        }

        public UpdatedItem[] PublicPatchNotEqualTypes(IProxy target)
        {
            return base.PatchNotEqualTypes(target);
        }

        public UpdatedItem[] PublicPutEqualTypes(IProxy target)
        {
            return base.PutEqualTypes(target);
        }

        public UpdatedItem[] PublicPutNotEqualTypes(IProxy target)
        {
            return base.PutNotEqualTypes(target);
        }

        public Type Publictype => base.type;
    }

    private TestUpdater _testClass;
    private IFixture _fixture;
    private object _item;
    private Mock<IInvoker> _traceChanges;
    private Mock<IProxy> _proxy;
    private Type _type;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Updater"/>.
    /// </summary>
    public UpdaterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._item = _fixture.Create<object>();
        this._traceChanges = _fixture.Freeze<Mock<IInvoker>>();
        this._proxy = _fixture.Freeze<Mock<IProxy>>();
        this._type = _fixture.Create<Type>();
        this._testClass = _fixture.Create<TestUpdater>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestUpdater();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestUpdater(this._item, this._traceChanges.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestUpdater(this._item);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestUpdater(this._proxy.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestUpdater(this._type);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new TestUpdater(default(object), this._traceChanges.Object)).Should().Throw<ArgumentNullException>().WithParameterName("item");
        FluentActions.Invoking(() => new TestUpdater(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that instance construction throws when the traceChanges parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTraceChanges()
    {
        FluentActions.Invoking(() => new TestUpdater(this._item, default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("traceChanges");
    }

    /// <summary>
    /// Checks that instance construction throws when the proxy parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProxy()
    {
        FluentActions.Invoking(() => new TestUpdater(default(IProxy))).Should().Throw<ArgumentNullException>().WithParameterName("proxy");
    }

    /// <summary>
    /// Checks that instance construction throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullType()
    {
        FluentActions.Invoking(() => new TestUpdater(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the PublicCombine method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCombineWithProxy()
    {
        // Arrange
        var proxy = _fixture.Create<IProxy>();

        // Act
        this._testClass.PublicCombine(proxy);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCombine method throws when the proxy parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCombineWithProxyWithNullProxy()
    {
        FluentActions.Invoking(() => this._testClass.PublicCombine(default(IProxy))).Should().Throw<ArgumentNullException>().WithParameterName("proxy");
    }

    /// <summary>
    /// Checks that the PublicCombine method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCombineWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        this._testClass.PublicCombine(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCombine method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCombineWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicCombine(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicSetBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetBy()
    {
        // Arrange
        var target = _fixture.Create<IProxy>();
        var updates = _fixture.Create<UpdatedItem[]>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.PublicSetBy(target, updates, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSetBy method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.PublicSetBy(default(IProxy), _fixture.Create<UpdatedItem[]>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PublicSetBy method throws when the updates parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetByWithNullUpdates()
    {
        FluentActions.Invoking(() => this._testClass.PublicSetBy(_fixture.Create<IProxy>(), default(UpdatedItem[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("updates");
    }

    /// <summary>
    /// Checks that the PublicSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSet()
    {
        // Arrange
        var target = _fixture.Create<IProxy>();
        var updates = _fixture.Create<UpdatedItem[]>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.PublicSet(target, updates, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSet method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.PublicSet(default(IProxy), _fixture.Create<UpdatedItem[]>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PublicSet method throws when the updates parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNullUpdates()
    {
        FluentActions.Invoking(() => this._testClass.PublicSet(_fixture.Create<IProxy>(), default(UpdatedItem[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("updates");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.Patch(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Patch(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchWithEAndE()
    {
        // Arrange
        var item = _fixture.Create<E>();

        // Act
        var result = this._testClass.Patch<E>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithEAndEWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Patch<E>(default(E))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchWithE()
    {
        // Act
        var result = this._testClass.Patch<E>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.Put(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithEAndE()
    {
        // Arrange
        var item = _fixture.Create<E>();

        // Act
        var result = this._testClass.Put<E>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithEAndEWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Put<E>(default(E))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithE()
    {
        // Act
        var result = this._testClass.Put<E>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Detect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDetectWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.Detect(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Detect method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDetectWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Detect(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Detect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDetectWithEAndE()
    {
        // Arrange
        var item = _fixture.Create<E>();

        // Act
        var result = this._testClass.Detect<E>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Detect method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDetectWithEAndEWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Detect<E>(default(E))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClone()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPatchEqualTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchEqualTypes()
    {
        // Arrange
        var target = _fixture.Create<IProxy>();

        // Act
        var result = this._testClass.PublicPatchEqualTypes(target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPatchEqualTypes method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchEqualTypesWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.PublicPatchEqualTypes(default(IProxy))).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PublicPatchNotEqualTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchNotEqualTypes()
    {
        // Arrange
        var target = _fixture.Create<IProxy>();

        // Act
        var result = this._testClass.PublicPatchNotEqualTypes(target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPatchNotEqualTypes method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchNotEqualTypesWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.PublicPatchNotEqualTypes(default(IProxy))).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PublicPutEqualTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutEqualTypes()
    {
        // Arrange
        var target = _fixture.Create<IProxy>();

        // Act
        var result = this._testClass.PublicPutEqualTypes(target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPutEqualTypes method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutEqualTypesWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.PublicPutEqualTypes(default(IProxy))).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PublicPutNotEqualTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutNotEqualTypes()
    {
        // Arrange
        var target = _fixture.Create<IProxy>();

        // Act
        var result = this._testClass.PublicPutNotEqualTypes(target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPutNotEqualTypes method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutNotEqualTypesWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.PublicPutNotEqualTypes(default(IProxy))).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
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
    /// Checks that the Publictype property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublictype()
    {
        // Assert
        this._testClass.Publictype.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Source property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSource()
    {
        // Arrange
        var testValue = _fixture.Create<IProxy>();

        // Act
        this._testClass.Source = testValue;

        // Assert
        this._testClass.Source.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the UpdateAction property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUpdateAction()
    {
        // Arrange
        Action<Updater, object> testValue = (x, y) => { };

        // Act
        this._testClass.UpdateAction = testValue;

        // Assert
        this._testClass.UpdateAction.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the TraceEvent property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTraceEvent()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.TraceEvent = testValue;

        // Assert
        this._testClass.TraceEvent.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ExcludedRubrics property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetExcludedRubrics()
    {
        // Assert
        this._testClass.ExcludedRubrics.Should().BeAssignableTo<HashSet<string>>();

        Assert.Fail("Create or modify test");
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
    /// Checks that the Code property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCode()
    {
        // Arrange
        var testValue = _fixture.Create<Uscn>();

        // Act
        this._testClass.Code = testValue;

        // Assert
        this._testClass.Code.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Rubrics property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        // Arrange
        var testValue = _fixture.Create<IRubrics>();

        // Act
        this._testClass.Rubrics = testValue;

        // Assert
        this._testClass.Rubrics.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Target property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTarget()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Target = testValue;

        // Assert
        this._testClass.Target.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForString()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }
}