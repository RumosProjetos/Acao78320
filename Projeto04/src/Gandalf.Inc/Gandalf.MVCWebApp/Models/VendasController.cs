using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gandalf.MVCWebApp.Models
{
    public class VendasController : Controller
    {
        private readonly SqldbProjeto4Context _context;

        public VendasController(SqldbProjeto4Context context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var sqldbProjeto4Context = _context.Vendas.Include(v => v.Cliente).Include(v => v.Loja).Include(v => v.PontoDeVenda).Include(v => v.Usuario);
            return View(await sqldbProjeto4Context.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Loja)
                .Include(v => v.PontoDeVenda)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Customers, "CustomerId", "Nome");
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Nome");
            ViewData["PontoDeVendaId"] = new SelectList(_context.PontoDeVendas, "Id", "Localizacao");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroFatura,DataCriacao,DataModificacao,Pago,ClienteId,LojaId,PontoDeVendaId,UsuarioId,Promocao")] Venda venda)
        {
            if (venda.DataCriacao == null)
            {
                venda.DataCriacao = DateTime.Now;
            }
            venda.DataModificacao = DateTime.Now;



            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Customers, "CustomerId", "Nome", venda.ClienteId);
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Nome", venda.LojaId);
            ViewData["PontoDeVendaId"] = new SelectList(_context.PontoDeVendas, "Id", "Localizacao", venda.PontoDeVendaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", venda.UsuarioId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Customers, "CustomerId", "Nome", venda.ClienteId);
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Nome", venda.LojaId);
            ViewData["PontoDeVendaId"] = new SelectList(_context.PontoDeVendas, "Id", "Localizacao", venda.PontoDeVendaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", venda.UsuarioId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroFatura,DataCriacao,DataModificacao,Pago,ClienteId,LojaId,PontoDeVendaId,UsuarioId,Promocao")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (venda.DataCriacao == null)
            {
                venda.DataCriacao = DateTime.Now;
            }
            venda.DataModificacao = DateTime.Now;





            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Customers, "CustomerId", "Nome", venda.ClienteId);
            ViewData["LojaId"] = new SelectList(_context.Lojas, "Id", "Nome", venda.LojaId);
            ViewData["PontoDeVendaId"] = new SelectList(_context.PontoDeVendas, "Id", "Localizacao", venda.PontoDeVendaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", venda.UsuarioId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Loja)
                .Include(v => v.PontoDeVenda)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'SqldbProjeto4Context.Vendas'  is null.");
            }
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
          return (_context.Vendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
