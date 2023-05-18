using iKnow.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace iKnow.DAO
{
    public class CompraDAO : PadraoDAO<CompraViewModel>
    {
        protected override SqlParameter[] CriaParametros(CompraViewModel model)
        {
            SqlParameter[] parametros =
             {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("IdCliente", model.IdCliente),
                 new SqlParameter("ValorTotal", model.ValorTotal),
                 new SqlParameter("DataCompra", model.DataCompra),

             };
            return parametros;
        }

        protected override CompraViewModel MontaModel(DataRow registro)
        {
            CompraViewModel c = new CompraViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                IdCliente = Convert.ToInt32(registro["IdCliente"]),
                ValorTotal = Convert.ToDouble(registro["ValorTotal"]),
                DataCompra = Convert.ToDateTime(registro["DataCompra"]),
            };
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Compras";
        }
    }
}
