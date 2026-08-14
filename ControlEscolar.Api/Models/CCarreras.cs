namespace ControlEscolar.Api.Models;

public class Carrera
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = string.Empty;

    public bool? Estatus { get; set; }

    public ICollection<Alumno> Alumnos { get; set; }
        = new List<Alumno>();
}