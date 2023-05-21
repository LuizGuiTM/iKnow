using CadastroAlunoV1.Controllers;
using iKnow.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace iKnow.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            ViewBag.FuncionarioRH = HelperControllers.VerificaFuncionarioRH(HttpContext.Session);
            return View();
        }

        [HttpPost]
        public List<object> GetQuantidadeFuncionariosPorEstado()
        {
            string sql = "select count(id) as 'Value', Estado as 'Label' from Funcionarios group by Estado";
            DataTable dados = HelperDAO.ExecutaSelect(sql, null);
            return ConvertDataTableToList(dados);
        }

        [HttpPost]
        public List<object> GetQuantidadeLivrosPorCategoria()
        {
            string sql = "select count(id) as 'Value', Categoria as 'Label' from Produtos group by categoria";
            DataTable dados = HelperDAO.ExecutaSelect(sql, null);
            return ConvertDataTableToList(dados);
        }

        [HttpPost]
        public List<object> GetQuantidadeDisponivelLivrosPorCategoria()
        {
            string sql = "select sum(QuantidadeDisponivel) as 'Value', Categoria as 'Label' from Produtos group by categoria";
            DataTable dados = HelperDAO.ExecutaSelect(sql, null);
            return ConvertDataTableToList(dados);
        }

        public List<object> ConvertDataTableToList(DataTable dados)
        {
            List<object> data = new List<object>();

            List<string> labels = new List<string>();
            List<int> numeros = new List<int>();

            foreach (DataRow row in dados.Rows)
            {
                labels.Add(row["Label"].ToString());
                numeros.Add(Convert.ToInt32(row["Value"]));
            }

            data.Add(labels);
            data.Add(numeros);

            return data;
        }
    }
}
