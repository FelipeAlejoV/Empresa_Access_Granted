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

    // Acci�n para mostrar el formulario de creaci�n
    public IActionResult Create()
    {
        return View();
    }

    // Acci�n para manejar el env�o del formulario
    [HttpPost]
    [ValidateAntiForgeryToken] // Previene ataques CSRF
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (ModelState.IsValid) // Verifica que el modelo sea v�lido
        {
            try
            {
                // Agrega el cliente a la base de datos
                _context.Add(cliente);
                await _context.SaveChangesAsync();

                // Redirige al usuario al �ndice de la p�gina principal
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Maneja posibles errores de la base de datos
                ModelState.AddModelError("", $"Error al guardar los datos: {ex.Message}");
            }
        }

        // Si el modelo no es v�lido o hubo un error, regresa a la vista con los datos ingresados
        return View(cliente);
    }
}
