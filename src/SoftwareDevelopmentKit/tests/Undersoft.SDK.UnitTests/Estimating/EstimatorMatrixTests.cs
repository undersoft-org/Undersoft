using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorMatrix"/>.
/// </summary>
public class EstimatorMatrixTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the MatrixTranpose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixTranposeWithArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixTranpose(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixTranpose method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixTranposeWithArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixTranpose(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixTranpose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixTranposeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixTranpose(matrix, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixTranpose method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixTranposeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixTranpose(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixTranpose method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixTranposeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixTranpose(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixTranposeSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixTranposeSafe()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixTranposeSafe(matrix, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixTranposeSafe method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixTranposeSafeWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixTranposeSafe(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixTranposeSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixTranposeSafeWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixTranposeSafe(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixCreate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateWithRowsAndCols()
    {
        // Arrange
        var rows = _fixture.Create<int>();
        var cols = _fixture.Create<int>();

        // Act
        var result = EstimatorMatrix.MatrixCreate(rows, cols);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateWithArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixCreate(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreate method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateWithArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreate(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixCreate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateWithArrayOfDouble()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixCreate(vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreate method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateWithArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreate(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateColumnWithArrayOfDouble()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixCreateColumn(vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumn method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateColumnWithArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateColumn(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumnSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateColumnSafe()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixCreateColumnSafe(vector, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumnSafe method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateColumnSafeWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateColumnSafe(default(double[]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumnSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateColumnSafeWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateColumnSafe(_fixture.Create<double[]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateColumnWithArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixCreateColumn(vector, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumn method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateColumnWithArrayOfDoubleAndArrayOfArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateColumn(default(double[]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateColumn method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateColumnWithArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateColumn(_fixture.Create<double[]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixCreateRow method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateRowWithArrayOfDouble()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixCreateRow(vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreateRow method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateRowWithArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateRow(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateRowSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateRowSafe()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixCreateRowSafe(vector, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreateRowSafe method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateRowSafeWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateRowSafe(default(double[]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateRowSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateRowSafeWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateRowSafe(_fixture.Create<double[]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixCreateRow method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixCreateRowWithArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixCreateRow(vector, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixCreateRow method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateRowWithArrayOfDoubleAndArrayOfArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateRow(default(double[]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixCreateRow method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixCreateRowWithArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixCreateRow(_fixture.Create<double[]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixRandom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixRandom()
    {
        // Arrange
        var rows = _fixture.Create<int>();
        var cols = _fixture.Create<int>();
        var minVal = _fixture.Create<double>();
        var maxVal = _fixture.Create<double>();
        var seed = _fixture.Create<int>();

        // Act
        var result = EstimatorMatrix.MatrixRandom(rows, cols, minVal, maxVal, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixZeros method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixZeros()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixZeros(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixZeros method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixZerosWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixZeros(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixIdentity method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixIdentityWithN()
    {
        // Arrange
        var n = _fixture.Create<int>();

        // Act
        var result = EstimatorMatrix.MatrixIdentity(n);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixIdentity method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixIdentityWithArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixIdentity(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixIdentity method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixIdentityWithArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixIdentity(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDiagonalWithNAndValue()
    {
        // Arrange
        var n = _fixture.Create<int>();
        var value = _fixture.Create<double>();

        // Act
        var result = EstimatorMatrix.MatrixDiagonal(n, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDiagonalWithArrayOfArrayOfDoubleAndDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var value = _fixture.Create<double>();

        // Act
        var result = EstimatorMatrix.MatrixDiagonal(matrix, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDiagonalWithArrayOfArrayOfDoubleAndDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDiagonal(default(double[][]), _fixture.Create<double>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDiagonalWithArrayOfDouble()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixDiagonal(vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDiagonalWithArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDiagonal(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDiagonalWithArrayOfArrayOfDoubleAndArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixDiagonal(matrix, vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDiagonalWithArrayOfArrayOfDoubleAndArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDiagonal(default(double[][]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDiagonal method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDiagonalWithArrayOfArrayOfDoubleAndArrayOfDoubleWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDiagonal(_fixture.Create<double[][]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixDiagonalSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDiagonalSafe()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixDiagonalSafe(matrix, vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDiagonalSafe method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDiagonalSafeWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDiagonalSafe(default(double[][]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDiagonalSafe method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDiagonalSafeWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDiagonalSafe(_fixture.Create<double[][]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the MatrixAsString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixAsString()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var dec = _fixture.Create<int>();

        // Act
        var result = EstimatorMatrix.MatrixAsString(matrix, dec);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixAsString method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixAsStringWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixAsString(default(double[][]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixAreEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixAreEqual()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var epsilon = _fixture.Create<double>();

        // Act
        var result = EstimatorMatrix.MatrixAreEqual(matrixA, matrixB, epsilon);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixAreEqual method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixAreEqualWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixAreEqual(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixAreEqual method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixAreEqualWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixAreEqual(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSum method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixSum(matrixA, matrixB);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixSum method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSum(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixSum method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSum(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSum method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixSum(matrixA, matrixB, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixSum method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSum(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixSum method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSum(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSum method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSum(_fixture.Create<double[][]>(), _fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixSumSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixSumSafe()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixSumSafe(matrixA, matrixB, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixSumSafe method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumSafeWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSumSafe(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixSumSafe method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumSafeWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSumSafe(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSumSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSumSafeWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSumSafe(_fixture.Create<double[][]>(), _fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixSub method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixSub(matrixA, matrixB);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixSub method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSub(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixSub method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSub(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSub method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixSub(matrixA, matrixB, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixSub method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSub(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixSub method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSub(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSub method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSub(_fixture.Create<double[][]>(), _fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixSubSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixSubSafe()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixSubSafe(matrixA, matrixB, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixSubSafe method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubSafeWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSubSafe(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixSubSafe method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubSafeWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSubSafe(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixSubSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixSubSafeWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixSubSafe(_fixture.Create<double[][]>(), _fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixProduct(matrixA, matrixB);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixProduct(matrixA, matrixB, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(_fixture.Create<double[][]>(), _fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixProductSafeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrixA = _fixture.Create<double[][]>();
        var matrixB = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixProductSafe(matrixA, matrixB, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method throws when the matrixA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductSafeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProductSafe(default(double[][]), _fixture.Create<double[][]>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixA");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method throws when the matrixB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductSafeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrixB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProductSafe(_fixture.Create<double[][]>(), default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrixB");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductSafeWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProductSafe(_fixture.Create<double[][]>(), _fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixProductWithArrayOfArrayOfDoubleAndDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var value = _fixture.Create<double>();

        // Act
        var result = EstimatorMatrix.MatrixProduct(matrix, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(default(double[][]), _fixture.Create<double>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixProductWithArrayOfArrayOfDoubleAndDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var value = _fixture.Create<double>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixProduct(matrix, value, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndDoubleAndArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(default(double[][]), _fixture.Create<double>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixProduct method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductWithArrayOfArrayOfDoubleAndDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProduct(_fixture.Create<double[][]>(), _fixture.Create<double>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixProductSafeWithArrayOfArrayOfDoubleAndDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var value = _fixture.Create<double>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixProductSafe(matrix, value, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductSafeWithArrayOfArrayOfDoubleAndDoubleAndArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProductSafe(default(double[][]), _fixture.Create<double>(), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixProductSafe method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixProductSafeWithArrayOfArrayOfDoubleAndDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixProductSafe(_fixture.Create<double[][]>(), _fixture.Create<double>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the ScalarProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallScalarProduct()
    {
        // Arrange
        var vectorA = _fixture.Create<double[]>();
        var vectorB = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.ScalarProduct(vectorA, vectorB);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ScalarProduct method throws when the vectorA parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallScalarProductWithNullVectorA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.ScalarProduct(default(double[]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("vectorA");
    }

    /// <summary>
    /// Checks that the ScalarProduct method throws when the vectorB parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallScalarProductWithNullVectorB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.ScalarProduct(_fixture.Create<double[]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vectorB");
    }

    /// <summary>
    /// Checks that the MatrixVectorProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixVectorProduct()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var vector = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.MatrixVectorProduct(matrix, vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixVectorProduct method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixVectorProductWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixVectorProduct(default(double[][]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixVectorProduct method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixVectorProductWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixVectorProduct(_fixture.Create<double[][]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the VectorMatrixProduct method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallVectorMatrixProduct()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.VectorMatrixProduct(vector, matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the VectorMatrixProduct method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallVectorMatrixProductWithNullVector()
    {
        FluentActions.Invoking(() => EstimatorMatrix.VectorMatrixProduct(default(double[]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the VectorMatrixProduct method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallVectorMatrixProductWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.VectorMatrixProduct(_fixture.Create<double[]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDecompose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDecompose()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixDecompose(matrix, out var perm, out var toggle);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDecompose method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDecomposeWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDecompose(default(double[][]), out _, out _)).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixInverse method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixInverseWithArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixInverse(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixInverse method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixInverseWithArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixInverse(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixInverse method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixInverseWithArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixInverse(matrix, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixInverse method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixInverseWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixInverse(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixInverse method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixInverseWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixInverse(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixDeterminant method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDeterminant()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixDeterminant(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDeterminant method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDeterminantWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDeterminant(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the HelperSolve method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHelperSolve()
    {
        // Arrange
        var luMatrix = _fixture.Create<double[][]>();
        var b = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.HelperSolve(luMatrix, b);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HelperSolve method throws when the luMatrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHelperSolveWithNullLuMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.HelperSolve(default(double[][]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("luMatrix");
    }

    /// <summary>
    /// Checks that the HelperSolve method throws when the b parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHelperSolveWithNullB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.HelperSolve(_fixture.Create<double[][]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("b");
    }

    /// <summary>
    /// Checks that the SystemSolve method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSystemSolve()
    {
        // Arrange
        var A = _fixture.Create<double[][]>();
        var b = _fixture.Create<double[]>();

        // Act
        var result = EstimatorMatrix.SystemSolve(A, b);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SystemSolve method throws when the A parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSystemSolveWithNullA()
    {
        FluentActions.Invoking(() => EstimatorMatrix.SystemSolve(default(double[][]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("A");
    }

    /// <summary>
    /// Checks that the SystemSolve method throws when the b parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSystemSolveWithNullB()
    {
        FluentActions.Invoking(() => EstimatorMatrix.SystemSolve(_fixture.Create<double[][]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("b");
    }

    /// <summary>
    /// Checks that the MatrixDuplicate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDuplicateWithArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixDuplicate(matrix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDuplicate method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDuplicateWithArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDuplicate(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDuplicate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixDuplicateWithArrayOfArrayOfDoubleAndArrayOfArrayOfDouble()
    {
        // Arrange
        var matrix = _fixture.Create<double[][]>();
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixDuplicate(matrix, result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixDuplicate method throws when the matrix parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDuplicateWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullMatrix()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDuplicate(default(double[][]), _fixture.Create<double[][]>())).Should().Throw<ArgumentNullException>().WithParameterName("matrix");
    }

    /// <summary>
    /// Checks that the MatrixDuplicate method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixDuplicateWithArrayOfArrayOfDoubleAndArrayOfArrayOfDoubleWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixDuplicate(_fixture.Create<double[][]>(), default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that the MatrixTest method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMatrixTest()
    {
        // Arrange
        var result = _fixture.Create<double[][]>();

        // Act
        var result = EstimatorMatrix.MatrixTest(result);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MatrixTest method throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMatrixTestWithNullResult()
    {
        FluentActions.Invoking(() => EstimatorMatrix.MatrixTest(default(double[][]))).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }
}