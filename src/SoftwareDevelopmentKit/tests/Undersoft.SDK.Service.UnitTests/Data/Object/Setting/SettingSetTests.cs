using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Object.Setting;
using TDto = Undersoft.SDK.Service.Data.Object.Setting.ObjectSetting;

namespace Undersoft.SDK.Service.UnitTests.Data.Object.Setting;

/// <summary>
/// Unit tests for the type <see cref="SettingSet"/>.
/// </summary>
public class SettingSet_1Tests
{
    private SettingSet<TDto> _testClass;
    private IFixture _fixture;
    private IEnumerable<TDto> _list;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SettingSet"/>.
    /// </summary>
    public SettingSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._list = _fixture.Create<IEnumerable<TDto>>();
        this._testClass = _fixture.Create<SettingSet<TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SettingSet<TDto>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SettingSet<TDto>(this._list);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the list parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullList()
    {
        FluentActions.Invoking(() => new SettingSet<TDto>(default(IEnumerable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("list");
    }
}