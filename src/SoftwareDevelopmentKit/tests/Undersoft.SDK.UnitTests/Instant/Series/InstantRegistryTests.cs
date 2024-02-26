using System;
using System.IO;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Instant.Series;

/// <summary>
/// Unit tests for the type <see cref="InstantRegistry"/>.
/// </summary>
public class InstantRegistryTests
{
    private class TestInstantRegistry : InstantRegistry
    {
        public bool PublicInnerAdd(IInstant value)
        {
            return base.InnerAdd(value);
        }

        public ISeriesItem<IInstant> PublicInnerPut(IInstant value)
        {
            return base.InnerPut(value);
        }

        public override IInstant NewInstant()
        {
            return default(IInstant);
        }

        public override IProxy NewProxy()
        {
            return default(IProxy);
        }

        public override bool Prime { get; set; }
        public override object this[] { get; set; }
        public override object this[] { get; set; }
        public override IRubrics Rubrics { get; set; }
        public override IRubrics KeyRubrics { get; set; }
        public override Type InstantType { get; set; }
        public override int InstantSize { get; set; }
        public override Uscn Code { get; set; }
    }

    private TestInstantRegistry _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantRegistry"/>.
    /// </summary>
    public InstantRegistryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestInstantRegistry>();
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
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndIInstant()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithLongAndIInstantWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<long>(), default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndIInstantPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndIInstant()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndIInstantWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<IInstant>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndIInstantWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<object>(), default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndIInstantPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithIInstant()
    {
        // Arrange
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithIInstantWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithIInstantPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithISeriesItemOfIInstant()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<IInstant>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithISeriesItemOfIInstantWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(ISeriesItem<IInstant>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithISeriesItemOfIInstantPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<IInstant>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
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
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAdd()
    {
        // Arrange
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.PublicInnerAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerAddWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerAdd(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPut()
    {
        // Arrange
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerPutWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerPut(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithNoParameters()
    {
        // Act
        var result = this._testClass.New();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.New(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.New(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.New(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
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
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerializeWithStreamAndOffsetAndBatchSize()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var offset = _fixture.Create<int>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.Serialize(stream, offset, batchSize
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSerializeWithStreamAndOffsetAndBatchSizeWithNullStream()
    {
        FluentActions.Invoking(() => this._testClass.Serialize(default(Stream), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerializeWithBufforAndOffsetAndBatchSize()
    {
        // Arrange
        var buffor = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.Serialize(buffor, offset, batchSize
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method throws when the buffor parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSerializeWithBufforAndOffsetAndBatchSizeWithNullBuffor()
    {
        FluentActions.Invoking(() => this._testClass.Serialize(default(byte[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffor");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithStream()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();

        // Act
        var result = this._testClass.Deserialize(stream);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithStreamWithNullStream()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize(default(Stream))).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithBuffer()
    {
        // Arrange
        var buffer = _fixture.Create<byte[]>();

        // Act
        var result = this._testClass.Deserialize(buffer
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithBufferWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the GetMessage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMessage()
    {
        // Act
        var result = this._testClass.GetMessage();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHeader()
    {
        // Act
        var result = this._testClass.GetHeader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Instant property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstant()
    {
        this._testClass.CheckProperty(x => x.Instant, _fixture.Create<IInstantCreator>(), _fixture.Create<IInstantCreator>());
    }

    /// <summary>
    /// Checks that setting the Prime property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPrime()
    {
        this._testClass.CheckProperty(x => x.Prime);
    }

    /// <summary>
    /// Checks that setting the Rubrics property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        this._testClass.CheckProperty(x => x.Rubrics, _fixture.Create<IRubrics>(), _fixture.Create<IRubrics>());
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
    /// Checks that setting the InstantType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantType()
    {
        this._testClass.CheckProperty(x => x.InstantType, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that setting the InstantSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSize()
    {
        this._testClass.CheckProperty(x => x.InstantSize);
    }

    /// <summary>
    /// Checks that setting the Code property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCode()
    {
        this._testClass.CheckProperty(x => x.Code, _fixture.Create<Uscn>(), _fixture.Create<Uscn>());
    }

    /// <summary>
    /// Checks that setting the ValueArray property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValueArray()
    {
        this._testClass.CheckProperty(x => x.ValueArray, _fixture.Create<object[]>(), _fixture.Create<object[]>());
    }

    /// <summary>
    /// Checks that setting the Type property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetType()
    {
        this._testClass.CheckProperty(x => x.Type, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that setting the View property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetView()
    {
        this._testClass.CheckProperty(x => x.View, _fixture.Create<IQueryable<IInstant>>(), _fixture.Create<IQueryable<IInstant>>());
    }

    /// <summary>
    /// Checks that setting the Total property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTotal()
    {
        this._testClass.CheckProperty(x => x.Total, _fixture.Create<IInstant>(), _fixture.Create<IInstant>());
    }

    /// <summary>
    /// Checks that setting the Filter property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFilter()
    {
        this._testClass.CheckProperty(x => x.Filter, _fixture.Create<InstantSeriesFilter>(), _fixture.Create<InstantSeriesFilter>());
    }

    /// <summary>
    /// Checks that setting the Sort property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSort()
    {
        this._testClass.CheckProperty(x => x.Sort, _fixture.Create<InstantSeriesSort>(), _fixture.Create<InstantSeriesSort>());
    }

    /// <summary>
    /// Checks that setting the Predicate property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPredicate()
    {
        this._testClass.CheckProperty(x => x.Predicate, x => _fixture.Create<bool>(), x => _fixture.Create<bool>());
    }

    /// <summary>
    /// Checks that setting the Aggregate property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAggregate()
    {
        this._testClass.CheckProperty(x => x.Aggregate, _fixture.Create<InstantSeriesAggregate>(), _fixture.Create<InstantSeriesAggregate>());
    }

    /// <summary>
    /// Checks that setting the Computations property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetComputations()
    {
        this._testClass.CheckProperty(x => x.Computations, _fixture.Create<ISeries<IInstantMath>>(), _fixture.Create<ISeries<IInstantMath>>());
    }

    /// <summary>
    /// Checks that setting the SerialCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSerialCount()
    {
        this._testClass.CheckProperty(x => x.SerialCount);
    }

    /// <summary>
    /// Checks that setting the DeserialCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDeserialCount()
    {
        this._testClass.CheckProperty(x => x.DeserialCount);
    }

    /// <summary>
    /// Checks that setting the ProgressCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProgressCount()
    {
        this._testClass.CheckProperty(x => x.ProgressCount);
    }

    /// <summary>
    /// Checks that the ItemsCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetItemsCount()
    {
        // Assert
        this._testClass.ItemsCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndString()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()].Should().BeSameAs(testValue);
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
}