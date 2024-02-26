using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="Extract"/>.
/// </summary>
public partial class ExtractTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndUintAndByte*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndUlongAndByte*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintAndUintWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndUintAndArrayOfByteAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUintAndArrayOfByteAndUintAndUintWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<uint>(), _fixture.Create<byte[]>(), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUintAndArrayOfByteAndUintAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<uint>(), default(byte[]), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<ulong>(), _fixture.Create<byte[]>(), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<ulong>(), default(byte[]), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndUintAndNintAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndUlongAndNintAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndUintAndVoid*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<void*>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndUlongAndVoid*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<void*>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndUint()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndUlong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithByte*AndByte*AndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithByte*AndByte*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithByte*AndByte*AndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithByte*AndByte*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithByte*AndUintAndByte*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithByte*AndUlongAndByte*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithArrayOfByteAndArrayOfByteAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUintWithNullDest()
    {
        FluentActions.Invoking(() => Extract.Cpblk(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.Cpblk(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithArrayOfByteAndArrayOfByteAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUintAndUintWithNullDest()
    {
        FluentActions.Invoking(() => Extract.Cpblk(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUintAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.Cpblk(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithArrayOfByteAndArrayOfByteAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.Cpblk(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.Cpblk(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithArrayOfByteAndArrayOfByteAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUlongAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.Cpblk(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndArrayOfByteAndUlongAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.Cpblk(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithArrayOfByteAndUintAndArrayOfByteAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndUintAndArrayOfByteAndUintAndUintWithNullDest()
    {
        FluentActions.Invoking(() => Extract.Cpblk(default(byte[]), _fixture.Create<uint>(), _fixture.Create<byte[]>(), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndUintAndArrayOfByteAndUintAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.Cpblk(_fixture.Create<byte[]>(), _fixture.Create<uint>(), default(byte[]), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.Cpblk(default(byte[]), _fixture.Create<ulong>(), _fixture.Create<byte[]>(), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the Cpblk method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCpblkWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.Cpblk(_fixture.Create<byte[]>(), _fixture.Create<ulong>(), default(byte[]), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithNintAndNintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithNintAndNintAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithNintAndNintAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithNintAndNintAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithNintAndUintAndNintAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithNintAndUlongAndNintAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithVoid*AndUintAndVoid*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<void*>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithVoid*AndUlongAndVoid*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<void*>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithVoid*AndVoid*AndUint()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithVoid*AndVoid*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithVoid*AndVoid*AndUlong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cpblk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCpblkWithVoid*AndVoid*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        Extract.Cpblk(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }
}