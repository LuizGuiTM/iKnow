using iKnow.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace iKnow.DAO
{
    public class ProdutoDAO : PadraoDAO<ProdutoViewModel>
    {
        protected override SqlParameter[] CriaParametros(ProdutoViewModel model)
        { 
            object imgByte = model.ImagemEmByte;
             if (imgByte == null)
             imgByte = DBNull.Value;

            SqlParameter[] parametros =
             {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.Nome),
                 new SqlParameter("Preco", model.Preco),
                 new SqlParameter("QuantidadeDisponivel", model.QtdDisponivel),
                 new SqlParameter("Imagem", imgByte)


             };
            return parametros;
        }

        protected override ProdutoViewModel MontaModel(DataRow registro)
        {
            ProdutoViewModel p = new ProdutoViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                Nome = registro["Nome"].ToString(),
                Preco = Convert.ToDouble(registro["Preco"]),
                QtdDisponivel = Convert.ToInt32(registro["QuantidadeDisponivel"]),
            };
            if (registro["imagem"] != DBNull.Value)
                p.ImagemEmByte = registro["Imagem"] as byte[];
            return p;
        }

        protected override void SetTabela()
        {
            Tabela = "Produtos";
        }
    }
}
