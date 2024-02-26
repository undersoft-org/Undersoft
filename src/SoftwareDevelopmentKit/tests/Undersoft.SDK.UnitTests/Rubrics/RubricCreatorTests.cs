using System;
using System.Collections.Generic;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="RubricBuilder"/>.
/// </summary>
public class RubricBuilderTests
{
    private RubricBuilder _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricBuilder"/>.
    /// </summary>
    public RubricBuilderTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RubricBuilder>();
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithType()
    {
        // Arrange
        var modelType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Create(modelType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the modelType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithTypeWithNullModelType()
    {
        FluentActions.Invoking(() => this._testClass.Create(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("modelType");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithMemberRubrics()
    {
        // Arrange
        var memberRubrics = _fixture.Create<MemberRubric[]>();

        // Act
        var result = this._testClass.Create(memberRubrics);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the memberRubrics parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithMemberRubricsWithNullMemberRubrics()
    {
        FluentActions.Invoking(() => this._testClass.Create(default(MemberRubric[]))).Should().Throw<ArgumentNullException>().WithParameterName("memberRubrics");
    }

    /// <summary>
    /// Checks that the PrepareMembers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPrepareMembers()
    {
        // Arrange
        var membersInfo = _fixture.Create<IEnumerable<MemberInfo>>();

        // Act
        var result = this._testClass.PrepareMembers(membersInfo);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PrepareMembers method throws when the membersInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareMembersWithNullMembersInfo()
    {
        FluentActions.Invoking(() => this._testClass.PrepareMembers(default(IEnumerable<MemberInfo>))).Should().Throw<ArgumentNullException>().WithParameterName("membersInfo");
    }

    /// <summary>
    /// Checks that the GetMembers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMembers()
    {
        // Arrange
        var modelType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetMembers(modelType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMembers method throws when the modelType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMembersWithNullModelType()
    {
        FluentActions.Invoking(() => this._testClass.GetMembers(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("modelType");
    }
}