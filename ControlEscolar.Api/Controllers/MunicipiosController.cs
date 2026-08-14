using ControlEscolar.Api.Data;
using ControlEscolar.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MunicipiosController : ControllerBase
{
    private readonly ControlEscolarBDContext _context;

    public MunicipiosController(ControlEscolarBDContext context)
    {
        _context = context;
    }

    // Mostrar municipios
    [HttpGet]
    public async Task<ActionResult<List<MunicipioDto>>> GetMunicipios()
    {
        List<MunicipioDto> municipios = await _context.CMunicipios
            .Select(municipio => new MunicipioDto
            {
                IdMunicipio = municipio.IdMunicipio,
                Nombre = municipio.Nombre,
                IdEstado = municipio.IdEstado
            })
            .ToListAsync();

        return Ok(municipios);
    }
}