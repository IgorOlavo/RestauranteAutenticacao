using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteAutenticacao.Data;
using RestauranteAutenticacao.Models;

namespace RestauranteAutenticacao.Controllers
{
    public class BebidasController : Controller
    {
        private readonly Contexto _context;

        public BebidasController(Contexto context)
        {
            _context = context;
        }

        // GET: Bebidas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Bebida.ToListAsync());
        }

        // GET: Bebidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebida
                .FirstOrDefaultAsync(m => m.id == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // GET: Bebidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bebidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,preco")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bebida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bebida);
        }

        // GET: Bebidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebida.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }
            return View(bebida);
        }

        // POST: Bebidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,preco")] Bebida bebida)
        {
            if (id != bebida.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bebida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebidaExists(bebida.id))
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
            return View(bebida);
        }

        // GET: Bebidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bebida == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebida
                .FirstOrDefaultAsync(m => m.id == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // POST: Bebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bebida == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bebida'  is null.");
            }
            var bebida = await _context.Bebida.FindAsync(id);
            if (bebida != null)
            {
                _context.Bebida.Remove(bebida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BebidaExists(int id)
        {
          return _context.Bebida.Any(e => e.id == id);
        }
    }
}
