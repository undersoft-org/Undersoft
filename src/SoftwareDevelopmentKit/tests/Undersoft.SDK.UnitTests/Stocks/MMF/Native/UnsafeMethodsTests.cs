using System;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.SafeHandles;
using Undersoft.SDK.Stocks.MMF.Handle;
using Undersoft.SDK.Stocks.MMF.Native;

namespace Undersoft.SDK.UnitTests.Stocks.MMF.Native;

/// <summary>
/// Unit tests for the type <see cref="UnsafeMethods"/>.
/// </summary>
public class UnsafeMethodsTests
{
    private UnsafeMethods _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UnsafeMethods"/>.
    /// </summary>
    public UnsafeMethodsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<UnsafeMethods>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UnsafeMethods();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the FormatMessage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFormatMessage()
    {
        // Arrange
        var dwFlags = _fixture.Create<int>();
        var lpSource = _fixture.Create<nint>();
        var dwMessageId = _fixture.Create<int>();
        var dwLanguageId = _fixture.Create<int>();
        var lpBuffer = _fixture.Create<StringBuilder>();
        var nSize = _fixture.Create<int>();
        var va_list_arguments = _fixture.Create<nint>();

        // Act
        var result = UnsafeMethods.FormatMessage(dwFlags, lpSource, dwMessageId, dwLanguageId, lpBuffer, nSize, va_list_arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FormatMessage method throws when the lpBuffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFormatMessageWithNullLpBuffer()
    {
        FluentActions.Invoking(() => UnsafeMethods.FormatMessage(_fixture.Create<int>(), _fixture.Create<nint>(), _fixture.Create<int>(), _fixture.Create<int>(), default(StringBuilder), _fixture.Create<int>(), _fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("lpBuffer");
    }

    /// <summary>
    /// Checks that the GetMessage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMessage()
    {
        // Arrange
        var errorCode = _fixture.Create<int>();

        // Act
        var result = UnsafeMethods.GetMessage(errorCode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CloseHandle method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCloseHandle()
    {
        // Arrange
        var handle = _fixture.Create<nint>();

        // Act
        var result = UnsafeMethods.CloseHandle(handle);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFileMapping method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateFileMappingWithHFileAndLpAttributesAndFProtectAndDwMaxSizeHiAndDwMaxSizeLoAndLpName()
    {
        // Arrange
        var hFile = _fixture.Create<SafeFileHandle>();
        var lpAttributes = _fixture.Create<nint>();
        var fProtect = _fixture.Create<UnsafeMethods.FileMapProtection>();
        var dwMaxSizeHi = _fixture.Create<int>();
        var dwMaxSizeLo = _fixture.Create<int>();
        var lpName = _fixture.Create<string>();

        // Act
        var result = UnsafeMethods.CreateFileMapping(hFile, lpAttributes, fProtect, dwMaxSizeHi, dwMaxSizeLo, lpName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFileMapping method throws when the hFile parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateFileMappingWithHFileAndLpAttributesAndFProtectAndDwMaxSizeHiAndDwMaxSizeLoAndLpNameWithNullHFile()
    {
        FluentActions.Invoking(() => UnsafeMethods.CreateFileMapping(default(SafeFileHandle), _fixture.Create<nint>(), _fixture.Create<UnsafeMethods.FileMapProtection>(), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("hFile");
    }

    /// <summary>
    /// Checks that the CreateFileMapping method throws when the lpName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateFileMappingWithHFileAndLpAttributesAndFProtectAndDwMaxSizeHiAndDwMaxSizeLoAndLpNameWithInvalidLpName(string value)
    {
        FluentActions.Invoking(() => UnsafeMethods.CreateFileMapping(_fixture.Create<SafeFileHandle>(), _fixture.Create<nint>(), _fixture.Create<UnsafeMethods.FileMapProtection>(), _fixture.Create<int>(), _fixture.Create<int>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("lpName");
    }

    /// <summary>
    /// Checks that the CreateFileMapping method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateFileMappingWithHFileAndFlProtectAndDdMaxSizeAndLpName()
    {
        // Arrange
        var hFile = _fixture.Create<SafeFileHandle>();
        var flProtect = _fixture.Create<UnsafeMethods.FileMapProtection>();
        var ddMaxSize = _fixture.Create<long>();
        var lpName = _fixture.Create<string>();

        // Act
        var result = UnsafeMethods.CreateFileMapping(hFile, flProtect, ddMaxSize, lpName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFileMapping method throws when the hFile parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateFileMappingWithHFileAndFlProtectAndDdMaxSizeAndLpNameWithNullHFile()
    {
        FluentActions.Invoking(() => UnsafeMethods.CreateFileMapping(default(SafeFileHandle), _fixture.Create<UnsafeMethods.FileMapProtection>(), _fixture.Create<long>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("hFile");
    }

    /// <summary>
    /// Checks that the CreateFileMapping method throws when the lpName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateFileMappingWithHFileAndFlProtectAndDdMaxSizeAndLpNameWithInvalidLpName(string value)
    {
        FluentActions.Invoking(() => UnsafeMethods.CreateFileMapping(_fixture.Create<SafeFileHandle>(), _fixture.Create<UnsafeMethods.FileMapProtection>(), _fixture.Create<long>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("lpName");
    }

    /// <summary>
    /// Checks that the GetSystemInfo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSystemInfo()
    {
        // Arrange
        var lpSystemInfo = _fixture.Create<UnsafeMethods.SYSTEM_INFO>();

        // Act
        UnsafeMethods.GetSystemInfo(ref lpSystemInfo);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapViewOfFile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapViewOfFileWithHFileMappingObjectAndDwDesiredAccessAndDwFileOffsetHighAndDwFileOffsetLowAndDwNumberOfBytesToMap()
    {
        // Arrange
        var hFileMappingObject = _fixture.Create<SafeMMFileHandle>();
        var dwDesiredAccess = _fixture.Create<UnsafeMethods.FileMapAccess>();
        var dwFileOffsetHigh = _fixture.Create<uint>();
        var dwFileOffsetLow = _fixture.Create<uint>();
        var dwNumberOfBytesToMap = _fixture.Create<nuint>();

        // Act
        var result = UnsafeMethods.MapViewOfFile(hFileMappingObject, dwDesiredAccess, dwFileOffsetHigh, dwFileOffsetLow, dwNumberOfBytesToMap);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapViewOfFile method throws when the hFileMappingObject parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapViewOfFileWithHFileMappingObjectAndDwDesiredAccessAndDwFileOffsetHighAndDwFileOffsetLowAndDwNumberOfBytesToMapWithNullHFileMappingObject()
    {
        FluentActions.Invoking(() => UnsafeMethods.MapViewOfFile(default(SafeMMFileHandle), _fixture.Create<UnsafeMethods.FileMapAccess>(), _fixture.Create<uint>(), _fixture.Create<uint>(), _fixture.Create<nuint>())).Should().Throw<ArgumentNullException>().WithParameterName("hFileMappingObject");
    }

    /// <summary>
    /// Checks that the MapViewOfFile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapViewOfFileWithHFileMappingObjectAndDwDesiredAccessAndDdFileOffsetAndDwNumberofBytesToMap()
    {
        // Arrange
        var hFileMappingObject = _fixture.Create<SafeMMFileHandle>();
        var dwDesiredAccess = _fixture.Create<UnsafeMethods.FileMapAccess>();
        var ddFileOffset = _fixture.Create<ulong>();
        var dwNumberofBytesToMap = _fixture.Create<nuint>();

        // Act
        var result = UnsafeMethods.MapViewOfFile(hFileMappingObject, dwDesiredAccess, ddFileOffset, dwNumberofBytesToMap);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapViewOfFile method throws when the hFileMappingObject parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapViewOfFileWithHFileMappingObjectAndDwDesiredAccessAndDdFileOffsetAndDwNumberofBytesToMapWithNullHFileMappingObject()
    {
        FluentActions.Invoking(() => UnsafeMethods.MapViewOfFile(default(SafeMMFileHandle), _fixture.Create<UnsafeMethods.FileMapAccess>(), _fixture.Create<ulong>(), _fixture.Create<nuint>())).Should().Throw<ArgumentNullException>().WithParameterName("hFileMappingObject");
    }

    /// <summary>
    /// Checks that the OpenFileMapping method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpenFileMapping()
    {
        // Arrange
        var dwDesiredAccess = _fixture.Create<uint>();
        var bInheritHandle = _fixture.Create<bool>();
        var lpName = _fixture.Create<string>();

        // Act
        var result = UnsafeMethods.OpenFileMapping(dwDesiredAccess, bInheritHandle, lpName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OpenFileMapping method throws when the lpName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallOpenFileMappingWithInvalidLpName(string value)
    {
        FluentActions.Invoking(() => UnsafeMethods.OpenFileMapping(_fixture.Create<uint>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("lpName");
    }

    /// <summary>
    /// Checks that the UnmapViewOfFile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnmapViewOfFile()
    {
        // Arrange
        var lpBaseAddress = _fixture.Create<nint>();

        // Act
        var result = UnsafeMethods.UnmapViewOfFile(lpBaseAddress);

        // Assert
        Assert.Fail("Create or modify test");
    }
}