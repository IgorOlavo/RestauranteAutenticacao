using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteAutenticacao.Data;
using RestauranteAutenticacao.Models;

namespace RestauranteAutenticacao.Controllers
{
    public class PedidosController : Controller
    {
        private readonly Contexto _context;

        public PedidosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pedido.Include(p => p.bebida).Include(p => p.cliente).Include(p => p.marmitas);
            return View(await contexto.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.bebida)
                .Include(p => p.cliente)
                .Include(p => p.marmitas)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["bebidaid"] = new SelectList(_context.Bebida, "id", "descricao");
            ViewData["clienteid"] = new SelectList(_context.Cliente, "id", "endereco");
            ViewData["marmitaid"] = new SelectList(_context.Marmita, "id", "descricao");
            var status = Enum.GetValues(typeof(Status)).Cast<Status>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });
            ViewBag.bagStatus = status;
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,bebidaid,marmitaid,clienteid,status,tempoPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bebidaid"] = new SelectList(_context.Bebida, "id", "descricao", pedido.bebidaid);
            ViewData["clienteid"] = new SelectList(_context.Cliente, "id", "endereco", pedido.clienteid);
            ViewData["marmitaid"] = new SelectList(_context.Marmita, "id", "descricao", pedido.marmitaid);
            return View(pedido);

        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["bebidaid"] = new SelectList(_context.Bebida, "id", "descricao", pedido.bebidaid);
            ViewData["clienteid"] = new SelectList(_context.Cliente, "id", "endereco", pedido.clienteid);
            ViewData["marmitaid"] = new SelectList(_context.Marmita, "id", "descricao", pedido.marmitaid);
            var status = Enum.GetValues(typeof(Status)).Cast<Status>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });
            ViewBag.bagStatus = status;
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,bebidaid,marmitaid,clienteid,status,tempoPedido")] Pedido pedido)
        {
            if (id != pedido.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.id))
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
            ViewData["bebidaid"] = new SelectList(_context.Bebida, "id", "descricao", pedido.bebidaid);
            ViewData["clienteid"] = new SelectList(_context.Cliente, "id", "endereco", pedido.clienteid);
            ViewData["marmitaid"] = new SelectList(_context.Marmita, "id", "descricao", pedido.marmitaid);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.bebida)
                .Include(p => p.cliente)
                .Include(p => p.marmitas)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedido == null)
            {
                return Problem("Entity set 'Contexto.pedidos'  is null.");
            }
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedido.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.id == id);
        }
    }
}
