using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SDK.Service.UnitTests.Data.Store;

/// <summary>
/// Unit tests for the type <see cref="DataStoreSchema"/>.
/// </summary>
public class DataStoreSchemaTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the DomainSchema property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetDomainSchema()
    {
        // Assert
        DataStoreSchema.DomainSchema.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoteSchema property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRemoteSchema()
    {
        // Assert
        DataStoreSchema.RemoteSchema.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IdentifierSchema property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIdentifierSchema()
    {
        // Assert
        DataStoreSchema.IdentifierSchema.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelationSchema property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRelationSchema()
    {
        // Assert
        DataStoreSchema.RelationSchema.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PropertySchema property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPropertySchema()
    {
        // Assert
        DataStoreSchema.PropertySchema.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }
}