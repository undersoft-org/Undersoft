using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client;
using TEntity = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Client;

/// <summary>
/// Unit tests for the type <see cref="OpenDataRegistry"/>.
/// </summary>
public class OpenDataRegistryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetEdmModel method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetEdmModelAsync()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();

        // Act
        var result = await context.GetEdmModel();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEdmModel method throws when the context parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetEdmModelWithNullContextAsync()
    {
        await FluentActions.Invoking(() => default(OpenDataContext).GetEdmModel()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEdmModelSync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEdmModelSync()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();

        // Act
        var result = context.GetEdmModelSync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEdmModelSync method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEdmModelSyncWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).GetEdmModelSync()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEdmModelAsync method throws when the context parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetEdmModelAsyncWithNullContextAsync()
    {
        await FluentActions.Invoking(() => default(OpenDataContext).GetEdmModelAsync()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEdmEntityTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEdmEntityTypes()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();

        // Act
        var result = context.GetEdmEntityTypes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEdmEntityTypes method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEdmEntityTypesWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).GetEdmEntityTypes()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetLinkedStoreType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetLinkedStoreTypeWithOpenDataContext()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();

        // Act
        var result = context.GetLinkedStoreType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetLinkedStoreType method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetLinkedStoreTypeWithOpenDataContextWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).GetLinkedStoreType()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetLinkedStoreType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetLinkedStoreTypeWithContextType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = OpenDataRegistry.GetLinkedStoreType(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetLinkedStoreType method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetLinkedStoreTypeWithContextTypeWithNullContextType()
    {
        FluentActions.Invoking(() => OpenDataRegistry.GetLinkedStoreType(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the GetMappedType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMappedTypeWithName()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = OpenDataRegistry.GetMappedType(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMappedType method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetMappedTypeWithNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => OpenDataRegistry.GetMappedType(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetMappedType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMappedTypeWithContextAndName()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();
        var name = _fixture.Create<string>();

        // Act
        var result = context.GetMappedType(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMappedType method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMappedTypeWithContextAndNameWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).GetMappedType(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetMappedType method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetMappedTypeWithContextAndNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().GetMappedType(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetMappedName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMappedName()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = context.GetMappedName(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMappedName method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMappedNameWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).GetMappedName(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetMappedName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMappedNameWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().GetMappedName(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetMappedFullName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMappedFullName()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = context.GetMappedFullName(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMappedFullName method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMappedFullNameWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).GetMappedFullName(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetMappedFullName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMappedFullNameWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().GetMappedFullName(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetContextType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContextTypeWithTStoreAndTEntity()
    {
        // Act
        var result = OpenDataRegistry.GetContextType<TStore, TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContextType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContextTypeWithStoreTypeAndEntityType()
    {
        // Arrange
        var storeType = _fixture.Create<Type>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = OpenDataRegistry.GetContextType(storeType, entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContextType method throws when the storeType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetContextTypeWithStoreTypeAndEntityTypeWithNullStoreType()
    {
        FluentActions.Invoking(() => OpenDataRegistry.GetContextType(default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("storeType");
    }

    /// <summary>
    /// Checks that the GetContextType method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetContextTypeWithStoreTypeAndEntityTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => OpenDataRegistry.GetContextType(_fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetEntityStoreTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityStoreTypes()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();

        // Act
        var result = OpenDataRegistry.GetEntityStoreTypes(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityStoreTypes method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityStoreTypesWithNullEntityType()
    {
        FluentActions.Invoking(() => OpenDataRegistry.GetEntityStoreTypes(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetContextTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContextTypesWithType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();

        // Act
        var result = OpenDataRegistry.GetContextTypes(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContextTypes method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetContextTypesWithTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => OpenDataRegistry.GetContextTypes(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetContextTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContextTypesWithTEntity()
    {
        // Act
        var result = OpenDataRegistry.GetContextTypes<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}