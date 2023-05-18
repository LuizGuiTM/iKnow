using iKnow.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace iKnow.DAO
{
    public class ClienteDAO : PadraoDAO<ClienteViewModel>
    {
        protected override SqlParameter[] CriaParametros(ClienteViewModel model)
        {
            SqlParameter[] parametros =
             {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.Nome),
                 new SqlParameter("CPF", model.Cpf),
                 new SqlParameter("DataNascimento", model.DataNasc),
                 new SqlParameter("Estado", model.Estado),
                 new SqlParameter("Cidade", model.Cidade)
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
            };
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
    }
}
