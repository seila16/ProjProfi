﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoProjeto.Models;

namespace AgendamentoProjeto.Controllers
{
    public class DisciplinasController : Controller
    {
        private readonly Contexto _context;

        public DisciplinasController(Contexto context)
        {
            _context = context;
        }

        // GET: Disciplinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disciplina.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Procurar)
        {
            if (!String.IsNullOrEmpty(Procurar))
            {

                return View(await _context.Disciplina.Where(x => x.NomeDisciplina.ToUpper().Contains(Procurar.ToUpper())).ToListAsync());
            }

            return View(await _context.Disciplina.ToListAsync());
        }


        // GET: Disciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplinaId,NomeDisciplina")] Disciplina disciplina)
        {
            var temDisciplina = _context.Disciplina.Where(x => x.NomeDisciplina == disciplina.NomeDisciplina).ToList();
            if (temDisciplina.Count > 0)
            {
                ViewBag.TemDisciplina = true;
                return View();
            }
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisciplinaId,NomeDisciplina")] Disciplina disciplina)
        {
            if (id != disciplina.DisciplinaId)
            {
                return NotFound();
            }
            var temDisciplina = _context.Disciplina.Where(x => x.NomeDisciplina == disciplina.NomeDisciplina && x.DisciplinaId != disciplina.DisciplinaId).ToList();
            if (ModelState.IsValid && temDisciplina.Count == 0)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.DisciplinaId))
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
            else
            {
                ViewBag.TemDisciplina = true;
                return View(disciplina);
            }
            
        }

        

        // POST: Disciplinas/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            _context.Disciplina.Remove(disciplina);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplina.Any(e => e.DisciplinaId == id);
        }
    }
}
