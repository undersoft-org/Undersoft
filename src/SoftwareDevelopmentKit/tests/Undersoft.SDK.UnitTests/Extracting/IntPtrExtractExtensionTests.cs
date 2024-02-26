using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="IntPtrExtractExtenstion"/>.
/// </summary>
public class IntPtrExtractExtenstionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithNintAndNintAndUint()
    {
        // Arrange
        var src = _fixture.Create<nint>();
        var dest = _fixture.Create<nint>();
        var count = _fixture.Create<uint>();

        // Act
        src.CopyBlock(dest, count);

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
        var src = _fixture.Create<nint>();
        var dest = _fixture.Create<nint>();
        var offset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        src.CopyBlock(dest, offset, count);

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
        var src = _fixture.Create<nint>();
        var dest = _fixture.Create<nint>();
        var count = _fixture.Create<ulong>();

        // Act
        src.CopyBlock(dest, count);

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
        var src = _fixture.Create<nint>();
        var dest = _fixture.Create<nint>();
        var offset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        src.CopyBlock(dest, offset, count);

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
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<uint>();
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        src.CopyBlock(srcOffset, dest, destOffset, count
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
        var src = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<ulong>();
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        src.CopyBlock(srcOffset, dest, destOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromStructure()
    {
        // Arrange
        var binary = _fixture.Create<nint>();
        var structure = _fixture.Create<object>();

        // Act
        binary.FromStructure(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromStructureWithNullStructure()
    {
        FluentActions.Invoking(() => _fixture.Create<nint>().FromStructure(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the NewStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewStructure()
    {
        // Arrange
        var binary = _fixture.Create<nint>();
        var structure = _fixture.Create<Type>();
        var offset = _fixture.Create<int>();

        // Act
        var result = binary.NewStructure(structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewStructureWithNullStructure()
    {
        FluentActions.Invoking(() => _fixture.Create<nint>().NewStructure(default(Type), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStructure()
    {
        // Arrange
        var binary = _fixture.Create<nint>();
        var structure = _fixture.Create<object>();

        // Act
        var result = binary.ToStructure(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithNullStructure()
    {
        FluentActions.Invoking(() => _fixture.Create<nint>().ToStructure(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }
}