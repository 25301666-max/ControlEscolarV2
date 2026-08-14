using ControlEscolar.Api.Models;
using ControlEscolarV2.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarV2.Api.Data;

//DBContext permine realizar CRUD si escribir codigo SQL
public class ControlEscolarDbContext : DbContext
{
    //
    public ControlEscolarDbContext(DbContextOptions<ControlEscolarDbContext> options) : base(options)
    { 
    }

//Asignar Modelos
public DbSet<Estado> Estados { get; set; }
public DbSet<Municipio> Municipios { get; set; }
public DbSet<Localidad> Localidades { get; set; }
public DbSet<Genero> Generos { get; set; }
public DbSet<Carrera> Carreras { get; set; }
public DbSet<DatosPersonales> DatosPersonales { get; set; }
public DbSet<TbAlumnos> Alumnos { get; set; }
public DbSet<TipoPersonal> TiposPersonal { get; set; }
public DbSet<Personal> Personal { get; set; }
public DbSet<DatosEscuela> DatosEscuela { get; set; }

    //Asignar campos a propiedades
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurarAlumnosConfigurar(modelBuilder);
    }
}

private static void ConfigurarAlumnos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAlumnos>(entity =>
        {
            entity.ToTable("tb_alumnos");
            //Primary Key
            entity.HasKey(e => e.IdAlumno);

            entity.Property(e => e.Matricula)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(e => e.Estatus)
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Matricula)
                .IsUnique();

            entity.HasIndex(e => e.IdDatosPersonales)
                .IsUnique();
            entity.HasOne(e => e.Carrera)
                .withMany(entity => entity.Alumnos)
                .HasForeKey(entity => e.IdCarrera)




                .HasForeignkey<TbAlumnos>(entity => entity.)
        });