namespace ControlEscolar.Api.Models;

public class Alumno
{
    public string Matricula { get; set; } = string.Empty;

    public int IdCarrera { get; set; }

    public int IdDatosP { get; set; }

    public bool Status { get; set; } = true;

    public Carrera Carrera { get; set; } = null!;

    public DatosPersonales DatosPersonales { get; set; } = null!;
}