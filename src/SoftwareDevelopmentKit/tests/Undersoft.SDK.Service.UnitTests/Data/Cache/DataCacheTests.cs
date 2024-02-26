using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Cache;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Cache;

/// <summary>
/// Unit tests for the type <see cref="DataCache"/>.
/// </summary>
public class DataCacheTests
{
    private class TestDataCache : DataCache
    {
        public TestDataCache() : base()
        {
        }

        public TestDataCache(TimeSpan? lifeTime = null, IInvoker callback = null, int capacity = 259) : base(lifeTime, callback, capacity)
        {
        }

        public T PublicInnerMemorize<T>(T item)
        {
            return base.InnerMemorize<T>(item);
        }

        public T PublicInnerMemorize<T>(T item, string[] names)
        {
            return base.InnerMemorize<T>(item, names);
        }
    }

    private TestDataCache _testClass;
    private IFixture _fixture;
    private TimeSpan? _lifeTime;
    private Mock<IInvoker> _callback;
    private int _capacity;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataCache"/>.
    /// </summary>
    public DataCacheTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._lifeTime = _fixture.Create<TimeSpan?>();
        this._callback = _fixture.Freeze<Mock<IInvoker>>();
        this._capacity = _fixture.Create<int>();
        this._testClass = _fixture.Create<TestDataCache>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestDataCache();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestDataCache(this._lifeTime, this._callback.Object, this._capacity);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the PublicInnerMemorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerMemorizeWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.PublicInnerMemorize<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerMemorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerMemorizeWithItemAndNames()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.PublicInnerMemorize<T>(item, names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerMemorize method throws when the names parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerMemorizeWithItemAndNamesWithNullNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerMemorize<T>(_fixture.Create<T>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the AssignKeyRubrics method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignKeyRubrics()
    {
        // Arrange
        var proxy = _fixture.Create<ProxyCreator>();
        var item = _fixture.Create<IOrigin>();

        // Act
        var result = TestDataCache.AssignKeyRubrics(proxy, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssignKeyRubrics method throws when the proxy parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAssignKeyRubricsWithNullProxy()
    {
        FluentActions.Invoking(() => TestDataCache.AssignKeyRubrics(default(ProxyCreator), _fixture.Create<IOrigin>())).Should().Throw<ArgumentNullException>().WithParameterName("proxy");
    }

    /// <summary>
    /// Checks that the AssignKeyRubrics method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAssignKeyRubricsWithNullItem()
    {
        FluentActions.Invoking(() => TestDataCache.AssignKeyRubrics(_fixture.Create<ProxyCreator>(), default(IOrigin))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorize()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.Memorize<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeIdWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetDataTypeId(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeIdWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataTypeId(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetDataType(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataType method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataType(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeIdWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetDataTypeId(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeIdWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataTypeId(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetDataType(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataType method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataType(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }
}