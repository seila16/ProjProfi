using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoProjeto.Models;

namespace AgendamentoProjeto.Controllers
{
    public class AvisosController : Controller
    {
        private readonly Contexto _context;

        public AvisosController(Contexto context)
        {
            _context = context;
        }

        // GET: Avisos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Aviso.Include(a => a.Agendamento);
            return View(await contexto.ToListAsync());
        }

        // GET: Avisos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Aviso
                .Include(a => a.Agendamento)
                .FirstOrDefaultAsync(m => m.AvisosId == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // GET: Avisos/Create
        public IActionResult Create()
        {
            ViewData["AvisosId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId");
            return View();
        }

        // POST: Avisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvisosId,AgendamentoId,Mensagem")] Aviso aviso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aviso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AvisosId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId", aviso.AvisosId);
            return View(aviso);
        }

        // GET: Avisos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Aviso.FindAsync(id);
            if (aviso == null)
            {
                return NotFound();
            }
            ViewData["AvisosId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId", aviso.AvisosId);
            return View(aviso);
        }

        // POST: Avisos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvisosId,AgendamentoId,Mensagem")] Aviso aviso)
        {
            if (id != aviso.AvisosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aviso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvisoExists(aviso.AvisosId))
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
            ViewData["AvisosId"] = new SelectList(_context.Agendamento, "AgendamentoId", "AgendamentoId", aviso.AvisosId);
            return View(aviso);
        }

        // GET: Avisos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Aviso
                .Include(a => a.Agendamento)
                .FirstOrDefaultAsync(m => m.AvisosId == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // POST: Avisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aviso = await _context.Aviso.FindAsync(id);
            _context.Aviso.Remove(aviso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvisoExists(int id)
        {
            return _context.Aviso.Any(e => e.AvisosId == id);
        }
    }
}
