using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Uniques;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant.Math;

/// <summary>
/// Unit tests for the type <see cref="InstantMath"/>.
/// </summary>
public class InstantMath_1Tests
{
    private InstantMath<T> _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _data;
    private MathSetRoutine _routines;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantMath"/>.
    /// </summary>
    public InstantMath_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._data = _fixture.Freeze<Mock<IInstantSeries>>();
        this._routines = _fixture.Create<MathSetRoutine>();
        this._testClass = _fixture.Create<InstantMath<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantMath<T>(this._data.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantMath<T>(this._routines);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullData()
    {
        FluentActions.Invoking(() => new InstantMath<T>(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that instance construction throws when the routines parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRoutines()
    {
        FluentActions.Invoking(() => new InstantMath<T>(default(MathSetRoutine))).Should().Throw<ArgumentNullException>().WithParameterName("routines");
    }

    /// <summary>
    /// Checks that the GetMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMathSet()
    {
        // Arrange
        var exp = _fixture.Create<Expression<Func<T, object>>>();

        // Act
        var result = this._testClass.GetMathSet(exp);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMathSet method throws when the exp parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMathSetWithNullExp()
    {
        FluentActions.Invoking(() => this._testClass.GetMathSet(default(Expression<Func<T, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("exp");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexer()
    {
        this._testClass[_fixture.Create<Expression<Func<T, object>>>()].Should().BeAssignableTo<MathSet<T>>();
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="InstantMath"/>.
/// </summary>
public class InstantMathTests
{
    private InstantMath _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _data;
    private MathSetRoutine _routines;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantMath"/>.
    /// </summary>
    public InstantMathTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._data = _fixture.Freeze<Mock<IInstantSeries>>();
        this._routines = _fixture.Create<MathSetRoutine>();
        this._testClass = _fixture.Create<InstantMath>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantMath(this._data.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantMath(this._routines);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullData()
    {
        FluentActions.Invoking(() => new InstantMath(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that instance construction throws when the routines parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRoutines()
    {
        FluentActions.Invoking(() => new InstantMath(default(MathSetRoutine))).Should().Throw<ArgumentNullException>().WithParameterName("routines");
    }

    /// <summary>
    /// Checks that the GetMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMathSetWithId()
    {
        // Arrange
        var id = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetMathSet(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMathSetWithName()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetMathSet(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMathSet method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetMathSetWithNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetMathSet(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMathSetWithMemberRubric()
    {
        // Arrange
        var rubric = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.GetMathSet(rubric);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMathSet method throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMathSetWithMemberRubricWithNullRubric()
    {
        FluentActions.Invoking(() => this._testClass.GetMathSet(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the GetMathSet maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetMathSetWithMemberRubricPerformsMapping()
    {
        // Arrange
        var rubric = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.GetMathSet(rubric);

        // Assert
        result.Rubric.Should().BeSameAs(rubric);
    }

    /// <summary>
    /// Checks that the ContainsFirst method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsFirstWithMemberRubric()
    {
        // Arrange
        var rubric = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.ContainsFirst(rubric);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsFirst method throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsFirstWithMemberRubricWithNullRubric()
    {
        FluentActions.Invoking(() => this._testClass.ContainsFirst(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the ContainsFirst method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsFirstWithRubricName()
    {
        // Arrange
        var rubricName = _fixture.Create<string>();

        // Act
        var result = this._testClass.ContainsFirst(rubricName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsFirst method throws when the rubricName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallContainsFirstWithRubricNameWithInvalidRubricName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ContainsFirst(value)).Should().Throw<ArgumentNullException>().WithParameterName("rubricName");
    }

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompute()
    {
        // Act
        var result = this._testClass.Compute();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeInParallel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeInParallel()
    {
        // Arrange
        var chunks = _fixture.Create<int>();

        // Act
        var result = this._testClass.ComputeInParallel(chunks);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompile()
    {
        // Arrange
        var offset = _fixture.Create<int>();
        var chunk = _fixture.Create<int>();

        // Act
        var result = this._testClass.Compile(offset, chunk);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClone()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Act
        var result = this._testClass.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdBytes()
    {
        // Act
        var result = this._testClass.GetIdBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Routine property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRoutine()
    {
        // Assert
        this._testClass.Routine.Should().BeAssignableTo<MathSetRoutine>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForInt()
    {
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<MathSet>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForString()
    {
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<MathSet>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForMemberRubric()
    {
        this._testClass[_fixture.Create<MemberRubric>()].Should().BeAssignableTo<MathSet>();
        Assert.Fail("Create or modify test");
    }
}