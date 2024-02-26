using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqConsts"/>.
/// </summary>
[TestClass]
public class RabbitMqConstsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}