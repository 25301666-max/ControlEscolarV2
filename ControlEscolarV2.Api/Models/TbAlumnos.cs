namespace ControlEscolarV2.Api.Models
{
    public class TbAlumnos
    {

        public int Id { get; set; }

        public string Matricula { get; set; } = null;

        public string Nombre { get; set; } = null;

        public string Apellido { get; set; } = null;

        public int CarreraId { get; set; }

        public int Cuatrimestre { get; set; }

        public bool Estatus { get; set; }

        public virtual Carrera Carrera { get; set; } = null;

    }
}
