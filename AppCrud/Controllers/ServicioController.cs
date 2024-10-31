using Microsoft.AspNetCore.Mvc;

using AppCrud.Data;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Controllers
{
    public class ServicioController : Controller
    {
        private readonly AppDBContext _context;

        public ServicioController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Servicio> listaServicios = await _context.Servicios.ToListAsync();
            return View(listaServicios);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Servicio servicio = await _context.Servicios.FirstAsync(cl => cl.IdServicio == id);
            return View(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Servicio servicio = await _context.Servicios.FirstAsync(cl => cl.IdServicio == id);
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
