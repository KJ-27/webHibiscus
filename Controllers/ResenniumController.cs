using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webHibiscus.Models;

namespace webHibiscus.Controllers
{
    public class ResenniumController : Controller
    {
        private readonly db_a83ea8_hibiscusadminContext _context;

        public ResenniumController(db_a83ea8_hibiscusadminContext context)
        {
            _context = context;
        }

        // GET: Resennium
        public async Task<IActionResult> Index()
        {
            var db_a83ea8_hibiscusadminContext = _context.Resennia.Include(r => r.IdClienteNavigation);
            return View(await db_a83ea8_hibiscusadminContext.ToListAsync());
        }

        // GET: Resennium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resennium = await _context.Resennia
                .Include(r => r.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdResenia == id);
            if (resennium == null)
            {
                return NotFound();
            }

            return View(resennium);
        }

        // GET: Resennium/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1");
            return View();
        }

        // POST: Resennium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResenia,Cotenido,IdCliente,Puntuacion,Fecha")] Resennium resennium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resennium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1", resennium.IdCliente);
            return View(resennium);
        }

        // GET: Resennium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resennium = await _context.Resennia.FindAsync(id);
            if (resennium == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1", resennium.IdCliente);
            return View(resennium);
        }

        // POST: Resennium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResenia,Cotenido,IdCliente,Puntuacion,Fecha")] Resennium resennium)
        {
            if (id != resennium.IdResenia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resennium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResenniumExists(resennium.IdResenia))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Apellido1", resennium.IdCliente);
            return View(resennium);
        }

        // GET: Resennium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resennium = await _context.Resennia
                .Include(r => r.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdResenia == id);
            if (resennium == null)
            {
                return NotFound();
            }

            return View(resennium);
        }

        // POST: Resennium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resennium = await _context.Resennia.FindAsync(id);
            _context.Resennia.Remove(resennium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResenniumExists(int id)
        {
            return _context.Resennia.Any(e => e.IdResenia == id);
        }
    }
}
