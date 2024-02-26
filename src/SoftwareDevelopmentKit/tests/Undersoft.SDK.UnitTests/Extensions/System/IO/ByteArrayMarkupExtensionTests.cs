using System;
using System.IO;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ByteArrayMarkupExtension"/>.
/// </summary>
public class ByteArrayMarkupExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitializeWithArrayOfByteAndByte()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var defaultValue = _fixture.Create<byte>();

        // Act
        var result = array.Initialize(defaultValue);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithArrayOfByteAndByteWithNullArray()
    {
        FluentActions.Invoking(() => default(byte[]).Initialize(_fixture.Create<byte>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitializeWithArrayOfByteAndChar()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var defaultValue = _fixture.Create<char>();

        // Act
        var result = array.Initialize(defaultValue);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithArrayOfByteAndCharWithNullArray()
    {
        FluentActions.Invoking(() => default(byte[]).Initialize(_fixture.Create<char>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the Markup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMarkupWithArrayOfByteAndIntAndMarkupTypeAndIntAndInt()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var blocksize = _fixture.Create<int>();
        var bytenoise = _fixture.Create<MarkupType>();
        var written = _fixture.Create<int>();
        var byteprefix = _fixture.Create<int>();

        // Act
        var result = array.Markup(blocksize, bytenoise, written, byteprefix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Markup method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMarkupWithArrayOfByteAndIntAndMarkupTypeAndIntAndIntWithNullArray()
    {
        FluentActions.Invoking(() => default(byte[]).Markup(_fixture.Create<int>(), _fixture.Create<MarkupType>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the Markup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMarkupWithArrayOfByteAndLongAndMarkupTypeAndIntAndInt()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var blocksize = _fixture.Create<long>();
        var bytenoise = _fixture.Create<MarkupType>();
        var written = _fixture.Create<int>();
        var byteprefix = _fixture.Create<int>();

        // Act
        var result = array.Markup(blocksize, bytenoise, written, byteprefix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Markup method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMarkupWithArrayOfByteAndLongAndMarkupTypeAndIntAndIntWithNullArray()
    {
        FluentActions.Invoking(() => default(byte[]).Markup(_fixture.Create<long>(), _fixture.Create<MarkupType>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the SeekMarkup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSeekMarkup()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var direction = _fixture.Create<SeekDirection>();
        var offset = _fixture.Create<int>();
        var _length = _fixture.Create<int>();

        // Act
        var result = array.SeekMarkup(out var position, direction, offset, _length);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SeekMarkup method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSeekMarkupWithNullArray()
    {
        FluentActions.Invoking(() => default(byte[]).SeekMarkup(out _, _fixture.Create<SeekDirection>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the SeekSegment method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSeekSegment()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var itemSize = _fixture.Create<int>();

        // Act
        var result = array.SeekSegment(itemSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SeekSegment method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSeekSegmentWithNullArray()
    {
        FluentActions.Invoking(() => default(byte[]).SeekSegment(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }
}