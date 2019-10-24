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
    public class LaboratoriosController : Controller
    {
        private readonly Contexto _context;

        public LaboratoriosController(Contexto context)
        {
            _context = context;
        }

        // GET: Laboratorios
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Laboratorio.Include(l => l.Status);


            ViewBag.statusBd = _context.Status.Select(s => s.NomeStatus);
            ViewBag.quantidades = _context.Laboratorio.Select(l => l.QuantidadePcs);
            return View(await contexto.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Procurar)
        {
            if (!String.IsNullOrEmpty(Procurar))
            {
                ViewBag.statusBd = _context.Status.Select(s => s.NomeStatus);
                ViewBag.quantidades = _context.Laboratorio.Select(l => l.QuantidadePcs);
                return View(await _context.Laboratorio.Where(x => x.NomeLaboratorio.ToUpper().Contains(Procurar.ToUpper())).ToListAsync());
            }
            ViewBag.statusBd = _context.Status.Select(s => s.NomeStatus);
            ViewBag.quantidades = _context.Laboratorio.Select(l => l.QuantidadePcs);
            return View(await _context.Laboratorio.ToListAsync());
        }


        // GET: Laboratorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LaboratorioId == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        public async Task<IActionResult> Manutencao(int id)
        {
            var lab = _context.Laboratorio.Where(l => l.LaboratorioId == id).FirstOrDefault();
            try
            {

                lab.StatusId = 5;
                _context.Update(lab);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaboratorioExists(lab.LaboratorioId))
                {
                    return NotFound();
                }
                else
                {
                    return View("Index");
                }
            }
        }

        // GET: Laboratorios/Create
        public IActionResult Create()
        {
            ViewData["LaboratorioId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
            return View();
        }

        // POST: Laboratorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaboratorioId,NomeLaboratorio,Hardware,Software,QuantidadePcs,Projetor,StatusId")] Laboratorio laboratorio)
        {

            var temLaboratorio = _context.Laboratorio.Where(l => l.NomeLaboratorio == laboratorio.NomeLaboratorio).ToList();
            if (temLaboratorio.Any())
            {
                ViewBag.error = "Nome do laboratório já consta no banco de dados.";
                ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
                return View();
            }
            if (ModelState.IsValid)
            {
                _context.Add(laboratorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LaboratorioId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", laboratorio.LaboratorioId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
            return View(laboratorio);
        }

        // GET: Laboratorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio.FindAsync(id);
            if (laboratorio == null)
            {
                return NotFound();
            }
            ViewData["LaboratorioId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", laboratorio.LaboratorioId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");

            return View(laboratorio);
        }

        // POST: Laboratorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaboratorioId,NomeLaboratorio,Hardware,Software,QuantidadePcs,Projetor,StatusId")] Laboratorio laboratorio)
        {
            if (id != laboratorio.LaboratorioId)
            {
                return NotFound();
            }

            var temLaboratorio = _context.Laboratorio.Where(l => l.NomeLaboratorio == laboratorio.NomeLaboratorio && l.LaboratorioId != laboratorio.LaboratorioId).ToList();
            if (temLaboratorio.Any())
            {
                ViewBag.error = "Nome do laboratório já consta no banco de dados.";
                ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
                return View("Edit");
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(laboratorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratorioExists(laboratorio.LaboratorioId))
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
            ViewData["LaboratorioId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", laboratorio.LaboratorioId);
            return View(laboratorio);
        }

        

        // POST: Laboratorios/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var laboratorio = await _context.Laboratorio.FindAsync(id);
            _context.Laboratorio.Remove(laboratorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratorioExists(int id)
        {
            return _context.Laboratorio.Any(e => e.LaboratorioId == id);
        }
    }
}
