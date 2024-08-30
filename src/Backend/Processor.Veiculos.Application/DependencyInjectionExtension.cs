using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Processor.Veiculos.Application.Services.AutoMapper;
using Processor.Veiculos.Application.UseCases.Veiculos.Delete;
using Processor.Veiculos.Application.UseCases.Veiculos.GetById;
using Processor.Veiculos.Application.UseCases.Veiculos.Register;
using Processor.Veiculos.Application.UseCases.Veiculos.Update;
using Processor.Veiculos.Domain.Repositories.Veiculos;

namespace Processor.Veiculos.Application;

public static class DependencyInjectionExtension
{
    public static void AddAplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        var autoMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        }).CreateMapper();

        services.AddScoped(cfg => autoMapper);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterVeiculoUseCase, RegisterVeiculoUseCase>();
        services.AddScoped<IGetVeiculoById, GetVeiculoById>();
        services.AddScoped<IUpdateVeiculo, UpdateVeiculo>();
        services.AddScoped<IDeleteVeiculo, DeleteVeiculo>();   
    }
}
