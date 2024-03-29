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
    public class ProfessorsController : Controller
    {
        private readonly Contexto _context;

        public ProfessorsController(Contexto context)
        {
            _context = context;
        }

        // GET: Professors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professor.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(string Procurar, string Tipo)
        {
            if (!String.IsNullOrEmpty(Procurar) && !String.IsNullOrEmpty(Tipo))
            {

                if (Tipo == "nome")
                {
                    return View(await _context.Professor.Where(x => x.NomeProfessor.ToUpper().Contains(Procurar.ToUpper())).ToListAsync());

                }
                else
                {
                    return View(await _context.Professor.Where(x => x.EmailProfessor.ToUpper().Contains(Procurar.ToUpper())).ToListAsync());

                }
            }

            return View(await _context.Professor.ToListAsync());
        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorId,NomeProfessor,EmailProfessor")] Professor professor)
        {
            var temProfessorNaBase = _context.Professor.Where(p => p.NomeProfessor == professor.NomeProfessor || p.EmailProfessor == professor.EmailProfessor).ToList();
            if (ModelState.IsValid && temProfessorNaBase.Count() == 0)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.TemProfessor = "Já existe um professor com esse nome ou e-mail, favor escolha outro nome ou e-mail";
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorId,NomeProfessor,EmailProfessor")] Professor professor)
        {
            if (id != professor.ProfessorId)
            {
                return NotFound();
            }
            var temProfessorNaBase = _context.Professor.Where(p => (p.NomeProfessor == professor.NomeProfessor || p.EmailProfessor == professor.EmailProfessor) && p.ProfessorId != professor.ProfessorId).ToList();

            if (ModelState.IsValid && temProfessorNaBase.Count() == 0)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ProfessorId))
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
                ViewBag.TemProfessor = "Já existe um professor com esse nome ou e-mail, favor escolha outro nome ou e-mail";
            }
            return View(professor);
        }

        

        // POST: Professors/Delete/5
        [HttpPost]
        
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.ProfessorId == id);
        }
    }
}
