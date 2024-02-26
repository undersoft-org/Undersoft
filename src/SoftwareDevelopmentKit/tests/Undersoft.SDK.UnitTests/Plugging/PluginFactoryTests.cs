using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Plugging;

namespace Undersoft.SDK.UnitTests.Plugging;

/// <summary>
/// Unit tests for the type <see cref="PluginFactory"/>.
/// </summary>
public class PluginFactoryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}