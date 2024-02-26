using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.FileSystem;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.FileSystem;

/// <summary>
/// Unit tests for the type <see cref="FileSystemBlobProviderConfigurationNames"/>.
/// </summary>
[TestClass]
public class FileSystemBlobProviderConfigurationNamesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}