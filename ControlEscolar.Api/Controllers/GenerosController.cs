using ControlEscolar.Api.Data;
using ControlEscolar.Api.DTOs;
using ControlEscolar.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenerosController : ControllerBase
{
    private readonly ControlEscolarBDContext _context;

    public GenerosController(ControlEscolarBDContext context)
    {
        _context = context;
    }

    // Mostrar géneros
    [HttpGet]
    public async Task<ActionResult<List<GeneroDto>>> GetGeneros()
    {
        List<GeneroDto> generos = await _context.Generos
            .Select(genero => new GeneroDto
            {
                IdGenero = genero.IdGenero,
                Nombre = genero.Nombre
            })
            .ToListAsync();

        return Ok(generos);
    }

    // Agregar género
    [HttpPost]
    public async Task<ActionResult> AgregarGenero(GeneroDto generoDto)
    {
        Genero genero = new Genero
        {
            IdGenero = generoDto.IdGenero,
            Nombre = generoDto.Nombre
        };

        _context.Generos.Add(genero);
        await _context.SaveChangesAsync();

        return Ok();
    }
}