namespace ControlEscolar.Api.DTOs;

public class CrearAlumnoDto
{
    public string Matricula { get; set; } = string.Empty;

    public int IdCarrera { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public DateTime FechaNacimiento { get; set; }

    public string Curp { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string Calle { get; set; } = string.Empty;

    public int? NumE { get; set; }

    public int? NumI { get; set; }

    public int? CP { get; set; }

    public int IdLocalidad { get; set; }

    public int IdMunicipio { get; set; }

    public int IdEstado { get; set; }

    public int IdGenero { get; set; }
}