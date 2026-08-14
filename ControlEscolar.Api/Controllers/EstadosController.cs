using ControlEscolar.Api.Data;
using ControlEscolar.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstadosController : ControllerBase
{
    private readonly ControlEscolarBDContext _context;

    public EstadosController(ControlEscolarBDContext context)
    {
        _context = context;
    }

    // Mostrar estados
    [HttpGet]
    public async Task<ActionResult<List<EstadoDto>>> GetEstados()
    {
        List<EstadoDto> estados = await _context.CEstados
            .Select(estado => new EstadoDto
            {
                IdEstado = estado.IdEstado,
                Nombre = estado.Nombre
            })
            .ToListAsync();

        return Ok(estados);
    }
}