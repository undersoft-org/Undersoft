using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Object.Setting;

namespace Undersoft.SDK.Service.UnitTests.Data.Object.Setting;

/// <summary>
/// Unit tests for the type <see cref="SettingAttribute"/>.
/// </summary>
public class SettingAttributeTests
{
    private SettingAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SettingAttribute"/>.
    /// </summary>
    public SettingAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SettingAttribute>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="SettingsAttribute"/>.
/// </summary>
public class SettingsAttributeTests
{
    private SettingsAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SettingsAttribute"/>.
    /// </summary>
    public SettingsAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SettingsAttribute>();
    }
}