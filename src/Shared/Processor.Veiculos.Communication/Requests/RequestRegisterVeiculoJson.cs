﻿namespace Processor.Veiculos.Communication.Requests;

public class RequestRegisteredVeiculoJson
{
    public int Ano { get; set; } = 0;
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;

}
