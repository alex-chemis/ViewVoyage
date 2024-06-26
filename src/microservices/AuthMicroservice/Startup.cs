using AuthMicroservice.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Middleware;
using System;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using HealthChecks.UI.Client;

namespace AuthMicroservice;
public class Startup(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddJwt(Configuration);
        services.AddTransient<IEncryptor, Encryptor>();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "User", Version = "v1" });
        });
        
        services.AddDbContext<AuthDbContext>(o =>
            o.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddHealthChecks().AddDbContextCheck<AuthDbContext>(
            name: "postgresql",
            failureStatus: HealthStatus.Unhealthy
        );
        services.AddHealthChecksUI().AddInMemoryStorage();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetService<AuthDbContext>()?.Database.Migrate();
        }

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog V1");
        });

        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);

        app.UseHealthChecks("/healthz", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}