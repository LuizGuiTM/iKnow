using iKnow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace iKnow.DAO
{
    public class ClienteDAO : PadraoDAO<ClienteViewModel>
    {
        public static ClienteDAO getInstance() { return new ClienteDAO(); }
        protected override SqlParameter[] CriaParametros(ClienteViewModel model)
        {
            object imgByte = model.ImagemEmByte;
            if (imgByte == null) imgByte = new byte[0];

            object dataDeNascimento = model.DataNasc;
            if (dataDeNascimento == null)
                dataDeNascimento = SqlDateTime.MinValue.Value;

            object Estado = model.Estado;
            if (Estado == null)
                Estado = DBNull.Value;

            object Cidade = model.Cidade;
            if (Cidade == null)
                Cidade = DBNull.Value;

            object Desconto = model.Desconto;
            if (Desconto == null)
                Desconto = DBNull.Value;

            object Credito = model.Credito;
            if (Credito == null)
                Credito = DBNull.Value;

            SqlParameter[] parametros =
             {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.Nome),
                 new SqlParameter("CPF", model.Cpf),
                 new SqlParameter("DataNascimento", dataDeNascimento),
                 new SqlParameter("Estado", Estado),
                 new SqlParameter("Cidade", Cidade),
                 new SqlParameter("Desconto", Desconto),
                 new SqlParameter("Credito", Credito),
                 new SqlParameter("Documento", imgByte)
             };
            return parametros;
        }

        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                Nome = registro["Nome"].ToString(),
                Cpf = registro["CPF"].ToString(),
                DataNasc = Convert.ToDateTime(registro["DataNascimento"]),
                Estado = registro["Estado"].ToString(),
                Cidade = registro["Cidade"].ToString(),
                Desconto = Convert.ToDouble(registro["Desconto"]),
                Credito = Convert.ToDouble(registro["Credito"]),
            };

            if (registro["Documento"] != DBNull.Value)
                c.ImagemEmByte = registro["Documento"] as byte[];

            if (registro["Estado"] != DBNull.Value)
                c.Estado = Convert.ToString(registro["Estado"]);

            if (registro["Cidade"] != DBNull.Value)
                c.Cidade = Convert.ToString(registro["Cidade"]);

            if (registro["Desconto"] != DBNull.Value)
                c.Desconto = Convert.ToDouble(registro["Desconto"]);

            if (registro["Credito"] != DBNull.Value)
                c.Credito = Convert.ToDouble(registro["Credito"]);

            if (registro["DataNascimento"] != DBNull.Value)
                c.DataNasc = Convert.ToDateTime(registro["DataNascimento"]);

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Clientes";
        }

        public ClienteViewModel Consulta(string CPF)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("Cpf", CPF),
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaCPF", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
        public List<ClienteViewModel> ConsultaAvancadaJogos(string nome,
                                                         string cpf,
                                                         double descontoInicial,
                                                         double descontoFinal)
        {
            SqlParameter[] p = {
             new SqlParameter("nome", nome),
             new SqlParameter("cpf", cpf),
             new SqlParameter("descontoInicial", descontoInicial),
             new SqlParameter("descontoFinal", descontoFinal),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaClientes", p);
            var lista = new List<ClienteViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }
    }
}
