using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlEscolar.Api.Data;
using ControlEscolar.Api.Models;

namespace ControlEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly ControlEscolarBDContext _context;

    public AlumnosController(ControlEscolarBDContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlumnos()
    {
        var alumnos = await _context.CAlumnos
            .Include(a => a.DatosPersonales)
            .Include(a => a.Carrera)
            .ToListAsync();

        return Ok(alumnos);
    }
}