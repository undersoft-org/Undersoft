using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="MemberRubrics"/>.
/// </summary>
public partial class MemberRubricsTests
{
    private MemberRubrics _testClass;
    private IFixture _fixture;
    private IEnumerable<MemberRubric> _collectionIEnumerableMemberRubric;
    private IList<MemberRubric> _collectionIListMemberRubric;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MemberRubrics"/>.
    /// </summary>
    public MemberRubricsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._collectionIEnumerableMemberRubric = _fixture.Create<IEnumerable<MemberRubric>>();
        this._collectionIListMemberRubric = _fixture.Create<IList<MemberRubric>>();
        this._testClass = _fixture.Create<MemberRubrics>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MemberRubrics();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubrics(this._collectionIEnumerableMemberRubric);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubrics(this._collectionIListMemberRubric);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new MemberRubrics(default(IEnumerable<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new MemberRubrics(default(IList<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the EmptyItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyItem()
    {
        // Act
        var result = this._testClass.EmptyItem();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyTable()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyTable(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyVector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyVector()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyVector(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Arrange
        var figure = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.GetBytes(figure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the figure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithNullFigure()
    {
        FluentActions.Invoking(() => this._testClass.GetBytes(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("figure");
    }

    /// <summary>
    /// Checks that the GetUniqueBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetUniqueBytes()
    {
        // Arrange
        var figure = _fixture.Create<IInstant>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = this._testClass.GetUniqueBytes(figure, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetUniqueBytes method throws when the figure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetUniqueBytesWithNullFigure()
    {
        FluentActions.Invoking(() => this._testClass.GetUniqueBytes(default(IInstant), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("figure");
    }

    /// <summary>
    /// Checks that the GetUniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetUniqueKey()
    {
        // Arrange
        var figure = _fixture.Create<IInstant>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = this._testClass.GetUniqueKey(figure, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetUniqueKey method throws when the figure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetUniqueKeyWithNullFigure()
    {
        FluentActions.Invoking(() => this._testClass.GetUniqueKey(default(IInstant), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("figure");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithISeriesItemOfMemberRubric()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<MemberRubric>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithISeriesItemOfMemberRubricWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(ISeriesItem<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithISeriesItemOfMemberRubricPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<MemberRubric>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithMemberRubric()
    {
        // Arrange
        var value = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithMemberRubricWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithMemberRubricPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndMemberRubric()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndMemberRubricWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<MemberRubric>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndMemberRubricWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<object>(), default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndMemberRubricPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndMemberRubric()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithLongAndMemberRubricWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<long>(), default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndMemberRubricPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the SetUniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetUniqueKey()
    {
        // Arrange
        var figure = _fixture.Create<IInstant>();
        var seed = _fixture.Create<uint>();

        // Act
        this._testClass.SetUniqueKey(figure, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetUniqueKey method throws when the figure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetUniqueKeyWithNullFigure()
    {
        FluentActions.Invoking(() => this._testClass.SetUniqueKey(default(IInstant), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("figure");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdate()
    {
        // Act
        this._testClass.Update();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BinarySize property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetBinarySize()
    {
        // Assert
        this._testClass.BinarySize.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BinarySizes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetBinarySizes()
    {
        // Assert
        this._testClass.BinarySizes.Should().BeAssignableTo<int[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Series property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSeries()
    {
        this._testClass.CheckProperty(x => x.Series, _fixture.Create<IInstantSeries>(), _fixture.Create<IInstantSeries>());
    }

    /// <summary>
    /// Checks that setting the KeyRubrics property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKeyRubrics()
    {
        this._testClass.CheckProperty(x => x.KeyRubrics, _fixture.Create<IRubrics>(), _fixture.Create<IRubrics>());
    }

    /// <summary>
    /// Checks that setting the Mappings property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMappings()
    {
        this._testClass.CheckProperty(x => x.Mappings, _fixture.Create<RubricSqlMappings>(), _fixture.Create<RubricSqlMappings>());
    }

    /// <summary>
    /// Checks that the Ordinals property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetOrdinals()
    {
        // Assert
        this._testClass.Ordinals.Should().BeAssignableTo<int[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Visible property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetVisible()
    {
        this._testClass.CheckProperty(x => x.Visible);
    }
}