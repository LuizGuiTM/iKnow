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
            if (qrcode[0] == 'U' && Operacao == "login")
            {
                ClienteDAO clienteDAO = new ClienteDAO();
                ClienteViewModel c = clienteDAO.Consulta(qrcode);
                if(c == null)
                {
                    ViewBag.Erro = "Usuário não encontrado.";
                    return Index();
                }
                else
                {
                    CompraViewModel comp = new CompraViewModel();
                    comp.IdCliente = c.Id;
                    ViewBag.NomeCliente = c.Nome;
                    return Compras(comp);
                }
            }
            else if (qrcode[0] == 'L' && Operacao == "compra")
            {
                string id_qr = qrcode.Substring(1, qrcode.Length - 1);
                int id = -1;
                int.TryParse(id_qr, out id);
                if(id > 0)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    ProdutoViewModel p = produtoDAO.Consulta(id);
                    if(p == null) 
                    {
                        ViewBag.Erro = "Livro não encontrado.";
                        return PartialView("ItemCompra");
                    }
                    else
                    {
                        ItemCompraViewModel itemCompra = new ItemCompraViewModel();
                        itemCompra.IdProduto = p.Id;
                        return AddItemNaCompra(itemCompra);
                    }
                }
                else
                {
                    ViewBag.Erro = "QR Code inválido.";
                    if(Operacao == "login")
                    {
                        return Index();
                    }
                    else
                    {
                        return PartialView("ItemCompra");
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
                return PartialView("ItemCompra");
            }
            else if (Operacao == "login")
            {
                return Index();
            }
            else
            {
                return PartialView("ItemCompra");
            }
        }
        public IActionResult Compras(CompraViewModel comp)
        {
            List<ProdutoViewModel> produtoList = new List<ProdutoViewModel>();
            return View("Compras", comp);
        }

        private List<ItemCompraViewModel> ObtemCarrinhoNaSession()
        {
            List<ItemCompraViewModel> carrinho = new List<ItemCompraViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            if (carrinhoJson != null)
                carrinho = JsonSerializer.Deserialize<List<ItemCompraViewModel>>(carrinhoJson);
            return carrinho;
        }

        public IActionResult AddItemNaCompra(ItemCompraViewModel item)
        {
            try
            {
                List<ItemCompraViewModel> carrinho = ObtemCarrinhoNaSession();
                carrinho.Add(item);
                string carrinhoJson = JsonSerializer.Serialize(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);
                return PartialView("ItemCompra");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel());
            }
        }
    }
}
