using ControlEscolar.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Api.Data;

public class ControlEscolarBDContext : DbContext
{
    public ControlEscolarBDContext(
        DbContextOptions<ControlEscolarBDContext> options
    ) : base(options)
    {
    }

    // Asignar modelos
    public DbSet<Alumno> CAlumnos { get; set; }
    public DbSet<Carrera> CCarreras { get; set; }
    public DbSet<DatosEscuela> CDatosEscuela { get; set; }
    public DbSet<DatosPersonales> CDatosPersonales { get; set; }
    public DbSet<Estado> CEstados { get; set; }
    public DbSet<Localidad> CLocalidades { get; set; }
    public DbSet<Municipio> CMunicipios { get; set; }
    public DbSet<Personal> CPersonal { get; set; }
    public DbSet<TipoPersonal> CTipoPersonal { get; set; }
    public DbSet<Genero> Generos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurarCAlumnos(modelBuilder);
        ConfigurarCCarreras(modelBuilder);
        ConfigurarCDatosEscuela(modelBuilder);
        ConfigurarCDatosPersonales(modelBuilder);
        ConfigurarCEstados(modelBuilder);
        ConfigurarCLocalidad(modelBuilder);
        ConfigurarCMunicipio(modelBuilder);
        ConfigurarCPersonal(modelBuilder);
        ConfigurarCTipoPersonal(modelBuilder);
        ConfigurarGenero(modelBuilder);
    }

    private static void ConfigurarCAlumnos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.ToTable("tb_alumnos");

            entity.HasKey(e => e.Matricula);

            entity.Property(e => e.Matricula)
                .HasColumnName("Matricula")
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(e => e.IdDatosP)
                .HasColumnName("IdDatosPersonales");

            entity.Property(e => e.IdCarrera)
                .HasColumnName("IdCarrera");

            // Solo ignoramos propiedades que REALMENTE existen en la clase C# Alumno.cs
            entity.Ignore(e => e.Status);

            entity.HasIndex(e => e.IdDatosP)
                .IsUnique();

            entity.HasOne(e => e.Carrera)
                .WithMany(e => e.Alumnos)
                .HasForeignKey(e => e.IdCarrera)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.DatosPersonales)
                .WithOne(e => e.Alumno)
                .HasForeignKey<Alumno>(e => e.IdDatosP)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigurarCCarreras(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.ToTable("tb_carreras");

            entity.HasKey(e => e.IdCarrera);

            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .IsRequired();
        });
    }

    private static void ConfigurarCDatosEscuela(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosEscuela>(entity =>
        {
            entity.ToTable("tb_datos_escuela");

            entity.HasKey(e => e.CCT);

            entity.Property(e => e.CCT)
                .HasMaxLength(15)
                .IsRequired();

            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            entity.HasOne(e => e.Localidad)
                .WithMany(e => e.Escuelas)
                .HasForeignKey(e => e.IdLocalidad)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Municipio)
                .WithMany(e => e.Escuelas)
                .HasForeignKey(e => e.IdMunicipio)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Estado)
                .WithMany(e => e.Escuelas)
                .HasForeignKey(e => e.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigurarCDatosPersonales(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosPersonales>(entity =>
        {
            entity.ToTable("tb_datos_personales");

            entity.HasKey(e => e.IdDatosP);

            entity.Property(e => e.IdDatosP)
                .HasColumnName("IdDatosPersonales");

            entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Curp)
                .HasColumnName("CURP")
                .HasMaxLength(18)
                .IsRequired();

            entity.Property(e => e.NumI)
                .HasColumnName("NumeroInterior");

            entity.Property(e => e.CP)
                .HasColumnName("CodigoPostal");

            entity.Property(e => e.NumE)
                .HasColumnName("NumeroExterior");

            entity.Property(e => e.IdLocalidad)
                .HasColumnName("IdLocalidad");

            entity.Property(e => e.IdGenero)
                .HasColumnName("IdGenero");

            entity.HasOne(e => e.Localidad)
                .WithMany(e => e.Personas)
                .HasForeignKey(e => e.IdLocalidad)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Genero)
                .WithMany(e => e.Personas)
                .HasForeignKey(e => e.IdGenero)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigurarCEstados(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.ToTable("tb_estados");

            entity.HasKey(e => e.IdEstado);

            entity.Property(e => e.IdEstado)
                .HasColumnName("IdEstado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();
        });
    }

    private static void ConfigurarCMunicipio(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.ToTable("tb_municipios");

            entity.HasKey(e => e.IdMunicipio);

            entity.Property(e => e.IdMunicipio)
                .HasColumnName("IdMunicipio");

            entity.Property(e => e.IdEstado)
                .HasColumnName("IdEstado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            // Mapeo explícito de la relación con Estado
            entity.HasOne(e => e.Estado)
                .WithMany(e => e.Municipios)
                .HasForeignKey(e => e.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigurarCLocalidad(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.ToTable("tb_localidades");

            entity.HasKey(e => e.IdLocalidad);

            entity.Property(e => e.IdLocalidad)
                .HasColumnName("IdLocalidad");

            entity.Property(e => e.IdMunicipio)
                .HasColumnName("IdMunicipio");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            // Mapeo explícito de la relación con Municipio
            entity.HasOne(e => e.Municipio)
                .WithMany(e => e.Localidades)
                .HasForeignKey(e => e.IdMunicipio)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigurarCPersonal(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personal>(entity =>
        {
            entity.ToTable("tb_personal");

            entity.HasKey(e => e.IdPersonal);

            entity.Property(e => e.ClaveEmp)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(e => e.Status)
                .IsRequired();

            entity.HasOne(e => e.DatosPersonales)
                .WithMany()
                .HasForeignKey(e => e.IdDatosP)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.TipoPersonal)
                .WithMany(e => e.Personales)
                .HasForeignKey(e => e.IdTipo)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigurarCTipoPersonal(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoPersonal>(entity =>
        {
            entity.ToTable("tb_tipos_personal");

            entity.HasKey(e => e.IdTipo);

            entity.Property(e => e.Personal)
                .HasMaxLength(100)
                .IsRequired();
        });
    }

    private static void ConfigurarGenero(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.ToTable("tb_generos");

            entity.HasKey(e => e.IdGenero);

            entity.Property(e => e.Nombre)
                .HasColumnName("Genero")
                .HasMaxLength(30)
                .IsRequired();
        });
    }
}