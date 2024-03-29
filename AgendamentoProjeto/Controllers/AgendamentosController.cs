﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoProjeto.Models;
using Microsoft.AspNetCore.Http;
using AgendamentoProjeto.Utils;
using Newtonsoft.Json;

namespace AgendamentoProjeto.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly Contexto _context;
        public AgendamentosController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Aprovar(int AgendamentoId)
        {
            var ag = await _context.Agendamento.FindAsync(AgendamentoId);
            string email = _context.Usuarios.Where(u => u.UsuarioId == ag.UsuarioId).Select(u => u.Email).FirstOrDefault();

            var disciplina =  _context.Disciplina.Where(d => d.DisciplinaId == ag.DisciplinaId).Select(d => d.NomeDisciplina).FirstOrDefault();
            var professor = _context.Professor.Where(p => p.ProfessorId == ag.ProfessorId).Select(p => p.NomeProfessor).FirstOrDefault();
            if (ag == null)
            {
                return NotFound();
            }
            ag.StatusId = 1;
            _context.Update(ag);
            await _context.SaveChangesAsync();
            EnvioEmail ee = new EnvioEmail();
            string emailLog = HttpContext.Session.GetString("EmailLogado");
            ee.EnvioDeEmail(emailLog, "Caro coordenador, seu agendamento com a data de " + ag.DataAgendamento.ToShortDateString() + " e horário "+ ag.DataAgendamento.ToShortTimeString()+ " da disciplina " + disciplina + " e ministrada pelo professor " + professor +" foi aprovado!","Aprovação de agendamento");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Reprovar(int AgendamentoId, string mensagem)
        {
            var ag = await _context.Agendamento.FindAsync(AgendamentoId);
            var avisos =  _context.Aviso.Where(b => b.AgendamentoId == AgendamentoId).Select(b => b).FirstOrDefault();
            
            var disciplina = _context.Disciplina.Where(d => d.DisciplinaId == ag.DisciplinaId).Select(d => d.NomeDisciplina).FirstOrDefault();
            var professor = _context.Professor.Where(p => p.ProfessorId == ag.ProfessorId).Select(p => p.NomeProfessor).FirstOrDefault();
            string email = _context.Usuarios.Where(u => u.UsuarioId == ag.UsuarioId).Select(u => u.Email).FirstOrDefault();
            if (ag == null)
            {
                return NotFound();
            }
            try
            {
                if (avisos!=null)
                {
                    _context.Aviso.Remove(avisos);
                    await _context.SaveChangesAsync();
                }
               
                _context.Agendamento.Remove(ag);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            EnvioEmail ee = new EnvioEmail();
            string emailLog = email;
            ee.EnvioDeEmail(emailLog, "Caro coordenador, seu agendamento com a data de " + ag.DataAgendamento.ToShortDateString() + " e horário " + ag.DataAgendamento.ToShortTimeString() + " da disciplina " + disciplina + " e ministrada pelo professor " + professor + " foi reprovada, motivo: " + mensagem, "Reprovação de agendamento");
            return RedirectToAction("Index");
        }

        public IActionResult SolicitarAgendamento()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina");
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio");
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor");
            ViewBag.user = HttpContext.Session.GetString("LoginLogado");
            return View();
        }

        public JsonResult TodosOsAgendamentosEmJson()
        {
            var todosOsAgendamentos = _context.Agendamento.Where(a => a.StatusId == 1).Select(a => a).ToList();

            var json = JsonConvert.SerializeObject(todosOsAgendamentos);
            return new JsonResult(json);
        }


        public async Task<IActionResult> DashBoardAgendamentos()
        {
            await BloquearLaboratorios();
            ViewBag.Avisos = _context.Aviso.Select(a => a);
            return View(await _context.Agendamento.Where(a => a.DataAgendamento.ToShortDateString() == DateTime.Now.ToShortDateString() && a.StatusId == 1).Select(a => a).Include(a => a.Professor).Include(a => a.Disciplina).Include(a=>a.Laboratorio).Include(a=>a.Avisos).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> DashBoardAgendamentos(string Procurar)
        {
            await BloquearLaboratorios();
            if (String.IsNullOrEmpty(Procurar))
            {
                ViewBag.Avisos = _context.Aviso.Select(a => a);
                return View(await _context.Agendamento.Where(a => a.DataAgendamento.ToShortDateString() == DateTime.Now.ToShortDateString() && a.StatusId == 1).Select(a => a).Include(a => a.Professor).Include(a => a.Disciplina).Include(a=>a.Laboratorio).Include(a=>a.Avisos).ToListAsync());
               
            }
            string ano = Procurar.ToLower().Substring(0, 4);
            string mes = Procurar.ToLower().Substring(5, 2);
            string dia = Procurar.ToLower().Substring(8, 2);
            string result = dia + "/" + mes + "/" + ano;
            DateTime dataPost = Convert.ToDateTime(result);
            if (dataPost < DateTime.Now.Date)
            {
                ViewBag.errorData = "Não é possível selecionar datas anteriores à hoje!";

                return View();
            }
            ViewBag.Avisos = _context.Aviso.Select(a => a);
            return View(await _context.Agendamento.Where(a => a.DataAgendamento.ToShortDateString() == dataPost.ToShortDateString() && a.StatusId == 1).Select(a => a).Include(a => a.Professor).Include(a => a.Disciplina).Include(a=>a.Laboratorio).Include(a=>a.Avisos).ToListAsync());
        }


        public async Task<IActionResult> SalvarSolicitacao([Bind("AgendamentoId,DataAgendamento,DataFimAgendamento,LaboratorioId,DisciplinaId,ProfessorId")] Agendamento agendamento)
        {
            var temNaBaseMesmoHorario = _context.Agendamento.Where(a => (a.DataAgendamento <= agendamento.DataAgendamento && a.DataFimAgendamento >= agendamento.DataFimAgendamento) && a.LaboratorioId == agendamento.LaboratorioId).ToList();
            if (temNaBaseMesmoHorario.Any())
            {
                ViewBag.error = "Horários conflitantes com outro agendamento, favor altere os horarios e tente novamente.";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                ViewBag.user = HttpContext.Session.GetString("LoginLogado");
                return View("SolicitarAgendamento");
            }
            if (agendamento.DataAgendamento < DateTime.Now)
            {

                ViewBag.error = "Data ou horário anterior a data atual, favor seleciona outra data ou horário.";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                ViewBag.user = HttpContext.Session.GetString("LoginLogado");
                return View("SolicitarAgendamento");
            }
            int idUser =  Convert.ToInt32(HttpContext.Session.GetInt32("usuarioIdLogado"));
            agendamento.UsuarioId = idUser;
            agendamento.StatusId = 2;
            _context.Add(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction("MeusAgendamentos");
        }

        public async Task<IActionResult> MeusAgendamentos()
        {
            await BloquearLaboratorios();
            var IdLogado = Convert.ToInt32(HttpContext.Session.GetInt32("usuarioIdLogado"));
            var avisos = _context.Aviso.Select(x => x);
            var meusAgendamentos = _context.Agendamento.Where(a => a.UsuarioId == IdLogado).Select(a => a).Include(a => a.Status).Include(a => a.Usuario).Include(a => a.Professor).Include(a=>a.Laboratorio).Include(a=>a.Disciplina).ToList().OrderByDescending(a => a.DataAgendamento);
            ViewBag.agendamentos = meusAgendamentos;
            ViewBag.Avisos = avisos;
            return View();
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index(string error)
        {
            await BloquearLaboratorios();


            if (error != null)
            {
                ViewBag.ErrorDatabase = error;
            }
           
            List<string> listaDeAvisos = new List<string>();
            var contexto = _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario).Include(a => a.Status).OrderByDescending(a=>a.DataAgendamento);
            var avisos = _context.Aviso.Select(x => x);
            ViewBag.AgendamentosPendentes = _context.Agendamento.Where(a => a.StatusId == 2).Select(a=>a);
            ViewBag.Contagem = _context.Agendamento.Where(a => a.StatusId == 2).Count();
            ViewBag.Avisos = avisos;
          
            return View(await contexto.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Procurar, bool gambiarra)
        {
            await BloquearLaboratorios();
            if (!String.IsNullOrEmpty(Procurar))
            {
                var avisos = _context.Aviso.Select(x => x);
                ViewBag.Avisos = avisos;
                DateTime DataFinal = Convert.ToDateTime(Procurar);
                var contexto = _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario).Include(a => a.Status).OrderByDescending(a => a.DataAgendamento);
                return View(await contexto.Where(x => x.DataAgendamento.ToShortDateString().Contains(DataFinal.ToShortDateString())).ToListAsync());

            }
            var cargo = HttpContext.Session.GetString("Cargo");
            ViewBag.cargo = cargo;
            var avisos1 = _context.Aviso.Select(x => x);
            ViewBag.Avisos = avisos1;
            return View(await _context.Agendamento.Include(a => a.Disciplina).Include(a => a.Laboratorio).Include(a => a.Professor).Include(a => a.Usuario).Include(a=>a.Status).OrderByDescending(a => a.DataAgendamento).ToListAsync());
        }


        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina");
            ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio");
            ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NomeUsuario");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "NomeStatus");
           
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendamentoId,DataAgendamento,DataFimAgendamento,LaboratorioId,DisciplinaId,UsuarioId,ProfessorId,StatusId")] Agendamento agendamento)
        {
           // var temNaBaseMesmoHorario = _context.Agendamento.Where(a => (a.DataAgendamento <= agendamento.DataAgendamento && a.DataFimAgendamento >= agendamento.DataFimAgendamento) && a.LaboratorioId == agendamento.LaboratorioId).ToList();
           // var temNaBaseMesmoHorarioFim = _context.Agendamento.Where(b => b.DataFimAgendamento == agendamento.DataFimAgendamento && b.LaboratorioId ==  agendamento.LaboratorioId).ToList();

            if (await HorarioValido(agendamento) == false)
            {

                ViewBag.error = "Horários conflitantes com outro agendamento, favor altere os horarios e tente novamente";
                ViewData["DisciplinaId"] = new SelectList(_context.Set<Disciplina>(), "DisciplinaId", "NomeDisciplina", agendamento.DisciplinaId);
                ViewData["LaboratorioId"] = new SelectList(_context.Set<Laboratorio>(), "LaboratorioId", "NomeLaboratorio", agendamento.LaboratorioId);
                ViewData["ProfessorId"] = new SelectList(_context.Set<Professor>(), "ProfessorId", "NomeProfessor", agendamento.ProfessorId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", agendamento.UsuarioId);
                ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "StatusId", "NomeStatus");
                return View();

            }
            if (agendamento.DataAgendamento < DateTime.Now || agendamento.DataFimAgendamento < agendamento.DataAgendamento || agendamento.DataFimAgendamento < DateTime.Now)
            {

                ViewBag.error = "Data ou horário anterior a data atual ou ao horario inicial, favor selecione outra data ou horário.";
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

        private async Task<bool> HorarioValido(Agendamento agendamento)
        {
            //if ( !await InicioValido(agendamento))
            //{
            //    ViewBag.erro = "O horário de inicio do agendamento está em conflito com outro agendamento" ;

            //    return false;
            //}
            //if (!await FinalValido(agendamento))
            //{
            //    ViewBag.erro = "O horário de fim do agendamento está em conflito com outro agendamento";

            //    return false;
            //}

            

            if (!await InicioIgual(agendamento) || !await FinalIgual(agendamento))
            {
                ViewBag.erro = "O horário de Fim ou Inicio do agendamento estão em conflito com outro agendamento";

                return false;

            }
            else
            {
                if (!await AgendamentoEntre(agendamento)   )
                {
                    ViewBag.erro = "O seu agendamento está ocorrendo dentro de outro agendamento ";

                    return false;
                }
                else
                {
                    if (!await AgendamentoAntes(agendamento) || !await AgendamentoDepois(agendamento))
                    {
                        ViewBag.erro = "O seu agendamento está Iniciando ou Terminando no meio de outro agendamento";

                        return false;
                    }
                }
            }

           



            return true;
        }


        //Não permite que as datas de inicio sejam iguais as de outros agendamentos no mesmo lab
        private async Task<bool> InicioIgual(Agendamento agendamento)
        {
             var  HoraInicio = await _context.Agendamento.Where(a => a.DataAgendamento == agendamento.DataAgendamento && (a.LaboratorioId == agendamento.LaboratorioId) ).ToListAsync();

            if ( !HoraInicio.Any())
            {
                return true;
            }

             return false;
        }

        // Não permite que as datas de fim sejam iguais as de outros agendamentos no mesmo lab
        private async Task<bool> FinalIgual(Agendamento agendamento)
        {
            var HoraFinal = await _context.Agendamento.Where(a => a.DataFimAgendamento == agendamento.DataFimAgendamento && (a.LaboratorioId == agendamento.LaboratorioId) ).ToListAsync();

            if ( !HoraFinal.Any())
            {
                return  true;
            }

             return false;
        }



        //Não permite que a data de inicio seja entre o Inicio e o Fim de outro agendamento && Não permite que a data de Fim seja entre o Inicio e o Fim de outro agendamento
        private async Task<bool> AgendamentoEntre(Agendamento agendamento)
            {

            var InicioEntre = await _context.Agendamento.Where(a => a.DataFimAgendamento > agendamento.DataAgendamento  && a.DataAgendamento < agendamento.DataFimAgendamento && (a.LaboratorioId == agendamento.LaboratorioId && a.AgendamentoId != agendamento.AgendamentoId)).ToListAsync();

            if (!InicioEntre.Any())
            {
                return true;
            }

            return false;

            }

        
        





        //Não permite que um agendamento que Inicie antes de outro, termine durante ou depois de outro agendamento
        private async Task<bool> AgendamentoAntes(Agendamento agendamento)
        {

            var AgendamentoIniciandoFora = await _context.Agendamento.Where(a => a.DataAgendamento > agendamento.DataAgendamento  && a.DataFimAgendamento < agendamento.DataFimAgendamento && (a.LaboratorioId == agendamento.LaboratorioId) ).ToListAsync();

            if (!AgendamentoIniciandoFora.Any())
            {
                return true;

            }
            return false;
        }


        //Nâo permite que um agendamento que Termine depois de outro, Inicie durante ou antes de outro agendamento
        private async Task<bool> AgendamentoDepois(Agendamento agendamento)
        {

            var AgendamentoTerminandoDepois = await _context.Agendamento.Where( a => a.DataFimAgendamento < agendamento.DataFimAgendamento && a.DataAgendamento > agendamento.DataAgendamento && (a.LaboratorioId == agendamento.LaboratorioId) ).ToListAsync();

            if (!AgendamentoTerminandoDepois.Any())
            {
                return true;

            }

            return false;
        }


        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (true)
            {

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
        public async Task<IActionResult> Edit(int id, [Bind("AgendamentoId,DataAgendamento,DataFimAgendamento,LaboratorioId,DisciplinaId,UsuarioId,ProfessorId,StatusId")] Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoId)
            {
                return NotFound();
            }
            var temNaBaseMesmoHorario = _context.Agendamento.Where(a => a.DataAgendamento == agendamento.DataAgendamento && a.AgendamentoId != agendamento.AgendamentoId && a.LaboratorioId == agendamento.LaboratorioId).ToList();
            var temNaBaseMesmoHorarioFim = _context.Agendamento.Where(b => b.DataFimAgendamento == agendamento.DataFimAgendamento && b.AgendamentoId != agendamento.AgendamentoId && b.LaboratorioId == agendamento.LaboratorioId).ToList();
     
            if (temNaBaseMesmoHorario.Any() || temNaBaseMesmoHorarioFim.Any())
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
            var avisos = _context.Aviso.Select(a => a).ToList();
            foreach(var av in avisos)
            {
                if (av.AgendamentoId == agendamento.AgendamentoId)
                {
                    return Json(new { message = "error" });
                }
            }
            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<bool> BloquearLaboratorios()
        {
            var labsDisponivel = _context.Agendamento.Where(a => a.DataFimAgendamento < DateTime.Now && a.StatusId == 1).ToList();
            if (labsDisponivel.Count > 0)
            {
                foreach (var ag in labsDisponivel)
                {
                    ag.StatusId = 4;
                    _context.Update(ag);
                    await _context.SaveChangesAsync();
                }
                return true;
            }

            return true;
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamento.Any(e => e.AgendamentoId == id);
        }
    }
}