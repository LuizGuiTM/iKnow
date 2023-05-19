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
            object imgByte = model.ImagemEmByte; 
            if (imgByte == null) imgByte = DBNull.Value;
            SqlParameter[] parametros =
             {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.Nome),
                 new SqlParameter("CPF", model.Cpf),
                 new SqlParameter("DataNascimento", model.DataNasc),
                 new SqlParameter("Estado", model.Estado),
                 new SqlParameter("Cidade", model.Cidade),
                 new SqlParameter("Desconto", model.Desconto),
                 new SqlParameter("Credito", model.Credito),
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
                Desconto = Convert.ToDouble(registro["Desconto"].ToString()),
                Credito = Convert.ToDouble(registro["Credito"].ToString()),
            };
            if (registro["Documento"] != DBNull.Value)
                c.ImagemEmByte = registro["Documento"] as byte[];
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
