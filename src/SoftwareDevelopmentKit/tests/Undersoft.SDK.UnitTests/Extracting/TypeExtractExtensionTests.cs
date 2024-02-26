using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="TypeExtractExtenstion"/>.
/// </summary>
public class TypeExtractExtenstionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the NewStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewStructureWithTypeAndByte*AndLong()
    {
        // Arrange
        var structure = _fixture.Create<Type>();
        var binary = _fixture.Create<byte*>();
        var offset = _fixture.Create<long>();

        // Act
        var result = structure.NewStructure(binary, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewStructureWithTypeAndByte*AndLongWithNullStructure()
    {
        FluentActions.Invoking(() => default(Type).NewStructure(_fixture.Create<byte*>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the NewStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewStructureWithTypeAndArrayOfByteAndLong()
    {
        // Arrange
        var structure = _fixture.Create<Type>();
        var binary = _fixture.Create<byte[]>();
        var offset = _fixture.Create<long>();

        // Act
        var result = structure.NewStructure(binary, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewStructureWithTypeAndArrayOfByteAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => default(Type).NewStructure(_fixture.Create<byte[]>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the NewStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewStructureWithTypeAndArrayOfByteAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().NewStructure(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }
}