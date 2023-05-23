using iKnow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using iKnow.DAO;
using System.IO;

namespace iKnow.Controllers
{
    public class ClienteController : PadraoController<ClienteViewModel>
    {
        public IActionResult BagUsuario()
        {
            ViewBag.Usuario = "sim";
            return Create();
        }

        public IActionResult Form()
        {
            ClienteViewModel model = new ClienteViewModel();
            model.DataNasc = DateTime.Now;
            return View(model);
        }
        public IActionResult Home()
        {
            return View();
        }

        public ClienteController()
        {
            ExigeAutenticacao = false;
            DAO = new ClienteDAO();
            GeraProximoId = true;
        }
        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }
        protected override void ValidaDados(ClienteViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");

            if (string.IsNullOrEmpty(model.Cpf))
                ModelState.AddModelError("Cpf", "Preencha o seu CPF.");

            if (ClienteDAO.getInstance().Consulta(model.Cpf) != null && operacao == "I")
                ModelState.AddModelError("Cpf", "Este CPF já existe");

            if (model.DataNasc == null || model.DataNasc > DateTime.Now)
                ModelState.AddModelError("DataNasc", "Preencha a data de nascimento corretamente.");

            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");
            if (ModelState.IsValid)
            {
                
                if (operacao == "A" && model.Imagem == null)
                {
                    ClienteViewModel cid = DAO.Consulta(model.Id);
                    model.ImagemEmByte = cid.ImagemEmByte;
                }
                else if (operacao == "A" || (operacao == "I" && model.Imagem != null))
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }

        }
        public void FazOOtario()
        {
            ViewBag.Otario = true;
        }


        protected override void PreencheDadosParaView(string Operacao, ClienteViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            model.DataNasc = DateTime.Now;
        }
        public IActionResult ObtemDadosConsultaAvancada(string nome,
                                                             string cpf,
                                                             double descontoInicial,
                                                             double descontoFinal
                                                            )
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                if (string.IsNullOrEmpty(nome))
                    nome = "";
                if (string.IsNullOrEmpty(cpf))
                    cpf = "";
                if (descontoFinal == 0)
                    descontoFinal = 10000000000000;
                var lista = dao.ConsultaAvancadaJogos(nome, cpf, descontoInicial, descontoFinal);
                return PartialView("pvGridCliente", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }

        public override IActionResult Index()
        {
            try
            {
                return View(NomeViewIndex);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

    }

}
