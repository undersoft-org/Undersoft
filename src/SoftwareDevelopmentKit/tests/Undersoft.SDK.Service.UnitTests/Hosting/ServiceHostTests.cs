using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServiceHost"/>.
/// </summary>
public class ServiceHostTests
{
    private ServiceHost _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceHost"/>.
    /// </summary>
    public ServiceHostTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ServiceHost>();
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StartAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallStartAsync()
    {
        // Arrange
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.StartAsync(cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StopAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallStopAsync()
    {
        // Arrange
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.StopAsync(cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that setting the Host property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHost()
    {
        this._testClass.CheckProperty(x => x.Host, _fixture.Create<IHost>(), _fixture.Create<IHost>());
    }

    /// <summary>
    /// Checks that setting the HostName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHostName()
    {
        this._testClass.CheckProperty(x => x.HostName);
    }

    /// <summary>
    /// Checks that setting the Address property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAddress()
    {
        this._testClass.CheckProperty(x => x.Address);
    }

    /// <summary>
    /// Checks that setting the Port property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPort()
    {
        this._testClass.CheckProperty(x => x.Port);
    }

    /// <summary>
    /// Checks that setting the Certificate property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCertificate()
    {
        this._testClass.CheckProperty(x => x.Certificate, _fixture.Create<SslCertificate>(), _fixture.Create<SslCertificate>());
    }

    /// <summary>
    /// Checks that setting the Route property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoute()
    {
        this._testClass.CheckProperty(x => x.Route);
    }

    /// <summary>
    /// Checks that setting the TenantId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTenantId()
    {
        this._testClass.CheckProperty(x => x.TenantId);
    }

    /// <summary>
    /// Checks that setting the TenantName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTenantName()
    {
        this._testClass.CheckProperty(x => x.TenantName);
    }

    /// <summary>
    /// Checks that the Services property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetServices()
    {
        // Assert
        this._testClass.Services.Should().BeAssignableTo<IServiceProvider>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Servicer property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServicer()
    {
        this._testClass.CheckProperty(x => x.Servicer, _fixture.Create<IServicer>(), _fixture.Create<IServicer>());
    }
}