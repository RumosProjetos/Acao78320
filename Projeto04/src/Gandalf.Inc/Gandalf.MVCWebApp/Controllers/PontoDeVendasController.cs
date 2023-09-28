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
    public class PontoDeVendasController : Controller
    {
        private readonly SqldbProjeto4Context _context;

        public PontoDeVendasController(SqldbProjeto4Context context)
        {
            _context = context;
        }

        // GET: PontoDeVendas
        public async Task<IActionResult> Index()
        {
            var sqldbProjeto4Context = _context.PontoDeVendas.Include(p => p.Loja);
            return View(await sqldbProjeto4Context.ToListAsync());
        }

        // GET: PontoDeVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PontoDeVendas == null)
            {
                return NotFound();
            }

            var pontoDeVenda = await _context.PontoDeVendas
                .Include(p => p.Loja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoDeVenda == null)
            {
                return NotFound();
            }

            return View(pontoDeVenda);
        }

        // GET: PontoDeVendas/Create
        public IActionResult Create()
        {
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Id");
            return View();
        }

        // POST: PontoDeVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Localizacao,LojaId")] PontoDeVenda pontoDeVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoDeVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Id", pontoDeVenda.LojaId);
            return View(pontoDeVenda);
        }

        // GET: PontoDeVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PontoDeVendas == null)
            {
                return NotFound();
            }

            var pontoDeVenda = await _context.PontoDeVendas.FindAsync(id);
            if (pontoDeVenda == null)
            {
                return NotFound();
            }
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Id", pontoDeVenda.LojaId);
            return View(pontoDeVenda);
        }

        // POST: PontoDeVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Localizacao,LojaId")] PontoDeVenda pontoDeVenda)
        {
            if (id != pontoDeVenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoDeVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoDeVendaExists(pontoDeVenda.Id))
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
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Id", pontoDeVenda.LojaId);
            return View(pontoDeVenda);
        }

        // GET: PontoDeVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PontoDeVendas == null)
            {
                return NotFound();
            }

            var pontoDeVenda = await _context.PontoDeVendas
                .Include(p => p.Loja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoDeVenda == null)
            {
                return NotFound();
            }

            return View(pontoDeVenda);
        }

        // POST: PontoDeVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PontoDeVendas == null)
            {
                return Problem("Entity set 'SqldbProjeto4Context.PontoDeVendas'  is null.");
            }
            var pontoDeVenda = await _context.PontoDeVendas.FindAsync(id);
            if (pontoDeVenda != null)
            {
                _context.PontoDeVendas.Remove(pontoDeVenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoDeVendaExists(int id)
        {
          return (_context.PontoDeVendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
