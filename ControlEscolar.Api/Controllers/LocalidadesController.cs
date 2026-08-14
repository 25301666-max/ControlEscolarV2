using ControlEscolar.Api.Data;
using ControlEscolar.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocalidadesController : ControllerBase
{
    private readonly ControlEscolarBDContext _context;

    public LocalidadesController(ControlEscolarBDContext context)
    {
        _context = context;
    }

    // Mostrar localidades
    [HttpGet]
    public async Task<ActionResult<List<LocalidadDto>>> GetLocalidades()
    {
        List<LocalidadDto> localidades = await _context.CLocalidades
            .Select(localidad => new LocalidadDto
            {
                IdLocalidad = localidad.IdLocalidad,
                Nombre = localidad.Nombre,
                IdMunicipio = localidad.IdMunicipio
            })
            .ToListAsync();

        return Ok(localidades);
    }
}