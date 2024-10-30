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

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			Cliente cliente = await _context.Clientes.FirstAsync(cl => cl.Id == id);
            return View(cliente);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(Cliente cliente)
		{
			_context.Clientes.Update(cliente);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Lista));
		}

		[HttpGet]
		public async Task<IActionResult> Eliminar(int id)
		{
			Cliente cliente = await _context.Clientes.FirstAsync(cl => cl.Id == id);
			_context.Clientes.Remove(cliente);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Lista));
		}
	}
}
