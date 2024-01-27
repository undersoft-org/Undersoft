using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Application.Server.Hosting;

public class ApplicationServerHostSetup : ServerHostSetup, IApplicationServerHostSetup
{
    public ApplicationServerHostSetup(IApplicationBuilder application) : base(application) { }

    public ApplicationServerHostSetup(
        IApplicationBuilder application,
        IWebHostEnvironment environment
    ) : base(application, environment) { }

    public IApplicationServerHostSetup UseServiceApplication()
    {
        UseCustomSetup(setup =>
        {
            setup.UseHeaderForwarding();

            if (LocalEnvironment.IsDevelopment())
            {
                Application
                    .UseDeveloperExceptionPage()
                    .UseWebAssemblyDebugging();
            }
            else
            {
                Application
                    .UseExceptionHandler("/Error")
                    .UseHsts();
            }

            Application
                .UseHttpsRedirection()
                .UseODataBatching()
                .UseODataQueryRequest()
                .UseBlazorFrameworkFiles()
                .UseStaticFiles()
                .UseRouting()
                .UseCors();

            setup.UseSwaggerSetup(new[] { "v1.0" });

            Application
                .UseAuthentication()
                .UseAuthorization();

            setup
                .UseJwtMiddleware()
                .UseEndpoints(true);
        });

        return this;
    }
}
