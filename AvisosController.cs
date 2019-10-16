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
        public async Task<IActionResult> Create([Bind("AvisosId,Mensagem")] Aviso aviso, string agendamento)
        {
            int idInt = Convert.ToInt32(agendamento);
          
            
            if (aviso != null)
            {
                _context.Add(aviso);             
                await _context.SaveChangesAsync();

                
                return RedirectToAction("Index", "Avisos");
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
        public async Task<IActionResult> Edit(int id, [Bind("AvisosId,Mensagem")] Aviso aviso)
        {
            if (id != aviso.AvisosId)
            {
                return NotFound();
            }

            var temAviso = _context.Aviso.Where(x => x.Mensagem == aviso.Mensagem).ToList();
            if (temAviso.Count > 0)
            {
                ViewBag.TemAviso = true;
                return View();
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
            return View(aviso);
        }


        // POST: Cargos/Delete/5
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
