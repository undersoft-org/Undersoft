using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="GrpcDataServerRegistry"/>.
/// </summary>
[TestClass]
public class GrpcDataServerRegistryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}