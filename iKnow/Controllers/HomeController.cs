using iKnow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CadastroAlunoV1.Controllers;
using iKnow.DAO;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace iKnow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            ViewBag.Operacao = "login";
            return View();
        }
        private readonly ILogger<HomeController> _logger;

        public object JsonConvert { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ValidaQRCode(string qrcode, string Operacao)
        {
            if(qrcode == null)
            {
                ViewBag.Erro = "QR Code inválido.";
                if (Operacao == "login")
                {
                    return Index();
                }
                else
                {
                    return CarrinhoView();
                }
            }
            else
            {
                if (qrcode[0] == 'U' && Operacao == "login")
                {
                    ClienteDAO clienteDAO = new ClienteDAO();
                    ClienteViewModel c = clienteDAO.Consulta(qrcode);
                    if (c == null)
                    {
                        ViewBag.Erro = "Usuário não encontrado.";
                        return Index();
                    }
                    else
                    {
                        CompraViewModel comp = new CompraViewModel();
                        comp.IdCliente = c.Id;
                        comp.Desconto = c.Desconto;
                        comp.Nome = c.Nome;
                        return Compras(comp);
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
                            return CarrinhoView();
                        }
                        else
                        {
                            CarrinhoViewModel carrinho = new CarrinhoViewModel
                            {
                                IdProduto = p.Id,
                                Preco = p.Preco,
                                Nome = p.Nome,
                                ImagemEmBase64 = p.ImagemEmBase64,
                                QtdProduto = 1
                            };
                            return AddItemNaCompra(carrinho);
                        }
                    }
                    else
                    {
                        ViewBag.Erro = "QR Code inválido.";
                        if (Operacao == "login")
                        {
                            return Index();
                        }
                        else
                        {
                            return CarrinhoView();
                        }
                    }
                }
                else if (qrcode[0] == 'L' && Operacao == "login")
                {
                    ViewBag.Erro = "Insira o QRCode de usuário antes de registrar um livro.";
                    return Index();
                }
                else if (qrcode[0] == 'U' && Operacao == "compra")
                {
                    ViewBag.Erro = "Você já está logado, insira o QR Code do livro para adicioná-lo a seu carrinho.";
                    return CarrinhoView();
                }
                else if (Operacao == "login")
                {
                    ViewBag.Erro = "QR Code inválido.";
                    return Index();
                }
                else
                {
                    ViewBag.Erro = "QR Code inválido.";
                    return CarrinhoView();
                }
            }

        }
        public IActionResult Compras(CompraViewModel comp)
        {
            List<ProdutoViewModel> produtoList = new List<ProdutoViewModel>();
            return View("Compras", comp);
        }

        private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        {
            List<CarrinhoViewModel> carrinho = new List<CarrinhoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            if (carrinhoJson != null)
                carrinho = JsonSerializer.Deserialize<List<CarrinhoViewModel>>(carrinhoJson);
            return carrinho;
        }

        public IActionResult CarrinhoView()
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
            ViewBag.Operacao = "compra";
            return PartialView("Carrinho", carrinho);
        }

        public IActionResult AddItemNaCompra(CarrinhoViewModel item)
        {
            try
            {
                List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
                bool existe = false;
                foreach(var c in carrinho)
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
                string carrinhoJson = JsonSerializer.Serialize(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);
                return CarrinhoView();
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }
        public IActionResult Comprar(int IdCliente)
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
            CompraViewModel compra = new CompraViewModel();
            CompraDAO compraDAO = new CompraDAO();
            compra.Id = compraDAO.ProximoId();
            compra.IdCliente = IdCliente;
            compra.DataCompra = DateTime.Now;
            double preco = 0;
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
                itemCompra.IdCompra = compra.Id;
                itemCompra.IdProduto = item.IdProduto;
                itemCompra.QtdProduto = item.QtdProduto;
                preco += (item.Preco * cliente.Desconto) * itemCompra.QtdProduto;
                itD.Insert(itemCompra);
            }
            compra.ValorTotal = preco;
            compraDAO.Insert(compra);
            return View("Parabens");
        }
        public IActionResult RemoveCarrinho()
        {
            HttpContext.Session.SetString("carrinho", null);
            return Index();
        }
    }
}
