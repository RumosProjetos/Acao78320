using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gandalf.MVCWebApp.Models;

namespace Gandalf.MVCWebApp.Controllers
{
    public class DetalhesVendasController : Controller
    {
        private readonly SqldbProjeto4Context _context;

        public DetalhesVendasController(SqldbProjeto4Context context)
        {
            _context = context;
        }

        // GET: DetalhesVendas
        public async Task<IActionResult> Index()
        {
            var sqldbProjeto4Context = _context.DetalhesVendas.Include(d => d.Produto).Include(d => d.Venda);
            return View(await sqldbProjeto4Context.ToListAsync());
        }

        // GET: DetalhesVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalhesVendas == null)
            {
                return NotFound();
            }

            var detalhesVenda = await _context.DetalhesVendas
                .Include(d => d.Produto)
                .Include(d => d.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalhesVenda == null)
            {
                return NotFound();
            }

            return View(detalhesVenda);
        }

        // GET: DetalhesVendas/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtoes, "Id", "Id");
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id");
            return View();
        }

        // POST: DetalhesVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sequencial,Quantidade,PrecoUnitario,TotalLinha,DataCriacao,ProdutoId,VendaId")] DetalhesVenda detalhesVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalhesVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtoes, "Id", "Id", detalhesVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id", detalhesVenda.VendaId);
            return View(detalhesVenda);
        }

        // GET: DetalhesVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalhesVendas == null)
            {
                return NotFound();
            }

            var detalhesVenda = await _context.DetalhesVendas.FindAsync(id);
            if (detalhesVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtoes, "Id", "Id", detalhesVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id", detalhesVenda.VendaId);
            return View(detalhesVenda);
        }

        // POST: DetalhesVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sequencial,Quantidade,PrecoUnitario,TotalLinha,DataCriacao,ProdutoId,VendaId")] DetalhesVenda detalhesVenda)
        {
            if (id != detalhesVenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalhesVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalhesVendaExists(detalhesVenda.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtoes, "Id", "Id", detalhesVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "Id", "Id", detalhesVenda.VendaId);
            return View(detalhesVenda);
        }

        // GET: DetalhesVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalhesVendas == null)
            {
                return NotFound();
            }

            var detalhesVenda = await _context.DetalhesVendas
                .Include(d => d.Produto)
                .Include(d => d.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalhesVenda == null)
            {
                return NotFound();
            }

            return View(detalhesVenda);
        }

        // POST: DetalhesVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalhesVendas == null)
            {
                return Problem("Entity set 'SqldbProjeto4Context.DetalhesVendas'  is null.");
            }
            var detalhesVenda = await _context.DetalhesVendas.FindAsync(id);
            if (detalhesVenda != null)
            {
                _context.DetalhesVendas.Remove(detalhesVenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalhesVendaExists(int id)
        {
          return (_context.DetalhesVendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
