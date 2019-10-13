using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Http;

namespace AgendamentoProjeto.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _contexto;
        int CodigoGeral;
        public LoginController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Logar()
        {
            ViewData["CargoId"] = new SelectList(_contexto.Cargos, "CargoId", "NomeCargo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logar([Bind("UsuarioId,Login,Senha,CargoId,StatusId")] Usuario usuario)
        {
            ViewData["CargoId"] = new SelectList(_contexto.Cargos, "CargoId", "NomeCargo");
            //var login = from user in _contexto.Usuarios where user.Login == usuario.Login && user.Senha == usuario.Senha && user.CargoId == usuario.CargoId && usuario.StatusId == 1 select user;
            var login = _contexto.Usuarios.Where(u => u.Login == usuario.Login && u.Senha == usuario.Senha && u.CargoId == usuario.CargoId && u.StatusId == 1).ToList();

            if (login.Any())
            {
                return RedirectToAction("Index", "Agendamentos");
            }
            else
            {
                TempData["msgSucesso"] = "Login, senha ou cargo incorretos ou usuário inativo.";
                return View("Logar");
            }


        }

        public IActionResult GerarSenha()
        {
            ViewData["CargoId"] = new SelectList(_contexto.Cargos, "CargoId", "NomeCargo");
            return View();
        }

        public IActionResult EsqueciSenha(bool naoResetou, string erroCode)
        {
            if (erroCode == "sim")
            {
                ViewBag.erroCode = true;
            }
            if (naoResetou == true)
            {
                ViewBag.naoResetou = true;
            }
            return View();
        }

        public IActionResult ValidarCodigo(string Login, string Senha, int codigo)
        {
            int c = Convert.ToInt32(HttpContext.Session.GetInt32("code"));
            if (c == codigo)
            {
                Usuario user = _contexto.Usuarios.Where(x => x.Login == Login).FirstOrDefault();
                user.Senha = Senha;
                _contexto.Update(user);
                 _contexto.SaveChanges();
                return View();
            }
            else
            {
                return RedirectToAction("EsqueciSenha", new { naoResetou = true });

            }
        }

        public IActionResult GerarCodigo(string Login, string Email)
        {
            var SucessoDados = _contexto.Usuarios.Where(x => x.Login == Login && x.Email == Email).ToList();
            if (SucessoDados.Count >0)
            {
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("Admin",
                "projetoprofi2019@gmail.com");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress("Usuário",
                Email);
                message.To.Add(to);

                message.Subject = "Reset de senha";
                Random randNum = new Random();
                CodigoGeral = randNum.Next(100) + randNum.Next(100) + randNum.Next(100) + randNum.Next(100) + randNum.Next(100);
                HttpContext.Session.SetInt32("code", CodigoGeral);
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $"<p>Olá querido usuário, segue seu código de reset de senha {CodigoGeral} <p>";
                bodyBuilder.TextBody = "Reset de senha";
                message.Body = bodyBuilder.ToMessageBody();
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("projetoprofi2019@gmail.com", "projetoMERDA123");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
                return View("GerarCodigo");

            }
            else
            {

                return RedirectToAction("EsqueciSenha", new {naoResetou = false, erroCode = "sim" });
            }
          
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnviarSolic([Bind("UsuarioId,Login,Senha,Email,NomeUsuario,CargoId")] Usuario usuario)
        {
            try
            {
                int IdBanco = 0;
                var stats = _contexto.Status.Where(x => x.NomeStatus == "pendente").FirstOrDefault();
                var emailRepetido = _contexto.Usuarios.Select(u => u.Email).Contains(usuario.Email);
                var loginRepetido = _contexto.Usuarios.Select(u => u.Login).Contains(usuario.Login);
                IdBanco = stats.StatusId;
                var idUser = _contexto.Usuarios.Count() + 1;
                if (emailRepetido == true)
                {
                    TempData["msgSucesso"] = "E-mail já consta em nossa base de dados, favor insira outro e-mail";
                    return RedirectToAction("GerarSenha");
                }
                if (loginRepetido == true)
                {
                    TempData["msgSucesso"] = "Login já consta em nossa base de dados, favor insira outro Login";
                    return RedirectToAction("GerarSenha");
                }

                usuario.StatusId = 2;
                _contexto.Add(usuario);
                TempData["msgSucesso"] = "Solicitação enviada com sucesso";
                await _contexto.SaveChangesAsync();

                return RedirectToAction("Logar");
            }
            catch (Exception ex)
            {
                TempData["msgSucesso"] = "Ocorreu um erro na sua solicitação, favor contate o administrador do site";
                return RedirectToAction("GerarSenha");
            }
        }
    }
}