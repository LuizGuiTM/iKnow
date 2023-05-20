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
                    ClienteViewModel cid = DAO.Consulta(model.Id);
                    model.ImagemEmByte = cid.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }

        }
        protected override void PreencheDadosParaView(string Operacao, ClienteViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            model.DataNasc = DateTime.Now;
        }
    }

}
