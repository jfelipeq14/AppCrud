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

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Nuevo(Cliente cliente)
		{
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
		}
	}
}
