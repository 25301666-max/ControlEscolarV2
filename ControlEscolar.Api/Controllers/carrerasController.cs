using ControlEscolar.Api.Data;
using ControlEscolar.Api.DTOs;
using ControlEscolar.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Api.Controllers;

[ApiController] // Aquí nos indica que se trata de un controlador
[Route("api/[controller]")]
public class CarrerasController : ControllerBase
{
    private readonly ControlEscolarBDContext _context;

    public CarrerasController(ControlEscolarBDContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarreraDto>>> GetCarreras()
    {
        List<CarreraDto> carreras = await _context.CCarreras
            .Select(Carrera => new CarreraDto
            {
                IdCarrera = Carrera.IdCarrera,
                NombreCarrera = Carrera.NombreCarrera
            })
            .ToListAsync();

        return Ok(carreras);
    }
}