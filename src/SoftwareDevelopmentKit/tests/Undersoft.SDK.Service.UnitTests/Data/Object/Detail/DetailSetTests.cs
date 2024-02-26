using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Object.Detail;
using TDto = Undersoft.SDK.Service.Data.Object.Detail.ObjectDetail;

namespace Undersoft.SDK.Service.UnitTests.Data.Object.Detail;

/// <summary>
/// Unit tests for the type <see cref="DetailSet"/>.
/// </summary>
public class DetailSet_1Tests
{
    private class TestDetailSet : DetailSet<TDto>
    {
        public TestDetailSet() : base()
        {
        }

        public TestDetailSet(IEnumerable<TDto> list) : base(list)
        {
        }

        public string PublicGetKeyForItem(TDto item)
        {
            return base.GetKeyForItem(item);
        }
    }

    private TestDetailSet _testClass;
    private IFixture _fixture;
    private IEnumerable<TDto> _list;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DetailSet"/>.
    /// </summary>
    public DetailSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._list = _fixture.Create<IEnumerable<TDto>>();
        this._testClass = _fixture.Create<TestDetailSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestDetailSet();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestDetailSet(this._list);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the list parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullList()
    {
        FluentActions.Invoking(() => new TestDetailSet(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("list");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyForItem()
    {
        // Arrange
        var item = _fixture.Create<TDto>();

        // Act
        var result = this._testClass.PublicGetKeyForItem(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetKeyForItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicGetKeyForItem(default(TDto))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Single property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSingle()
    {
        // Assert
        this._testClass.Single.Should().BeAssignableTo<TDto>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<TDto>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<TDto>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }
}