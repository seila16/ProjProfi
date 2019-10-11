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
            return View(await _context.Aviso.ToListAsync());
        }

   
        // GET: Avisos/Create
        public IActionResult Create(int AgendamentoId)
        {
            var temNaBase = _context.Aviso.Where(a => a.AgendamentoId == AgendamentoId).ToList();
            if (temNaBase.Any())
            {
                return RedirectToAction("Index", "Agendamentos", new { error = "Já existe um aviso anexado ao agendamento em questão, favor editar o aviso já existente" });
            }
            ViewData["agendamentoId"] = AgendamentoId;
            return View();
        }

        // POST: Avisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("AgendamentoId,AvisosId,Mensagem")] Aviso aviso)
        {


            //var ids = _context.Aviso.Count() + 1;
            //aviso.AvisosId = ids;
            if (aviso != null)
            {
                _context.Add(aviso);             
                await _context.SaveChangesAsync();

                
                return RedirectToAction("Index", "Agendamentos");
            }
           
           // ViewData["agendamentoId"] = aviso.AgendamentoId;
            return View("Create", aviso);
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
