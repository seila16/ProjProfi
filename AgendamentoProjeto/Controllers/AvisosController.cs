using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoProjeto.Models;
using Microsoft.AspNetCore.Http;

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
            var agendamentos = _context.Agendamento.Select(a => a).Include(a=>a.Professor).Include(a=>a.Usuario).ToList();
            ViewBag.Agendamentos = agendamentos;
            return View(await _context.Aviso.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Procurar)
        {
            if (!String.IsNullOrEmpty(Procurar))
            {

                return View(await _context.Aviso.Where(x => x.Mensagem.ToUpper().Contains(Procurar.ToUpper())).ToListAsync());
            }

            return View(await _context.Aviso.ToListAsync());
        }

        // GET: Avisos/Create
        public IActionResult Create(int AgendamentoId)
        {
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

                if (HttpContext.Session.GetString("Cargo") == "Coordenador")
                {
                    return RedirectToAction("MeusAgendamentos", "Agendamentos");
                }
                else
                {
                    return RedirectToAction("Index", "Agendamentos");

                }
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
            ViewBag.agendamentoId = aviso.AgendamentoId;
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

       
        // POST: Avisos/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
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
