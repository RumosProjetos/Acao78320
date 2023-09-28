using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gandalf.MVCWebApp.Models;
using Gandalf.MVCWebApp.Dto;

namespace Gandalf.MVCWebApp.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly SqldbProjeto4Context _context;

        public ProdutosController(SqldbProjeto4Context context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            var sqldbProjeto4Context = _context.Produtoes.Include(p => p.Categoria);
            return View(await sqldbProjeto4Context.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtoes == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtoes
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CodigoBarras,UnidadeMedida,QuantidadePorUnidade,PrecoUnitario,Discontinuado,DataCriacao,DataModificacao,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if(produto.DataCriacao == null)
                {
                    produto.DataCriacao = DateTime.Now;
                }
                produto.DataModificacao = DateTime.Now;

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtoes == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtoes.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }


            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CodigoBarras,UnidadeMedida,QuantidadePorUnidade,PrecoUnitario,Discontinuado,DataCriacao,DataModificacao,CategoriaId")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (produto.DataCriacao == null)
            {
                produto.DataCriacao = DateTime.Now;
            }
            produto.DataModificacao = DateTime.Now;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtoes == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtoes
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtoes == null)
            {
                return Problem("Entity set 'SqldbProjeto4Context.Produtoes'  is null.");
            }
            var produto = await _context.Produtoes.FindAsync(id);
            if (produto != null)
            {
                _context.Produtoes.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return (_context.Produtoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}          