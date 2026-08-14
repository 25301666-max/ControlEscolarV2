namespace ControlEscolar.Api.DTOs;

public class AlumnoDto
{
    public string Matricula { get; set; } = string.Empty;

    public int? IdCarrera { get; set; }

    public int? IdDatosP { get; set; }

    public bool? Status { get; set; }
}