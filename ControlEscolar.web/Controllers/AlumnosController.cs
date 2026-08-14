using ControlEscolar.web.Models;
using ControlEscolar.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolar.web.Controllers;

public class AlumnosController : Controller
{
    private readonly string _baseUrl = "https://localhost:7016/";

    // Mostrar alumnos
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<AlumnoDto> alumnos = new List<AlumnoDto>();

        try
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);

            var result = await client.GetFromJsonAsync<List<AlumnoDto>>("api/alumnos");
            if (result != null)
            {
                alumnos = result;
            }
        }
        catch (Exception ex)
        {
            // Si la API truena o da error 500, la Web no se cae y muestra la vista vacía
            ViewBag.Error = "No se pudo conectar a la API o hubo un error en la base de datos: " + ex.Message;
        }

        return View(alumnos);
    }

    // Mostrar formulario
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        try
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);

            ViewData["Carreras"] = await client.GetFromJsonAsync<List<CarreraDto>>("api/carreras");
        }
        catch
        {
            ViewData["Carreras"] = new List<CarreraDto>();
        }

        return View();
    }
}