namespace ControlEscolar.Api.DTOs;

public class MunicipioDto
{
    public int IdMunicipio { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public int IdEstado { get; set; }
}