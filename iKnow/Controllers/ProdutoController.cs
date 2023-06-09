﻿using iKnow.DAO;
using iKnow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;

namespace iKnow.Controllers
{
    public class ProdutoController : PadraoController<ProdutoViewModel>
    {
        public ProdutoController()
        {
            DAO = new ProdutoDAO();
            GeraProximoId = true;
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
        protected override void ValidaDados(ProdutoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            //Imagem será obrigatio apenas na inclusão.
            //Na alteração iremos considerar a que já estava salva.
            if (model.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");
            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");
            if (ModelState.IsValid)
            {
                //na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
                if (operacao == "A" && model.Imagem == null)
                {
                    ProdutoViewModel cid = DAO.Consulta(model.Id);
                    model.ImagemEmByte = cid.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }
        }
        public IActionResult ObtemDadosConsultaAvancada(string nome,
                                                         string categoria,
                                                         double precoInicial,
                                                         double precoFinal
                                                        )
        {
            try
            {
                ProdutoDAO dao = new ProdutoDAO();
                if (string.IsNullOrEmpty(nome))
                    nome = "";
                if (string.IsNullOrEmpty(categoria))
                    categoria = "";
                if (precoFinal == 0)
                    precoFinal = 10000000000000;
                var lista = dao.ConsultaAvancadaJogos(nome, categoria, precoInicial, precoFinal);
                return PartialView("pvGridProduto", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }

    }
}
