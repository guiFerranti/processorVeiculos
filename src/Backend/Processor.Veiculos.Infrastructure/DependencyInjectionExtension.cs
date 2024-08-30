using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Processor.Veiculos.Domain.Repositories.Veiculos;
using Processor.Veiculos.Infrastructure.DataAccess.Repositories;
using System.Runtime.CompilerServices;

namespace Processor.Veiculos.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services, IConfiguration configuration)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "veiculos.json");

        services.AddScoped<IVeiculoWriteOnlyRepository>(provider => new VeiculoRepository(filePath));
        services.AddScoped<IVeiculoReadOnlyRepository>(provider => new VeiculoRepository(filePath));
        services.AddScoped<IVeiculoUpdateOnlyRepository>(provider => new VeiculoRepository(filePath));
        services.AddScoped<IVeiculoDeleteOnlyRepository>(provider => new VeiculoRepository(filePath));
    }
}
