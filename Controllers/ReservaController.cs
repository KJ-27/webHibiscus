using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webHibiscus.Models;
using webHibiscus.Services;

namespace webHibiscus.Controllers
{
    public class ReservaController : Controller
    {
        private readonly db_a83ea8_hibiscusadminContext _context;
        private readonly IUserService _userService;

        public ReservaController(db_a83ea8_hibiscusadminContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var lista = new List<SelectListItem>();
            ViewBag.UserId = _userService.GetUserId();
            var db_a83ea8_hibiscusadminContext = _context.Reservas.Include(r => r.IdClienteNavigation).Include(r => r.IdServicioNavigation);
            return View(await db_a83ea8_hibiscusadminContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create(int id)
        {
            var UserId = _userService.GetUserId();
            var lista = new List<SelectListItem>();
            var usuarios = _context.Clientes.ToList();
            foreach (var user in usuarios)
            {
                if (UserId == user.IdUsuario)
                {
                    var prueba = new SelectListItem { Value = user.IdUsuario, Text = user.Nombre + " " + user.Apellido1 + " " + user.Apellido2, Selected = true };
                    lista.Add(prueba);
                }
                else{
                    var prueba = new SelectListItem { Value = user.IdUsuario, Text = user.Nombre + " " + user.Apellido1 + " " + user.Apellido2 };
                    lista.Add(prueba);
                }
                
                
            }
            ViewData["IdCliente"] = lista;
            //ViewData["IdCliente"] = new SelectList(_context.Clientes.Where(o => o.IdUsuario == UserId), "IdCliente", "Apellido1");
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "Nombre", id);
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,FechaHora,IdCliente,IdServicio")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1", reserva.IdCliente);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "Nombre", reserva.IdServicio);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1", reserva.IdCliente);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "Nombre", reserva.IdServicio);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,FechaHora,IdCliente,IdServicio")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1", reserva.IdCliente);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "Nombre", reserva.IdServicio);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
