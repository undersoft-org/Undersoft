using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="IntPtrReferenceExtension"/>.
/// </summary>
public class IntPtrReferenceExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddressOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddressOfWithObj()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = IntPtrReferenceExtension.AddressOf(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddressOf method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddressOfWithObjWithNullObj()
    {
        FluentActions.Invoking(() => IntPtrReferenceExtension.AddressOf(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the AddressOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddressOfWithT()
    {
        // Arrange
        var t = _fixture.Create<T>();

        // Act
        var result = IntPtrReferenceExtension.AddressOf<T>(t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddressOfRef method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddressOfRef()
    {
        // Arrange
        var t = _fixture.Create<T>();

        // Act
        var result = IntPtrReferenceExtension.AddressOfRef<T>(ref t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ItemAt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallItemAt()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var index = _fixture.Create<int>();

        // Act
        var result = ptr.ItemAt<T>(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToIntPtrWithInt()
    {
        // Arrange
        var value = _fixture.Create<int>();

        // Act
        var result = value.ToIntPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToIntPtrWithLong()
    {
        // Arrange
        var value = _fixture.Create<long>();

        // Act
        var result = value.ToIntPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToIntPtrWithUint()
    {
        // Arrange
        var value = _fixture.Create<uint>();

        // Act
        var result = value.ToIntPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToIntPtrWithUlong()
    {
        // Arrange
        var value = _fixture.Create<ulong>();

        // Act
        var result = value.ToIntPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToUInt32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToUInt32()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();

        // Act
        var result = pointer.ToUInt32();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToUInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToUInt64()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();

        // Act
        var result = pointer.ToUInt64();

        // Assert
        Assert.Fail("Create or modify test");
    }
}