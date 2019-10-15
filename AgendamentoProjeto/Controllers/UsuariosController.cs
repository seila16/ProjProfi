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
    public class UsuariosController : Controller
    {
        private readonly Contexto _context;

        public UsuariosController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> TrocarStatus(int UsuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(UsuarioId);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.StatusId = 1;
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Reprovar(int UsuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(UsuarioId);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.StatusId = 4;
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(bool NotDelete, Usuario usuario)
        {
            ViewBag.NotDelete = NotDelete;
            ViewBag.UsuariosPendentes = _context.Usuarios.Where(u => u.StatusId == 2).ToList();
            ViewBag.Contagem = _context.Usuarios.Where(u => u.StatusId == 2).Count();

            ViewBag.CargoContexto = _context.Usuarios.Where(u => u.CargoId == 1).ToList();
            
            //var CargoUsuario = _context.Usuarios.Where(u => u.Cargo.NomeCargo == usuario.Cargo.NomeCargo).ToList();

            //if (CargoUsuario.Equals("T.I"))
            //{
            //    ViewBag.CargoUsuario = true;
            //    return View();

            //}





            var contexto = _context.Usuarios.Include(u => u.Cargo).Include(u => u.Curso);
            //Exibe todos os usuários
            //return View(await contexto.ToListAsync())

            //exibe apenas usuários ativos
            return View(await contexto.Where( u => u.StatusId == 1).ToListAsync());
        }

        

        [HttpPost]
        public async Task<IActionResult> Index(string Procurar)
        {
            if (!String.IsNullOrEmpty(Procurar))
            {
                ViewBag.UsuariosPendentes = _context.Usuarios.Where(u => u.StatusId == 2).ToList();
                ViewBag.Contagem = _context.Usuarios.Where(u => u.StatusId == 2).Count();
                return View(await _context.Usuarios.Where(x => x.NomeUsuario.ToUpper().Contains(Procurar.ToUpper())).ToListAsync());
            }
            ViewBag.UsuariosPendentes = _context.Usuarios.Where(u => u.StatusId == 2).ToList();
            ViewBag.Contagem = _context.Usuarios.Where(u => u.StatusId == 2).Count();
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Cargo)
                .Include(u => u.Curso)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo");
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,NomeUsuario,Login,Email,Senha,CargoId,CursoId,StatusId")] Usuario usuario)
        {
            var temEmail = _context.Usuarios.Where(x => x.Email == usuario.Email).ToList();
            var temLogin = _context.Usuarios.Where(x => x.Login == usuario.Login).ToList();
            if (ModelState.IsValid && temEmail.Count == 0)
            {
                if (temLogin.Count == 0)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.LoginRepetido = true;
                    ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", usuario.CargoId);
                    ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", usuario.CursoId);
                    ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", usuario.StatusId);
                    return View(usuario);
                   

                }
            }
            else
            {
                ViewBag.EmailRepetido = true;
                ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", usuario.CargoId);
                ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", usuario.CursoId);
                ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", usuario.StatusId);
                return View(usuario);

              
            }
           
        }

       
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", usuario.CargoId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", usuario.CursoId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,NomeUsuario,Login,Email,CargoId,CursoId,StatusId")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (id == usuario.UsuarioId)
            {
                try
                {
                    string pass = _context.Usuarios.Where(x=>x.Email == usuario.Email).Select(x=>x.Senha).FirstOrDefault();
                    usuario.Senha = pass;
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
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
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", usuario.CargoId);
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", usuario.CursoId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus", usuario.StatusId);
            return View(usuario);
        }

       

        // POST: Usuarios/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioNoAgendamento = _context.Agendamento.Where(x => x.UsuarioId == id).ToList();
            if (usuarioNoAgendamento.Count > 0)
            {
                return RedirectToAction("Index",new { NotDelete = true });

            }
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
