using iKnow.DAO;
using iKnow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadAlunoMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FazLogin(string usuario, string senha)
        {
            FuncionarioViewModel func = FuncionarioDAO.getInstance().Consulta(usuario);
            if (func != null && func.Senha == senha && func.Cargo == "RH")
            {
                HttpContext.Session.SetString("Logado", "true");
                HttpContext.Session.SetString("FuncionarioRH", "true");
                return RedirectToAction("index", "Home");
            }
            else if (func != null && func.Senha == senha)
            {
                HttpContext.Session.SetString("Logado", "true");
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

