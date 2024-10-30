using Microsoft.AspNetCore.Mvc;
using AppCrud.Data;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppDBContext _context;

        public ClienteController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Cliente> listaClientes = await _context.Clientes.ToListAsync();
            return View(listaClientes);
        }
    }
}
