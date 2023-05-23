using CadastroAlunoV1.Controllers;
using iKnow.DAO;
using iKnow.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKnow.Controllers
{
    public class FuncionarioController : PadraoController<FuncionarioViewModel>
    {
        public FuncionarioController()
        {
            ExigeAutenticacao = false;
            DAO = new FuncionarioDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(FuncionarioViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Cpf))
                ModelState.AddModelError("Cpf", "Preencha o seu CPF.");
            if (FuncionarioDAO.getInstance().Consulta(model.Cpf) != null && operacao == "I")
                ModelState.AddModelError("Cpf", "Este CPF já existe");
            if (model.DataNasc == null || model.DataNasc > DateTime.Now)
                ModelState.AddModelError("DataNasc", "Preencha a data de nascimento corretamente.");
            if (string.IsNullOrEmpty(model.Senha))
                ModelState.AddModelError("Senha", "Preencha a sua senha.");
        }

        protected override void PreencheDadosParaView(string Operacao, FuncionarioViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            if(Operacao == "I")
            {
                model.DataNasc = DateTime.Now;
            }
        }

        public IActionResult SaveFunc(FuncionarioViewModel model, string Operacao)
        {
            try
            {
                ValidaDados(model, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    PreencheDadosParaView(Operacao, model);
                    return View(NomeViewForm, model);
                }
                else
                {
                    if (Operacao == "I")
                    {
                        DAO.Insert(model);
                        if (ViewBag.FuncionarioRH == true)
                            return RedirectToAction(NomeViewIndex);
                        else
                            return RedirectToAction("index", "Login");
                    }
                    else
                    {
                        DAO.Update(model);
                        return RedirectToAction(NomeViewIndex);
                    }
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel());
            }
        }
        public IActionResult ObtemDadosConsultaAvancada(string nome, string cpf, string cargo, string estado, string cidade, double salarioInicial, double salarioFinal)
        {
            try
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                if (string.IsNullOrEmpty(nome))
                    nome = "";
                if (string.IsNullOrEmpty(cpf))
                    cpf = "";
                if (string.IsNullOrEmpty(cargo))
                    cargo = "";
                if (string.IsNullOrEmpty(estado))
                    estado = "";
                if (string.IsNullOrEmpty(cidade))
                    cidade = "";
                if (salarioFinal == 0)
                    salarioFinal = 10000000000000;
                var lista = dao.ConsultaAvancadaFuncionarios(nome, cpf, cargo, estado, cidade, salarioInicial, salarioFinal);
                return PartialView("pvGridFuncionario", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }
    }
}
