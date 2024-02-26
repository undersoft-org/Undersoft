using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks.MMF.Handle;

namespace Undersoft.SDK.UnitTests.Stocks.MMF.Handle;

/// <summary>
/// Unit tests for the type <see cref="SafeMMFileHandle"/>.
/// </summary>
public class SafeMMFileHandleTests
{
    private SafeMMFileHandle _testClass;
    private IFixture _fixture;
    private nint _handle;
    private bool _ownsHandle;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SafeMMFileHandle"/>.
    /// </summary>
    public SafeMMFileHandleTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._handle = _fixture.Create<nint>();
        this._ownsHandle = _fixture.Create<bool>();
        this._testClass = _fixture.Create<SafeMMFileHandle>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SafeMMFileHandle();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SafeMMFileHandle(this._handle, this._ownsHandle);

        // Assert
        instance.Should().NotBeNull();
    }
}