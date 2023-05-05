using iKnow.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace iKnow.DAO
{
    public class ItemCompraDAO : PadraoDAO<ItemCompraViewModel>
    {
        protected override SqlParameter[] CriaParametros(ItemCompraViewModel model)
        {
            SqlParameter[] parametros =
             {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("IdCompra", model.IdCompra),
                 new SqlParameter("IdProduto", model.IdProduto),
                 new SqlParameter("QuantidadeProduto", model.QtdProduto),

             };
            return parametros;
        }

        protected override ItemCompraViewModel MontaModel(DataRow registro)
        {
            ItemCompraViewModel ic = new ItemCompraViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                IdCompra = Convert.ToInt32(registro["IdCompra"]),
                IdProduto = Convert.ToInt32(registro["IdProduto"]),
                QtdProduto = Convert.ToInt32(registro["QuantidadeProduto"])
            };
            return ic;
        }

        protected override void SetTabela()
        {
            Tabela = "ItemCompra";
        }
    }
}
