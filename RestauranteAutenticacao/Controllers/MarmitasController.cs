using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteAutenticacao.Models;

namespace RestauranteAutenticacao.Controllers
{
    public class MarmitasController : Controller
    {
        private readonly Contexto _context;

        public MarmitasController(Contexto context)
        {
            _context = context;
        }

        // GET: Marmitas
        public async Task<IActionResult> Index()
        {
            var tamanho = Enum.GetValues(typeof(Tamanho)).Cast<Tamanho>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });
            ViewBag.bagTamanho = tamanho;

            return View(await _context.Marmita.ToListAsync());
        }

        // GET: Marmitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marmita == null)
            {
                return NotFound();
            }

            var marmita = await _context.Marmita
                .FirstOrDefaultAsync(m => m.id == id);
            if (marmita == null)
            {
                return NotFound();
            }
                        var tamanho = Enum.GetValues(typeof(Tamanho)).Cast<Tamanho>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });
            ViewBag.bagTamanho = tamanho;

            return View(marmita);
        }

        // GET: Marmitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marmitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,tamanho,preco")] Marmita marmita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marmita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marmita);
        }

        // GET: Marmitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marmita == null)
            {
                return NotFound();
            }

            var tamanho = Enum.GetValues(typeof(Tamanho)).Cast<Tamanho>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });
            ViewBag.bagTamanho = tamanho;

            var marmita = await _context.Marmita.FindAsync(id);
            if (marmita == null)
            {
                return NotFound();
            }
            return View(marmita);
        }

        // POST: Marmitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,tamanho,preco")] Marmita marmita)
        {
            if (id != marmita.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marmita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarmitaExists(marmita.id))
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
            return View(marmita);
        }

        // GET: Marmitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marmita == null)
            {
                return NotFound();
            }

            var marmita = await _context.Marmita
                .FirstOrDefaultAsync(m => m.id == id);
            if (marmita == null)
            {
                return NotFound();
            }

            return View(marmita);
        }

        // POST: Marmitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marmita == null)
            {
                return Problem("Entity set 'Contexto.Marmita'  is null.");
            }
            var marmita = await _context.Marmita.FindAsync(id);
            if (marmita != null)
            {
                _context.Marmita.Remove(marmita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarmitaExists(int id)
        {
          return _context.Marmita.Any(e => e.id == id);
        }
    }
}
