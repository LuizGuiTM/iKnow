using iKnow.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace iKnow.DAO
{
    public class FuncionarioDAO : PadraoDAO<FuncionarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(FuncionarioViewModel model)
        {
            SqlParameter[] parametros =
                 {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.Nome),
                 new SqlParameter("CPF", model.Cpf),
                 new SqlParameter("DataNascimento", model.DataNasc),
                 new SqlParameter("Salario", model.Salario),
                 new SqlParameter("Cargo", model.Cargo),
                 new SqlParameter("Estado", model.Estado),
                 new SqlParameter("Cidade", model.Cidade)
                 };
            return parametros;
        }

        protected override FuncionarioViewModel MontaModel(DataRow registro)
        {
            FuncionarioViewModel f = new FuncionarioViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                Nome = registro["Nome"].ToString(),
                Cpf = registro["CPF"].ToString(),
                DataNasc = Convert.ToDateTime(registro["DataNascimento"]),
                Salario = Convert.ToDouble(registro["Salario"]),
                Cargo = registro["Cargo"].ToString(),
                Estado = registro["Estado"].ToString(),
                Cidade = registro["Cidade"].ToString(),
            };
            return f;
        }

        protected override void SetTabela()
        {
            Tabela = "Funcionario";
        }
    }
}
