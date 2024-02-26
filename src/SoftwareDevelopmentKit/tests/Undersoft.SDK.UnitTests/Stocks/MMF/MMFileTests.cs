using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks.MMF;
using Undersoft.SDK.Stocks.MMF.Handle;

namespace Undersoft.SDK.UnitTests.Stocks.MMF;

/// <summary>
/// Unit tests for the type <see cref="MMFile"/>.
/// </summary>
public class MMFileTests
{
    private MMFile _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MMFile"/>.
    /// </summary>
    public MMFileTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<MMFile>();
    }

    /// <summary>
    /// Checks that the CreateNew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateNew()
    {
        // Arrange
        var path = _fixture.Create<string>();
        var mapName = _fixture.Create<string>();
        var capacity = _fixture.Create<long>();
        var readCapacity = _fixture.Create<bool>();

        // Act
        var result = MMFile.CreateNew(path, mapName, capacity, out var exists, readCapacity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateNew method throws when the path parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateNewWithInvalidPath(string value)
    {
        FluentActions.Invoking(() => MMFile.CreateNew(value, _fixture.Create<string>(), _fixture.Create<long>(), out _, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("path");
    }

    /// <summary>
    /// Checks that the CreateNew method throws when the mapName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateNewWithInvalidMapName(string value)
    {
        FluentActions.Invoking(() => MMFile.CreateNew(_fixture.Create<string>(), value, _fixture.Create<long>(), out _, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("mapName");
    }

    /// <summary>
    /// Checks that the CreateViewAccessor method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateViewAccessor()
    {
        // Arrange
        var offset = _fixture.Create<long>();
        var size = _fixture.Create<long>();
        var access = _fixture.Create<MMFileAccess>();

        // Act
        var result = this._testClass.CreateViewAccessor(offset, size, access);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OpenExisting method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpenExisting()
    {
        // Arrange
        var mapName = _fixture.Create<string>();

        // Act
        var result = MMFile.OpenExisting(mapName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OpenExisting method throws when the mapName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallOpenExistingWithInvalidMapName(string value)
    {
        FluentActions.Invoking(() => MMFile.OpenExisting(value)).Should().Throw<ArgumentNullException>().WithParameterName("mapName");
    }

    /// <summary>
    /// Checks that the SafeMemoryMappedFileHandle property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSafeMemoryMappedFileHandle()
    {
        // Assert
        this._testClass.SafeMemoryMappedFileHandle.Should().BeAssignableTo<SafeMMFileHandle>();

        Assert.Fail("Create or modify test");
    }
}