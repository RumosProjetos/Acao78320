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
    public class LojasController : Controller
    {
        private readonly SqldbProjeto4Context _context;

        public LojasController(SqldbProjeto4Context context)
        {
            _context = context;
        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
              return _context.Lojas != null ? 
                          View(await _context.Lojas.ToListAsync()) :
                          Problem("Entity set 'SqldbProjeto4Context.Lojas'  is null.");
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // GET: Lojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Morada,Ativo,DataCriacao,DataModificacao")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loja);
        }

        // GET: Lojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Morada,Ativo,DataCriacao,DataModificacao")] Loja loja)
        {
            if (id != loja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojaExists(loja.Id))
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
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lojas == null)
            {
                return Problem("Entity set 'SqldbProjeto4Context.Lojas'  is null.");
            }
            var loja = await _context.Lojas.FindAsync(id);
            if (loja != null)
            {
                _context.Lojas.Remove(loja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojaExists(int id)
        {
          return (_context.Lojas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
