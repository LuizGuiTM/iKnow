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
            if (string.IsNullOrEmpty(model.Senha))
                ModelState.AddModelError("Senha", "Preencha a sua senha.");
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

    }
}
