﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaMensualidadesCITI.Contexto;
using SistemaMensualidadesCITI.Models;

namespace SistemaMensualidadesCITI.Controllers
{
    public class PagoesController : Controller
    {
        private readonly MyContext _context;

        public PagoesController(MyContext context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Pagos.Include(p => p.Ingeniero).Include(p => p.Usuario);
            return View(await myContext.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Ingeniero)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagoes/Create
        public IActionResult Create()
        {
            ViewData["IngenieroId"] = new SelectList(_context.Ingenieros, "id", "Info");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NroRecibo,Fecha,Mes,Anio,Total,UsuarioId,IngenieroId")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                pago.Fecha = DateOnly.FromDateTime(DateTime.Now);
                pago.NroRecibo = GetNumero();

                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngenieroId"] = new SelectList(_context.Ingenieros, "id", "Ci", pago.IngenieroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", pago.UsuarioId);
            return View(pago);
        }

        private int GetNumero()
        {
            if (_context.Pagos.ToList().Count > 0)
                return _context.Pagos.Max(i => i.NroRecibo) + 1;
            return 1;
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Ingeniero)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
