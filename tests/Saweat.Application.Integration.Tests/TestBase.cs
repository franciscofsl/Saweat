using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Saweat.Application.Contracts.Common;
using System;
using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]

namespace Saweat.Application.Integration.Tests;

public abstract class TestBase : IDisposable
{
    private static IConfiguration _configuration = null!;

    private static WebApplicationFactory<Program> _factory = null!;

    private static Respawner _checkpoint = null!;

    private static IServiceScopeFactory _scopeFactory = null!;

    public TestBase()
    {
        _factory = new CustomWebApplicationFactory();
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();

        _configuration = _factory.Services.GetRequiredService<IConfiguration>();

        var context = GetRequiredService<IDbContext>();
        context.EnsureCreatedDatabase();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        return await mediator.Send(request);
    }

    public TService GetRequiredService<TService>()
    {
        var scope = _scopeFactory.CreateScope();

        return scope.ServiceProvider.GetRequiredService<TService>();
    }

    public void Dispose()
    {
        Task.Run(async () => {
            await _checkpoint.ResetAsync(_configuration.GetConnectionString("DefaultConnection"));
        });
    }
}