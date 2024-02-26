using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks.MMF;
using Undersoft.SDK.Stocks.MMF.Handle;

namespace Undersoft.SDK.UnitTests.Stocks.MMF;

/// <summary>
/// Unit tests for the type <see cref="MMView"/>.
/// </summary>
public class MMViewTests
{
    private MMView _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MMView"/>.
    /// </summary>
    public MMViewTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<MMView>();
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
    /// Checks that the CreateView method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateView()
    {
        // Arrange
        var safeMemoryMappedFileHandle = _fixture.Create<SafeMMFileHandle>();
        var access = _fixture.Create<MMFileAccess>();
        var offset = _fixture.Create<long>();
        var size = _fixture.Create<long>();

        // Act
        var result = MMView.CreateView(safeMemoryMappedFileHandle, access, offset, size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateView method throws when the safeMemoryMappedFileHandle parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateViewWithNullSafeMemoryMappedFileHandle()
    {
        FluentActions.Invoking(() => MMView.CreateView(default(SafeMMFileHandle), _fixture.Create<MMFileAccess>(), _fixture.Create<long>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("safeMemoryMappedFileHandle");
    }

    /// <summary>
    /// Checks that the CreateView maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void CreateViewPerformsMapping()
    {
        // Arrange
        var safeMemoryMappedFileHandle = _fixture.Create<SafeMMFileHandle>();
        var access = _fixture.Create<MMFileAccess>();
        var offset = _fixture.Create<long>();
        var size = _fixture.Create<long>();

        // Act
        var result = MMView.CreateView(safeMemoryMappedFileHandle, access, offset, size);

        // Assert
        result.Size.Should().Be(size);
    }

    /// <summary>
    /// Checks that the SafeMemoryMappedViewHandle property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSafeMemoryMappedViewHandle()
    {
        // Assert
        this._testClass.SafeMemoryMappedViewHandle.Should().BeAssignableTo<SafeMMViewHandle>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ViewStartOffset property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetViewStartOffset()
    {
        // Assert
        this._testClass.ViewStartOffset.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }
}