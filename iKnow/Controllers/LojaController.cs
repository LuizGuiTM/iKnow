using iKnow.DAO;
using iKnow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Web;
using Newtonsoft.Json;

namespace iKnow.Controllers
{
    public class LojaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Operacao = "qr_login";
            return View();
        }

        public IActionResult IndexComMensagem(string mensagem)
        {
            ViewBag.Erro = mensagem;
            ViewBag.Operacao = "qr_login";
            return View("Index");
        }

        public IActionResult ValidaQRCode(string qrcode, string Operacao)
        {
            if (qrcode == null)
            {
                ViewBag.Erro = "QR Code inválido.";
                if (Operacao == "qr_login")
                {
                    return Json(new { url = Url.Action("Index", "Loja") });
                }
                else
                {
                    return CarrinhoViewComMensagem(ViewBag.Erro);
                    //return CarrinhoView();
                }
            }
            else
            {
                if (qrcode[0] == 'U' && Operacao == "qr_login")
                {
                    string qr = qrcode.Substring(1, qrcode.Length - 1);
                    ClienteDAO clienteDAO = new ClienteDAO();
                    ClienteViewModel c = clienteDAO.Consulta(qr);
                    if (c == null)
                    {
                        ViewBag.Erro = "Usuário não encontrado.";
                        //return Index();
                        //return Json(new { url = Url.Action("Index", "Loja") });
                        return Json(new { url = Url.Action("IndexComMensagem", "Loja"), mensagem = ViewBag.Erro });
                    }
                    else
                    {
                        CompraViewModel comp = new CompraViewModel();
                        comp.IdCliente = c.Id;
                        comp.Desconto = c.Desconto;
                        comp.Nome = c.Nome;
                        ViewBag.Operacao = "compra";
                        //return IrParaCompras(comp);
                        return Json(new { url = Url.Action("IrParaCompras", "Loja"), compraViewModel = comp });
                    }
                }
                else if (qrcode[0] == 'L' && Operacao == "compra")
                {
                    string id_qr = qrcode.Substring(1, qrcode.Length - 1);
                    int id = -1;
                    int.TryParse(id_qr, out id);
                    if (id > 0)
                    {
                        ProdutoDAO produtoDAO = new ProdutoDAO();
                        ProdutoViewModel p = produtoDAO.Consulta(id);
                        if (p == null)
                        {
                            ViewBag.Erro = "QR Code inválido.";
                            return CarrinhoViewComMensagem(ViewBag.Erro);
                            //return CarrinhoView();
                            //return Json(new { url = Url.Action("CarrinhoView", "Loja") });
                        }
                        else
                        {
                            CarrinhoViewModel carrinho = new CarrinhoViewModel();
                            carrinho.IdProduto = p.Id;
                            carrinho.Preco = p.Preco;
                            carrinho.Nome = p.Nome;
                            carrinho.ImagemEmByte = p.ImagemEmByte;
                            carrinho.Categoria = p.Categoria;
                            carrinho.QtdProduto = 1;
                            return AddItemNaCompra(carrinho);
                            //return Json(new { url = Url.Action("AddItem", "Loja"), carrinhoViewModel = carrinho });
                        }
                    }
                    else
                    {
                        ViewBag.Erro = "QR Code inválido.";
                        if (Operacao == "qr_login")
                        {
                            //return Index();
                            //return Json(new { url = Url.Action("Index", "Loja") });
                            return Json(new { url = Url.Action("IndexComMensagem", "Loja"), mensagem = ViewBag.Erro });
                        }
                        else
                        {
                            return CarrinhoViewComMensagem(ViewBag.Erro);
                            //return CarrinhoView();
                            //return Json(new { url = Url.Action("CarrinhoView", "Loja") });
                        }
                    }
                }
                else if (qrcode[0] == 'L' && Operacao == "qr_login")
                {
                    ViewBag.Erro = "Insira o QRCode de usuário antes de registrar um livro.";
                    //return Index();
                    //return Json(new { url = Url.Action("Index", "Loja") });
                    return Json(new { url = Url.Action("IndexComMensagem", "Loja"), mensagem = ViewBag.Erro });
                }
                else if (qrcode[0] == 'U' && Operacao == "compra")
                {
                    ViewBag.Erro = "Você já está logado, insira o QR Code do livro para adicioná-lo a seu carrinho.";
                    return CarrinhoViewComMensagem(ViewBag.Erro);
                    //return CarrinhoView();
                    //return Json(new { url = Url.Action("CarrinhoView", "Loja") });
                }
                else if (Operacao == "qr_login")
                {
                    ViewBag.Erro = "QR Code inválido.";
                    //return Index();
                    //return Json(new { url = Url.Action("Index", "Loja") });
                    return Json(new { url = Url.Action("IndexComMensagem", "Loja"), mensagem = ViewBag.Erro });
                }
                else
                {
                    ViewBag.Erro = "QR Code inválido.";
                    return CarrinhoViewComMensagem(ViewBag.Erro);
                    //return Json(new { url = Url.Action("CarrinhoView", "Loja") });
                }
            }

        }
        public IActionResult IrParaCompras(string compraViewModel)
        {
            CompraViewModel comp = new CompraViewModel();

            if (!string.IsNullOrEmpty(compraViewModel))
            {
                // Decodificar e desserializar o parâmetro compraViewModel
                var compraViewModelJson = HttpUtility.UrlDecode(compraViewModel);
                comp = JsonConvert.DeserializeObject<CompraViewModel>(compraViewModelJson);
            }
            ViewBag.Operacao = "compra";
            return View("Compras", comp);
        }

        public IActionResult Compras()
        {
            ViewBag.Operacao = "compra";
            CompraViewModel compra = new CompraViewModel();
            return View("Compras", compra);
        }

        private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        {
            List<CarrinhoViewModel> carrinho = new List<CarrinhoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            if (carrinhoJson != null)
                carrinho = System.Text.Json.JsonSerializer.Deserialize<List<CarrinhoViewModel>>(carrinhoJson);
            return carrinho;
        }

        public IActionResult CarrinhoView()
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
            ViewBag.Operacao = "compra";
            return PartialView("Carrinho", carrinho);
        }

        public IActionResult CarrinhoViewComMensagem(string mensagem)
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
            ViewBag.Operacao = "compra";
            ViewBag.Erro = mensagem;
            return PartialView("Carrinho", carrinho);
        }

        public IActionResult AddItem(string carrinhoViewModel)
        {
            try
            {
                CarrinhoViewModel item = new CarrinhoViewModel();

                if (!string.IsNullOrEmpty(carrinhoViewModel))
                {
                    // Decodificar e desserializar o parâmetro compraViewModel
                    var compraViewModelJson = HttpUtility.UrlDecode(carrinhoViewModel);
                    item = JsonConvert.DeserializeObject<CarrinhoViewModel>(compraViewModelJson);
                }
                List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
                bool existe = false;
                foreach (var c in carrinho)
                {
                    if (item.IdProduto == c.IdProduto)
                    {
                        c.QtdProduto += 1;
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    carrinho.Add(item);
                }
                string carrinhoJson = System.Text.Json.JsonSerializer.Serialize(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);
                return CarrinhoView();
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult AddItemNaCompra(CarrinhoViewModel item)
        {
            try
            {
                List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
                bool existe = false;
                foreach (var c in carrinho)
                {
                    if (item.IdProduto == c.IdProduto)
                    {
                        c.QtdProduto += 1;
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    carrinho.Add(item);
                }
                string carrinhoJson = System.Text.Json.JsonSerializer.Serialize(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);
                return CarrinhoView();
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult Comprar(int IdCliente, double Desconto, string Nome)
        {

            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
            CompraViewModel compra = new CompraViewModel();
            CompraDAO compraDAO = new CompraDAO();



            compra.IdCliente = IdCliente;
            if(carrinho.Count == 0) 
            {
                compra.Desconto = Desconto;
                compra.Nome = Nome;
                ViewBag.Operacao = "compra";
                ViewBag.Erro = "Não há nenhum item em seu carrinho de compras";
                return View("Compras", compra);
            }
            compra.Id = compraDAO.ProximoId();
            compra.DataCompra = DateTime.Now;
            double preco = 0;
            compra.ValorTotal = preco;
            compraDAO.Insert(compra);
            ClienteDAO clienteDAO = new ClienteDAO();
            ClienteViewModel cliente = clienteDAO.Consulta(IdCliente);
            foreach (var item in carrinho)
            {
                ItemCompraViewModel itemCompra = new ItemCompraViewModel();
                ItemCompraDAO itD = new ItemCompraDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                ProdutoViewModel p = produtoDAO.Consulta(item.IdProduto);
                p.QtdDisponivel = p.QtdDisponivel - item.QtdProduto;
                produtoDAO.Update(p);
                itemCompra.Id = itD.ProximoId();
                itemCompra.IdCompra = compra.Id;
                itemCompra.IdProduto = item.IdProduto;
                itemCompra.QtdProduto = item.QtdProduto;
                preco += (item.Preco * cliente.Desconto) * itemCompra.QtdProduto;
                itD.Insert(itemCompra);
            }
            compra.ValorTotal = preco;
            compraDAO.Update(compra);
            RemoveCarrinho();
            return View("Parabens");
        }
        public IActionResult RemoveCarrinho()
        {
            HttpContext.Session.Remove("carrinho");
            return Index();
        }
        
        public IActionResult Parabens()
        {
            return View("Parabens");
        }
    }
}
