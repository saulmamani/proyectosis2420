using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaMensualidadesCITI.Contexto;
using SistemaMensualidadesCITI.Models;

namespace SistemaMensualidadesCITI.Controllers
{
    public class IngenieroesController : Controller
    {
        private readonly MyContext _context;
        IWebHostEnvironment _webHostEnvironment;

        public IngenieroesController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Ingenieroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingenieros.ToListAsync());
        }

        // GET: Ingenieroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingeniero = await _context.Ingenieros
                .FirstOrDefaultAsync(m => m.id == id);
            if (ingeniero == null)
            {
                return NotFound();
            }

            return View(ingeniero);
        }

        // GET: Ingenieroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingenieroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Rni,Ci,Nombre,Especialidad,FechaRegistro,UrlFoto")] Ingeniero ingeniero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingeniero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingeniero);
        }

        // GET: Ingenieroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingeniero = await _context.Ingenieros.FindAsync(id);
            if (ingeniero == null)
            {
                return NotFound();
            }
            return View(ingeniero);
        }

        // POST: Ingenieroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Rni,Ci,Nombre,Especialidad,FechaRegistro,FotoFile")] Ingeniero ingeniero)
        {
            if (id != ingeniero.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(ingeniero.FotoFile != null) 
                    {
                        await GuardarImagen(ingeniero);
                    }

                    _context.Update(ingeniero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngenieroExists(ingeniero.id))
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
            return View(ingeniero);
        }

        private async Task GuardarImagen(Ingeniero ingeniero)
        {
            //formar el nombre de la foto
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string extension = Path.GetExtension(ingeniero.FotoFile!.FileName);
            string nameFoto = $"{ingeniero.id}_{ingeniero.Rni}{extension}";

            ingeniero.UrlFoto = nameFoto;

            //copiar la foto en el proyecto
            string path = Path.Combine($"{wwwRootPath}/fotos/", nameFoto);
            var fileStream = new FileStream(path, FileMode.Create);
            await ingeniero.FotoFile.CopyToAsync(fileStream);
        }

        // GET: Ingenieroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingeniero = await _context.Ingenieros
                .FirstOrDefaultAsync(m => m.id == id);
            if (ingeniero == null)
            {
                return NotFound();
            }

            return View(ingeniero);
        }

        // POST: Ingenieroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingeniero = await _context.Ingenieros.FindAsync(id);
            if (ingeniero != null)
            {
                _context.Ingenieros.Remove(ingeniero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngenieroExists(int id)
        {
            return _context.Ingenieros.Any(e => e.id == id);
        }
    }
}
