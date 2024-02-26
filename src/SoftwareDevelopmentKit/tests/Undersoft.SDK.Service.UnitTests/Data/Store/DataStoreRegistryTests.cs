using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Store;
using TEntity = System.String;
using TOrigin = System.String;
using TStore = System.String;
using TTarget = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Store;

/// <summary>
/// Unit tests for the type <see cref="DataStoreRegistry"/>.
/// </summary>
public class DataStoreRegistryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetEntityProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityPropertiesWithIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetEntityProperties();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityProperties method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityPropertiesWithIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntityProperties()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntityProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityPropertiesWithType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetEntityProperties(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityProperties method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityPropertiesWithTypeWithNullContextType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetEntityProperties(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the GetEntityTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityTypesWithIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetEntityTypes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityTypes method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityTypesWithIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntityTypes()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntityTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityTypesWithType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetEntityTypes(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityTypes method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityTypesWithTypeWithNullContextType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetEntityTypes(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the GetRemoteType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRemoteType()
    {
        // Arrange
        var remoteName = _fixture.Create<string>();

        // Act
        var result = DataStoreRegistry.GetRemoteType(remoteName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRemoteType method throws when the remoteName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetRemoteTypeWithInvalidRemoteName(string value)
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetRemoteType(value)).Should().Throw<ArgumentNullException>().WithParameterName("remoteName");
    }

    /// <summary>
    /// Checks that the GetRemoteMembers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRemoteMembersWithIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetRemoteMembers();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRemoteMembers method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRemoteMembersWithIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetRemoteMembers()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetStoreType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStoreTypeWithIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetStoreType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStoreType method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStoreTypeWithIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetStoreType()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetStoreType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStoreTypeWithType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetStoreType(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStoreType method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStoreTypeWithTypeWithNullContextType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetStoreType(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndentityPropertiesWithIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context
        .GetIndentityProperties();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIndentityPropertiesWithIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetIndentityProperties()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetIdentityProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdentityPropertyWithEntityTypeAndIdentityType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();
        var identityType = _fixture.Create<DbIdentityType>();

        // Act
        var result = DataStoreRegistry.GetIdentityProperty(entityType, identityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdentityProperty method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIdentityPropertyWithEntityTypeAndIdentityTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetIdentityProperty(default(Type), _fixture.Create<DbIdentityType>())).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetIdentityProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdentityPropertyWithEntityAndIdentityType()
    {
        // Arrange
        var entity = _fixture.Create<IIdentifiable>();
        var identityType = _fixture.Create<DbIdentityType>();

        // Act
        var result = entity.GetIdentityProperty(identityType
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdentityProperty method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIdentityPropertyWithEntityAndIdentityTypeWithNullEntity()
    {
        FluentActions.Invoking(() => default(IIdentifiable).GetIdentityProperty(_fixture.Create<DbIdentityType>())).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndentityPropertiesWithIOrigin()
    {
        // Arrange
        var entity = _fixture.Create<IOrigin>();

        // Act
        var result = entity.GetIndentityProperties();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIndentityPropertiesWithIOriginWithNullEntity()
    {
        FluentActions.Invoking(() => default(IOrigin).GetIndentityProperties()).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndentityPropertiesWithIIdentifiable()
    {
        // Arrange
        var entity = _fixture.Create<IIdentifiable>();

        // Act
        var result = entity.GetIndentityProperties();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIndentityPropertiesWithIIdentifiableWithNullEntity()
    {
        FluentActions.Invoking(() => default(IIdentifiable).GetIndentityProperties()).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndentityPropertiesWithType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetIndentityProperties(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndentityProperties method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIndentityPropertiesWithTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetIndentityProperties(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPropertyWithIDataStoreContextAndString()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityTypeName = _fixture.Create<string>();

        // Act
        var result = context.GetProperty(entityTypeName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithIDataStoreContextAndStringWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetProperty(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the entityTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetPropertyWithIDataStoreContextAndStringWithInvalidEntityTypeName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<IDataStoreContext>().GetProperty(value)).Should().Throw<ArgumentNullException>().WithParameterName("entityTypeName");
    }

    /// <summary>
    /// Checks that the GetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPropertyWithIDataStoreContextAndType()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = context.GetProperty(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithIDataStoreContextAndTypeWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetProperty(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithIDataStoreContextAndTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => _fixture.Create<IDataStoreContext>().GetProperty(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetProperty maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetPropertyWithIDataStoreContextAndTypePerformsMapping()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = context.GetProperty(entityType);

        // Assert
        result.Attributes.Should().Be(entityType.Attributes);
        result.IsSpecialName.Should().Be(entityType.IsSpecialName);
        result.MemberType.Should().Be(entityType.MemberType);
    }

    /// <summary>
    /// Checks that the GetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPropertyWithTEntityAndIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetProperty<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithTEntityAndIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetProperty<TEntity>()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntityType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityTypeWithIDataStoreContextAndString()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityTypeName = _fixture.Create<string>();

        // Act
        var result = context.GetEntityType(entityTypeName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityType method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityTypeWithIDataStoreContextAndStringWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntityType(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntityType method throws when the entityTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetEntityTypeWithIDataStoreContextAndStringWithInvalidEntityTypeName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<IDataStoreContext>().GetEntityType(value)).Should().Throw<ArgumentNullException>().WithParameterName("entityTypeName");
    }

    /// <summary>
    /// Checks that the GetEntityType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityTypeWithIDataStoreContextAndType()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = context.GetEntityType(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityType method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityTypeWithIDataStoreContextAndTypeWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntityType(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntityType method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityTypeWithIDataStoreContextAndTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => _fixture.Create<IDataStoreContext>().GetEntityType(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetEntityType maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetEntityTypeWithIDataStoreContextAndTypePerformsMapping()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = context.GetEntityType(entityType);

        // Assert
        result.BaseType.Should().BeSameAs(entityType.BaseType);
    }

    /// <summary>
    /// Checks that the GetEntityType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntityTypeWithTEntityAndIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetEntityType<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntityType method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntityTypeWithTEntityAndIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntityType<TEntity>()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetRemoteMembers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRemoteMembersWithType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetRemoteMembers(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRemoteMembers method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRemoteMembersWithTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetRemoteMembers(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetRemoteMembers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRemoteMembersWithTOrigin()
    {
        // Act
        var result = DataStoreRegistry.GetRemoteMembers<TOrigin>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRemoteMember method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRemoteMemberWithEntityTypeAndTargetType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();
        var targetType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetRemoteMember(entityType, targetType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRemoteMember method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRemoteMemberWithEntityTypeAndTargetTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetRemoteMember(default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetRemoteMember method throws when the targetType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRemoteMemberWithEntityTypeAndTargetTypeWithNullTargetType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetRemoteMember(_fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
    }

    /// <summary>
    /// Checks that the GetRemoteMember maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRemoteMemberWithEntityTypeAndTargetTypePerformsMapping()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();
        var targetType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetRemoteMember(entityType, targetType);

        // Assert
        result.DeclaringType.Should().BeSameAs(entityType.DeclaringType);
        result.MemberType.Should().Be(entityType.MemberType);
        result.ReflectedType.Should().BeSameAs(entityType.ReflectedType);
        result.DeclaringType.Should().BeSameAs(targetType.DeclaringType);
        result.MemberType.Should().Be(targetType.MemberType);
        result.ReflectedType.Should().BeSameAs(targetType.ReflectedType);
    }

    /// <summary>
    /// Checks that the GetRemoteMember method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRemoteMemberWithTOriginAndTTarget()
    {
        // Act
        var result = DataStoreRegistry.GetRemoteMember<TOrigin, TTarget>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntitySetWithIDataStoreContextAndString()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityTypeName = _fixture.Create<string>();

        // Act
        var result = context.GetEntitySet(entityTypeName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntitySet method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntitySetWithIDataStoreContextAndStringWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntitySet(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntitySet method throws when the entityTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetEntitySetWithIDataStoreContextAndStringWithInvalidEntityTypeName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<IDataStoreContext>().GetEntitySet(value)).Should().Throw<ArgumentNullException>().WithParameterName("entityTypeName");
    }

    /// <summary>
    /// Checks that the GetEntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntitySetWithIDataStoreContextAndType()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = context.GetEntitySet(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntitySet method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntitySetWithIDataStoreContextAndTypeWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntitySet(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetEntitySet method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntitySetWithIDataStoreContextAndTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => _fixture.Create<IDataStoreContext>().GetEntitySet(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetEntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEntitySetWithTEntityAndIDataStoreContext()
    {
        // Arrange
        var context = _fixture.Create<IDataStoreContext>();

        // Act
        var result = context.GetEntitySet<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEntitySet method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEntitySetWithTEntityAndIDataStoreContextWithNullContext()
    {
        FluentActions.Invoking(() => default(IDataStoreContext).GetEntitySet<TEntity>()).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the GetContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContextWithStoreTypeAndEntityType()
    {
        // Arrange
        var storeType = _fixture.Create<Type>();
        var entityType = _fixture.Create<Type>();

        // Act
        var result = DataStoreRegistry.GetContext(storeType, entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContext method throws when the storeType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetContextWithStoreTypeAndEntityTypeWithNullStoreType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetContext(default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("storeType");
    }

    /// <summary>
    /// Checks that the GetContext method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetContextWithStoreTypeAndEntityTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => DataStoreRegistry.GetContext(_fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the GetContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContextWithTStoreAndTEntity()
    {
        // Act
        var result = DataStoreRegistry.GetContext<TStore, TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContexts method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContexts()
    {
        // Act
        var result = DataStoreRegistry.GetContexts<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}