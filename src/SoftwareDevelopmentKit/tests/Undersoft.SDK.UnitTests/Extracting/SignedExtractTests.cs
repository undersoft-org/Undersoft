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
    public void CanCallCopyBlockWithByte*AndByte*AndInt()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndLong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndByte*AndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var src = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndIntAndByte*AndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<int>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

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
    public void CanCallCopyBlockWithByte*AndLongAndByte*AndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<long>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

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
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndInt()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndIntWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndIntWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndIntAndIntWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndIntAndIntWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndLong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndLongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndLongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var src = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndLongAndLongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<byte[]>(), _fixture.Create<long>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndLongAndLongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), default(byte[]), _fixture.Create<long>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndIntAndArrayOfByteAndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<int>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

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
    public void CannotCallCopyBlockWithArrayOfByteAndIntAndArrayOfByteAndIntAndIntWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<int>(), _fixture.Create<byte[]>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndIntAndArrayOfByteAndIntAndIntWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<int>(), default(byte[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndLongAndArrayOfByteAndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<long>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

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
    public void CannotCallCopyBlockWithArrayOfByteAndLongAndArrayOfByteAndLongAndLongWithNullDest()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(default(byte[]), _fixture.Create<long>(), _fixture.Create<byte[]>(), _fixture.Create<long>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndLongAndArrayOfByteAndLongAndLongWithNullSrc()
    {
        FluentActions.Invoking(() => Extract.CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<long>(), default(byte[]), _fixture.Create<long>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndIntAndNintAndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<int>();
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

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
    public void CanCallCopyBlockWithNintAndNintAndInt()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var destOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndLong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var src = _fixture.Create<nint>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndLongAndNintAndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<long>();
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

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
    public void CanCallCopyBlockWithVoid*AndIntAndVoid*AndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var destOffset = _fixture.Create<int>();
        var src = _fixture.Create<void*>();
        var srcOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

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
    public void CanCallCopyBlockWithVoid*AndLongAndVoid*AndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var destOffset = _fixture.Create<long>();
        var src = _fixture.Create<void*>();
        var srcOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

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
    public void CanCallCopyBlockWithVoid*AndVoid*AndInt()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndIntAndInt()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var destOffset = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndLong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithVoid*AndVoid*AndLongAndLong()
    {
        // Arrange
        var dest = _fixture.Create<void*>();
        var src = _fixture.Create<void*>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        Extract.CopyBlock(dest, src, destOffset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }
}