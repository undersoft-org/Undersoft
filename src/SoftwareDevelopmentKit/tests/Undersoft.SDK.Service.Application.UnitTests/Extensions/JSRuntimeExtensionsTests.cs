using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.JSInterop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Application.Extensions;
using T = System.String;

namespace Undersoft.SDK.Service.Application.UnitTests.Extensions;

/// <summary>
/// Unit tests for the type <see cref="JSRuntimeExtensions"/>.
/// </summary>
[TestClass]
public class JSRuntimeExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the InvokeVoidAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeVoidAsync()
    {
        // Arrange
        var jsRuntime = _fixture.Create<IJSRuntime>();
        var el = _fixture.Create<object>();
        var func = _fixture.Create<string>();
        var args = _fixture.Create<object[]>();

        // Act
        await jsRuntime.InvokeVoidAsync(el, func, args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeVoidAsync method throws when the jsRuntime parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeVoidAsyncWithNullJsRuntimeAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).InvokeVoidAsync(_fixture.Create<object>(), _fixture.Create<string>(), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("jsRuntime");
    }

    /// <summary>
    /// Checks that the InvokeVoidAsync method throws when the args parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeVoidAsyncWithNullArgsAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().InvokeVoidAsync(_fixture.Create<object>(), _fixture.Create<string>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the InvokeVoidAsync method throws when the func parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallInvokeVoidAsyncWithInvalidFuncAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().InvokeVoidAsync(_fixture.Create<object>(), value, _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("func");
    }

    /// <summary>
    /// Checks that the InitializeInactivityTimer method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInitializeInactivityTimerAsync()
    {
        // Arrange
        var js = _fixture.Create<IJSRuntime>();
        var dotNetObjectReference = _fixture.Create<DotNetObjectReference<T>>();

        // Act
        await js.InitializeInactivityTimer<T>(dotNetObjectReference
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InitializeInactivityTimer method throws when the js parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInitializeInactivityTimerWithNullJsAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).InitializeInactivityTimer<T>(_fixture.Create<DotNetObjectReference<T>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that the InitializeInactivityTimer method throws when the dotNetObjectReference parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInitializeInactivityTimerWithNullDotNetObjectReferenceAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().InitializeInactivityTimer<T>(default(DotNetObjectReference<T>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dotNetObjectReference");
    }

    /// <summary>
    /// Checks that the Confirm method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallConfirmAsync()
    {
        // Arrange
        var js = _fixture.Create<IJSRuntime>();
        var message = _fixture.Create<string>();

        // Act
        var result = await js.Confirm(message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Confirm method throws when the js parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallConfirmWithNullJsAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).Confirm(_fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that the Confirm method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallConfirmWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().Confirm(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the MyFunction method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMyFunctionAsync()
    {
        // Arrange
        var js = _fixture.Create<IJSRuntime>();
        var message = _fixture.Create<string>();

        // Act
        await js.MyFunction(message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MyFunction method throws when the js parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallMyFunctionWithNullJsAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).MyFunction(_fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that the MyFunction method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallMyFunctionWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().MyFunction(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the SetInLocalStorage method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetInLocalStorageAsync()
    {
        // Arrange
        var js = _fixture.Create<IJSRuntime>();
        var key = _fixture.Create<string>();
        var content = _fixture.Create<string>();

        // Act
        var result = await js.SetInLocalStorage(key, content
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetInLocalStorage method throws when the js parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetInLocalStorageWithNullJsAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).SetInLocalStorage(_fixture.Create<string>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that the SetInLocalStorage method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetInLocalStorageWithInvalidKeyAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().SetInLocalStorage(value, _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the SetInLocalStorage method throws when the content parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetInLocalStorageWithInvalidContentAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().SetInLocalStorage(_fixture.Create<string>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("content");
    }

    /// <summary>
    /// Checks that the GetFromLocalStorage method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetFromLocalStorageAsync()
    {
        // Arrange
        var js = _fixture.Create<IJSRuntime>();
        var key = _fixture.Create<string>();

        // Act
        var result = await js.GetFromLocalStorage(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFromLocalStorage method throws when the js parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetFromLocalStorageWithNullJsAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).GetFromLocalStorage(_fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that the GetFromLocalStorage method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetFromLocalStorageWithInvalidKeyAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().GetFromLocalStorage(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the RemoveItem method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRemoveItemAsync()
    {
        // Arrange
        var js = _fixture.Create<IJSRuntime>();
        var key = _fixture.Create<string>();

        // Act
        var result = await js.RemoveItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveItem method throws when the js parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRemoveItemWithNullJsAsync()
    {
        await FluentActions.Invoking(() => default(IJSRuntime).RemoveItem(_fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that the RemoveItem method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallRemoveItemWithInvalidKeyAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IJSRuntime>().RemoveItem(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("key");
    }
}