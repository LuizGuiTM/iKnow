﻿using iKnow.Models;
using System;
using System.Collections.Generic;
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
                 new SqlParameter("Imagem", imgByte),
                 new SqlParameter("Categoria", model.Categoria)

             };
            return parametros;
        }
        public List<ProdutoViewModel> ConsultaAvancadaJogos(string nome,
                                                         string categoria,
                                                         double precoInicial,
                                                         double precoFinal)
        {
             SqlParameter[] p = {
             new SqlParameter("nome", nome),
             new SqlParameter("categoria", categoria),
             new SqlParameter("precoInicial", precoInicial),
             new SqlParameter("precoFinal", precoFinal),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaProdutos", p);
            var lista = new List<ProdutoViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }

        protected override ProdutoViewModel MontaModel(DataRow registro)
        {
            ProdutoViewModel p = new ProdutoViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                Nome = registro["Nome"].ToString(),
                Preco = Convert.ToDouble(registro["Preco"]),
                QtdDisponivel = Convert.ToInt32(registro["QuantidadeDisponivel"]),
                Categoria = registro["Categoria"].ToString()
            };
            if (registro.Table.Columns.Contains("imagem"))
            {
                if (registro["imagem"] != DBNull.Value)
                    p.ImagemEmByte = registro["Imagem"] as byte[];
            }     
            return p;
        }

        protected override void SetTabela()
        {
            Tabela = "Produtos";
        }
    }
}
