using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SDK.Service.UnitTests.Data.Store;

/// <summary>
/// Unit tests for the type <see cref="StoreRoutes"/>.
/// </summary>
public class StoreRoutesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}