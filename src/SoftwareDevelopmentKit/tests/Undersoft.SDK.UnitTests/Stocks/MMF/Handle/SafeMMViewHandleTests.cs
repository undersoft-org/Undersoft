using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks.MMF.Handle;

namespace Undersoft.SDK.UnitTests.Stocks.MMF.Handle;

/// <summary>
/// Unit tests for the type <see cref="SafeMMViewHandle"/>.
/// </summary>
public class SafeMMViewHandleTests
{
    private SafeMMViewHandle _testClass;
    private IFixture _fixture;
    private nint _handle;
    private bool _ownsHandle;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SafeMMViewHandle"/>.
    /// </summary>
    public SafeMMViewHandleTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._handle = _fixture.Create<nint>();
        this._ownsHandle = _fixture.Create<bool>();
        this._testClass = _fixture.Create<SafeMMViewHandle>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SafeMMViewHandle();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SafeMMViewHandle(this._handle, this._ownsHandle);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the AcquireIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquireIntPtr()
    {
        // Arrange
        var pointer = _fixture.Create<byte*>();

        // Act
        this._testClass.AcquireIntPtr(ref pointer);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReleaseIntPtr()
    {
        // Act
        this._testClass.ReleaseIntPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }
}