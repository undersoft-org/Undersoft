using System;
using System.Runtime.InteropServices;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Attributes;

namespace Undersoft.SDK.UnitTests.Instant.Attributes;

/// <summary>
/// Unit tests for the type <see cref="InstantAsAttribute"/>.
/// </summary>
public class InstantAsAttributeTests
{
    private InstantAsAttribute _testClass;
    private IFixture _fixture;
    private UnmanagedType _unmanaged;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantAsAttribute"/>.
    /// </summary>
    public InstantAsAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._unmanaged = _fixture.Create<UnmanagedType>();
        this._testClass = _fixture.Create<InstantAsAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantAsAttribute(this._unmanaged);

        // Assert
        instance.Should().NotBeNull();
    }
}