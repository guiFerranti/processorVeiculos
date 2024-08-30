using Processor.Veiculos.Communication.Requests;
using Processor.Veiculos.Domain.Entities;
using Processor.Veiculos.Domain.Repositories.Veiculos;
using System.Text.Json;

namespace Processor.Veiculos.Infrastructure.DataAccess.Repositories;

public class VeiculoRepository : IVeiculoWriteOnlyRepository, IVeiculoReadOnlyRepository, IVeiculoUpdateOnlyRepository
{
    private readonly string _filePath;
    public VeiculoRepository(string filePath)
    {
        _filePath = filePath;
    }


    public async Task Add(Veiculo veiculo)
    {
        List<Veiculo> veiculos;

        if (File.Exists(_filePath))
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);

            veiculos = JsonSerializer.Deserialize<List<Veiculo>>(jsonString) ?? new List<Veiculo>();
        }
        else
        {
            veiculos = new List<Veiculo>();
        }

        veiculos.Add(veiculo);

        var newJsonString = JsonSerializer.Serialize(veiculos, new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(_filePath, newJsonString);

    }

    public async Task<bool> Exists(long id)
    {
        if (!File.Exists(_filePath))
        {
            return false;
        }

        var jsonString = await File.ReadAllTextAsync(_filePath);
        var veiculos = JsonSerializer.Deserialize<List<Veiculo>>(jsonString) ?? new List<Veiculo>();

        var exists = veiculos.Any(v => v.Id == id);

        return exists;
    }

    public async Task<IEnumerable<Veiculo>> GetAll()
    {
        if (File.Exists(_filePath))
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);
            var veiculos = JsonSerializer.Deserialize<List<Veiculo>>(jsonString) ?? new List<Veiculo>();
            return veiculos;
        }

        return Enumerable.Empty<Veiculo>();
    }

    public async Task<Veiculo> GetById(long id)
    {
        if (File.Exists(_filePath))
        {
            var jsonString = await File.ReadAllTextAsync(_filePath);
            var veiculos = JsonSerializer.Deserialize<List<Veiculo>>(jsonString);

            if (veiculos != null)
            {
                return veiculos.FirstOrDefault(v => v.Id == id);
            }
        }

        return null;
    }

    public async Task Update(long id, Veiculo veiculoAtualizado)
    {
        var veiculos = await GetAll();
        var veiculoExistente = await GetById(id);

        veiculoExistente.Ano = veiculoAtualizado.Ano;
        veiculoExistente.Modelo = veiculoAtualizado.Modelo;
        veiculoExistente.Marca = veiculoAtualizado.Marca;
        veiculoExistente.UpdatedAt = DateTime.UtcNow;

        var veiculosAtualizados = veiculos
            .Select(v => v.Id == id ? veiculoExistente : v)
            .ToList();


        var newJsonString = JsonSerializer.Serialize(veiculosAtualizados, new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(_filePath, newJsonString);
    }
}
