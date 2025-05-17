using Empresa_Access_Granted.Data;
using Empresa_Access_Granted.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ClientesController : Controller
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    // Acción para mostrar el formulario de creación
    public IActionResult Create()
    {
        return View();
    }

    // Acción para manejar el envío del formulario
    [HttpPost]
    [ValidateAntiForgeryToken] // Previene ataques CSRF
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (ModelState.IsValid) // Verifica que el modelo sea válido
        {
            try
            {
                // Agrega el cliente a la base de datos
                _context.Add(cliente);
                await _context.SaveChangesAsync();

                // Redirige al usuario al índice de la página principal
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Maneja posibles errores de la base de datos
                ModelState.AddModelError("", $"Error al guardar los datos: {ex.Message}");
            }
        }

        // Si el modelo no es válido o hubo un error, regresa a la vista con los datos ingresados
        return View(cliente);
    }
}
