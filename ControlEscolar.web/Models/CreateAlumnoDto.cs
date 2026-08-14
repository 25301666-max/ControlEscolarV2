namespace ControlEscolar.web.Models
{
    public class CreateAlumnoDto
    {
        public string Matricula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string FechaNacimiento { get; set; } = string.Empty;
        public string Curp { get; set; } = string.Empty;
        public string IdGenero { get; set; } = string.Empty;
        public string IdCarrera { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int Cuatrimestre { get; set; } 
        public string Calle { get; set; } = string.Empty;
        public string NumeroExterior { get; set; } = string.Empty;
        public string NumeroInterior { get; set; } = string.Empty;
        public string IdEstado { get; set; } = string.Empty;
        public string IdMunicipio { get; set; } = string.Empty;
        public string IdLocalidad { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
    }
}
