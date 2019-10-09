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
    public class AgendamentosController : Controller
    {
        private readonly Contexto _context;

        public AgendamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Agendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.Disciplina)
                .Include(a => a.Laboratorio)
                .Include(a => a.Professor)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AgendamentoId == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina");
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio");
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NomeUsuario");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendamentoId,DataAgendamento,LaboratorioId,DisciplinaId,UsuarioId,ProfessorId")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendamentoId,DataAgendamento,LaboratorioId,DisciplinaId,UsuarioId,ProfessorId")] Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.AgendamentoId))
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
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.Disciplina)
                .Include(a => a.Laboratorio)
                .Include(a => a.Professor)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AgendamentoId == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);
            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamento.Any(e => e.AgendamentoId == id);
        }
    }
}
