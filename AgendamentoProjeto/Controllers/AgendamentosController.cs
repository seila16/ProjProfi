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
        public async Task<IActionResult> Index(string error)
        {
            if (error !=null)
            {
                ViewBag.ErrorDatabase = error;
            }
            List<string> listaDeAvisos = new List<string>();
            var contexto = _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario);
            var avisos = _context.Aviso.Select(x => x);
            ViewBag.Avisos = avisos;
            return View(await contexto.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Procurar, bool gambiarra)
        {
            if (!String.IsNullOrEmpty(Procurar))
            {
                var avisos = _context.Aviso.Select(x => x);
                ViewBag.Avisos = avisos;
                DateTime DataFinal = Convert.ToDateTime(Procurar);
                var contexto = _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario);
                return View(await  contexto.Where(x => x.DataAgendamento.ToShortDateString().Contains(DataFinal.ToShortDateString())).ToListAsync());

            }
            var avisos1 = _context.Aviso.Select(x => x);
            ViewBag.Avisos = avisos1;
            return View(await _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario).ToListAsync());
        }


        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina");
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio");
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NomeUsuario");
            var x = _context.Status.Where(s => s.NomeStatus != "Bloqueado").ToList();
            ViewData["StatusId"] = new SelectList(x);
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendamentoId,DataAgendamento,LaboratorioId,DisciplinaId,UsuarioId,ProfessorId,StatusId")] Agendamento agendamento)
        {
            var temNaBaseMesmoHorario = _context.Agendamento.Where(a => a.DataAgendamento == agendamento.DataAgendamento).ToList();
            if (temNaBaseMesmoHorario.Any() )
            {
                ViewBag.error = "Já existe um agendamento para a data e horário escolhida.";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                return View();
            }
            if (agendamento.DataAgendamento < DateTime.Now)
            {

                ViewBag.error = "Data ou horário anterior a data atual, favor seleciona outra data ou horário.";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                return View();
            }
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
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");

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
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");

            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendamentoId,DataAgendamento,LaboratorioId,DisciplinaId,UsuarioId,ProfessorId,StatusId")] Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoId)
            {
                return NotFound();
            }

            var temNaBaseMesmoHorario = _context.Agendamento.Where(a => a.DataAgendamento == agendamento.DataAgendamento).ToList();
            if (temNaBaseMesmoHorario.Any())
            {
                ViewBag.error = "Já existe um agendamento para a data e horário escolhida.";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                return View();
            }
            if (agendamento.DataAgendamento < DateTime.Now)
            {

                ViewBag.error = "Data ou horário anterior a data atual, favor seleciona outra data ou horário.";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                return View();
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
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");

            return View(agendamento);
        }

    
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
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
