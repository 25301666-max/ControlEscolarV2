namespace ControlEscolar.Api.DTOs;

public class LocalidadDto
{
    public int IdLocalidad { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public int IdMunicipio { get; set; }
}