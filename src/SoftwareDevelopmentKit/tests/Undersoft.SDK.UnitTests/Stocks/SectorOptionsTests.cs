using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Stocks;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="SectorOptions"/>.
/// </summary>
public class SectorOptions_1Tests
{
    private SectorOptions<T> _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _instantSeries;
    private ushort _clusterId;
    private ushort _sectorId;
    private int _blockSize;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SectorOptions"/>.
    /// </summary>
    public SectorOptions_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._clusterId = _fixture.Create<ushort>();
        this._sectorId = _fixture.Create<ushort>();
        this._blockSize = _fixture.Create<int>();
        this._testClass = _fixture.Create<SectorOptions<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SectorOptions<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions<T>(this._instantSeries.Object, this._clusterId, this._sectorId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions<T>(this._clusterId, this._sectorId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions<T>(this._clusterId, this._sectorId, this._blockSize);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSeries()
    {
        FluentActions.Invoking(() => new SectorOptions<T>(default(IInstantSeries), this._clusterId, this._sectorId)).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }
}

/// <summary>
/// Unit tests for the type <see cref="SectorOptions"/>.
/// </summary>
public class SectorOptionsTests
{
    private SectorOptions _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _instantSeries;
    private ushort _clusterId;
    private ushort _sectorId;
    private Type _type;
    private int _blockSize;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SectorOptions"/>.
    /// </summary>
    public SectorOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._clusterId = _fixture.Create<ushort>();
        this._sectorId = _fixture.Create<ushort>();
        this._type = _fixture.Create<Type>();
        this._blockSize = _fixture.Create<int>();
        this._testClass = _fixture.Create<SectorOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SectorOptions();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions(this._instantSeries.Object, this._clusterId, this._sectorId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions(this._type);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions(this._type, this._clusterId, this._sectorId, this._blockSize);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SectorOptions(this._type, this._clusterId, this._sectorId);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSeries()
    {
        FluentActions.Invoking(() => new SectorOptions(default(IInstantSeries), this._clusterId, this._sectorId)).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }

    /// <summary>
    /// Checks that instance construction throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullType()
    {
        FluentActions.Invoking(() => new SectorOptions(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
        FluentActions.Invoking(() => new SectorOptions(default(Type), this._clusterId, this._sectorId, this._blockSize)).Should().Throw<ArgumentNullException>().WithParameterName("type");
        FluentActions.Invoking(() => new SectorOptions(default(Type), this._clusterId, this._sectorId)).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ClusterId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusterId()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.ClusterId = testValue;

        // Assert
        this._testClass.ClusterId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the SectorId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSectorId()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.SectorId = testValue;

        // Assert
        this._testClass.SectorId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the FileName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFileName()
    {
        // Assert
        this._testClass.FileName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SectorName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSectorName()
    {
        // Assert
        this._testClass.SectorName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SectorPath property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSectorPath()
    {
        // Assert
        this._testClass.SectorPath.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }
}