using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Uniques;
using T = Undersoft.SDK.Origin;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="UniqueOne"/>.
/// </summary>
[TestClass]
public class UniqueOne_1Tests
{
    private UniqueOne<T> _testClass;
    private IFixture _fixture;
    private T _entity;
    private IEnumerable<T> _enumerable;
    private Mock<IQueryable<T>> _queryable;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniqueOne"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._entity = _fixture.Create<T>();
        this._enumerable = _fixture.Create<IEnumerable<T>>();
        this._queryable = _fixture.Freeze<Mock<IQueryable<T>>>();
        this._testClass = _fixture.Create<UniqueOne<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UniqueOne<T>(this._entity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new UniqueOne<T>(this._enumerable);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new UniqueOne<T>(this._queryable.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the enumerable parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEnumerable()
    {
        FluentActions.Invoking(() => new UniqueOne<T>(default(IEnumerable<T>))).Should().Throw<ArgumentNullException>().WithParameterName("enumerable");
    }

    /// <summary>
    /// Checks that instance construction throws when the queryable parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullQueryable()
    {
        FluentActions.Invoking(() => new UniqueOne<T>(default(IQueryable<T>))).Should().Throw<ArgumentNullException>().WithParameterName("queryable");
    }
}

/// <summary>
/// Unit tests for the type <see cref="UniqueOne"/>.
/// </summary>
[TestClass]
public class UniqueOneTests
{
    private class TestUniqueOne : UniqueOne
    {
        public TestUniqueOne(object entity) : base(entity)
        {
        }

        public TestUniqueOne(IQueryable queryable) : base(queryable)
        {
        }
    }

    private TestUniqueOne _testClass;
    private IFixture _fixture;
    private object _entity;
    private Mock<IQueryable> _queryable;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniqueOne"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._entity = _fixture.Create<object>();
        this._queryable = _fixture.Freeze<Mock<IQueryable>>();
        this._testClass = _fixture.Create<TestUniqueOne>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestUniqueOne(this._entity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestUniqueOne(this._queryable.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEntity()
    {
        FluentActions.Invoking(() => new TestUniqueOne(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that instance construction throws when the queryable parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullQueryable()
    {
        FluentActions.Invoking(() => new TestUniqueOne(default(IQueryable))).Should().Throw<ArgumentNullException>().WithParameterName("queryable");
    }
}