using System;
using System.IO;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="StreamMarkupExtension"/>.
/// </summary>
public class StreamMarkupExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Markup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMarkupWithStreamAndIntAndMarkupType()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var blocksize = _fixture.Create<int>();
        var bytenoise = _fixture.Create<MarkupType>();

        // Act
        var result = stream.Markup(blocksize, bytenoise);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Markup method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMarkupWithStreamAndIntAndMarkupTypeWithNullStream()
    {
        FluentActions.Invoking(() => default(Stream).Markup(_fixture.Create<int>(), _fixture.Create<MarkupType>())).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the Markup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMarkupWithStreamAndLongAndMarkupType()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var blocksize = _fixture.Create<long>();
        var bytenoise = _fixture.Create<MarkupType>();

        // Act
        var result = stream.Markup(blocksize, bytenoise);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Markup method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMarkupWithStreamAndLongAndMarkupTypeWithNullStream()
    {
        FluentActions.Invoking(() => default(Stream).Markup(_fixture.Create<long>(), _fixture.Create<MarkupType>())).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the SeekMarkup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSeekMarkup()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var seekorigin = _fixture.Create<SeekOrigin>();
        var direction = _fixture.Create<SeekDirection>();
        var offset = _fixture.Create<int>();
        var _length = _fixture.Create<int>();

        // Act
        var result = stream.SeekMarkup(seekorigin, direction, offset, _length);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SeekMarkup method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSeekMarkupWithNullStream()
    {
        FluentActions.Invoking(() => default(Stream).SeekMarkup(_fixture.Create<SeekOrigin>(), _fixture.Create<SeekDirection>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }
}