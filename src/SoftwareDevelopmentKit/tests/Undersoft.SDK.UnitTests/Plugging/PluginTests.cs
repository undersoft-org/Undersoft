using System;
using System.IO;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Plugging;

namespace Undersoft.SDK.UnitTests.Plugging;

/// <summary>
/// Unit tests for the type <see cref="Plugin"/>.
/// </summary>
public class PluginTests
{
    private class TestPlugin : Plugin
    {
        public TestPlugin() : base()
        {
        }

        public TestPlugin(string assemblyPath, string symbolsPath) : base(assemblyPath, symbolsPath)
        {
        }

        public TestPlugin(string assemblyPath) : base(assemblyPath)
        {
        }

        public Assembly PublicLoad(AssemblyName assemblyName)
        {
            return base.Load(assemblyName);
        }

        public nint PublicLoadUnmanagedDll(string unmanagedDllName)
        {
            return base.LoadUnmanagedDll(unmanagedDllName);
        }
    }

    private TestPlugin _testClass;
    private IFixture _fixture;
    private string _assemblyPath;
    private string _symbolsPath;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Plugin"/>.
    /// </summary>
    public PluginTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._assemblyPath = _fixture.Create<string>();
        this._symbolsPath = _fixture.Create<string>();
        this._testClass = _fixture.Create<TestPlugin>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestPlugin();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestPlugin(this._assemblyPath, this._symbolsPath);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestPlugin(this._assemblyPath);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the assemblyPath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidAssemblyPath(string value)
    {
        FluentActions.Invoking(() => new TestPlugin(value, this._symbolsPath)).Should().Throw<ArgumentNullException>().WithParameterName("assemblyPath");
        FluentActions.Invoking(() => new TestPlugin(value)).Should().Throw<ArgumentNullException>().WithParameterName("assemblyPath");
    }

    /// <summary>
    /// Checks that the constructor throws when the symbolsPath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSymbolsPath(string value)
    {
        FluentActions.Invoking(() => new TestPlugin(this._assemblyPath, value)).Should().Throw<ArgumentNullException>().WithParameterName("symbolsPath");
    }

    /// <summary>
    /// Checks that the PublicLoad method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithAssemblyName()
    {
        // Arrange
        var assemblyName = _fixture.Create<AssemblyName>();

        // Act
        var result = this._testClass.PublicLoad(assemblyName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicLoad method throws when the assemblyName parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithAssemblyNameWithNullAssemblyName()
    {
        FluentActions.Invoking(() => this._testClass.PublicLoad(default(AssemblyName))).Should().Throw<ArgumentNullException>().WithParameterName("assemblyName");
    }

    /// <summary>
    /// Checks that the PublicLoad maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void LoadWithAssemblyNamePerformsMapping()
    {
        // Arrange
        var assemblyName = _fixture.Create<AssemblyName>();

        // Act
        var result = this._testClass.PublicLoad(assemblyName);

        // Assert
        result.CodeBase.Should().BeSameAs(assemblyName.CodeBase);
        result.EscapedCodeBase.Should().BeSameAs(assemblyName.EscapedCodeBase);
        result.FullName.Should().BeSameAs(assemblyName.FullName);
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithAssemblyPathAndSymbolsPath()
    {
        // Arrange
        var assemblyPath = _fixture.Create<string>();
        var symbolsPath = _fixture.Create<string>();

        // Act
        var result = this._testClass.Load(assemblyPath, symbolsPath);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the assemblyPath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallLoadWithAssemblyPathAndSymbolsPathWithInvalidAssemblyPath(string value)
    {
        FluentActions.Invoking(() => this._testClass.Load(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("assemblyPath");
    }

    /// <summary>
    /// Checks that the Load method throws when the symbolsPath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallLoadWithAssemblyPathAndSymbolsPathWithInvalidSymbolsPath(string value)
    {
        FluentActions.Invoking(() => this._testClass.Load(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("symbolsPath");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithDllStreamAndPdbStream()
    {
        // Arrange
        var dllStream = _fixture.Create<Stream>();
        var pdbStream = _fixture.Create<Stream>();

        // Act
        var result = this._testClass.Load(dllStream, pdbStream);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the dllStream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithDllStreamAndPdbStreamWithNullDllStream()
    {
        FluentActions.Invoking(() => this._testClass.Load(default(Stream), _fixture.Create<Stream>())).Should().Throw<ArgumentNullException>().WithParameterName("dllStream");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithDllBytesAndPdbBytes()
    {
        // Arrange
        var dllBytes = _fixture.Create<byte[]>();
        var pdbBytes = _fixture.Create<byte[]>();

        // Act
        var result = this._testClass.Load(dllBytes, pdbBytes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the dllBytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithDllBytesAndPdbBytesWithNullDllBytes()
    {
        FluentActions.Invoking(() => this._testClass.Load(default(byte[]), _fixture.Create<byte[]>())).Should().Throw<ArgumentNullException>().WithParameterName("dllBytes");
    }

    /// <summary>
    /// Checks that the PublicLoadUnmanagedDll method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadUnmanagedDll()
    {
        // Arrange
        var unmanagedDllName = _fixture.Create<string>();

        // Act
        var result = this._testClass.PublicLoadUnmanagedDll(unmanagedDllName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicLoadUnmanagedDll method throws when the unmanagedDllName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallLoadUnmanagedDllWithInvalidUnmanagedDllName(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicLoadUnmanagedDll(value)).Should().Throw<ArgumentNullException>().WithParameterName("unmanagedDllName");
    }
}