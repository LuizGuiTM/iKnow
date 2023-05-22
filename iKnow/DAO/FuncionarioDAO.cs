using iKnow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace iKnow.DAO
{
    public class FuncionarioDAO : PadraoDAO<FuncionarioViewModel>
    {
        public static FuncionarioDAO getInstance() { return new FuncionarioDAO(); }
        protected override SqlParameter[] CriaParametros(FuncionarioViewModel model)
        {
            object salario = model.Salario;
            if (salario == null)
                salario = DBNull.Value;

            object dataDeNascimento = model.DataNasc;
            if (dataDeNascimento == null)
                dataDeNascimento = SqlDateTime.MinValue.Value;

            object Nome = model.Nome;
            if (Nome == null)
                Nome = DBNull.Value;

            object Cargo = model.Cargo;
            if (Cargo == null)
                Cargo = DBNull.Value;

            object Estado = model.Estado;
            if (Estado == null)
                Estado = DBNull.Value;

            object Cidade = model.Cidade;
            if (Cidade == null)
                Cidade = DBNull.Value;

            SqlParameter[] parametros =
                 {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", Nome),
                 new SqlParameter("CPF", model.Cpf),
                 new SqlParameter("DataNascimento", dataDeNascimento),
                 new SqlParameter("Salario", salario),
                 new SqlParameter("Cargo", Cargo),
                 new SqlParameter("Estado", Estado),
                 new SqlParameter("Senha", model.Senha),
                 new SqlParameter("Cidade", Cidade)
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
                Cargo = registro["Cargo"].ToString(),
                Estado = registro["Estado"].ToString(),
                Cidade = registro["Cidade"].ToString(),
                Senha = registro["Senha"].ToString()    
            };

            if (registro["Salario"] != DBNull.Value)
                f.Salario = Convert.ToDouble(registro["Salario"]);

            if (registro["DataNascimento"] != DBNull.Value)
                f.DataNasc = Convert.ToDateTime(registro["DataNascimento"]);

            if (registro["Nome"] != DBNull.Value)
                f.Nome = Convert.ToString(registro["Nome"]);

            if (registro["Estado"] != DBNull.Value)
                f.Estado = Convert.ToString(registro["Estado"]);

            if (registro["Cidade"] != DBNull.Value)
                f.Cidade = Convert.ToString(registro["Cidade"]);

            if (registro["Cargo"] != DBNull.Value)
                f.Cargo = Convert.ToString(registro["Cargo"]);

            return f;
        }
        public FuncionarioViewModel Consulta(string CPF)
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
        protected override void SetTabela()
        {
            Tabela = "Funcionarios";
        }

        public List<FuncionarioViewModel> ConsultaAvancadaFuncionarios(string nome,
                                                 string cpf,
                                                 string cargo,
                                                 string estado,
                                                 string cidade,
                                                 double salarioInicial,
                                                 double salarioFinal)
        {
            SqlParameter[] p = {
             new SqlParameter("nome", nome),
             new SqlParameter("cpf", cpf),
             new SqlParameter("cargo", cargo),
             new SqlParameter("estado", estado),
             new SqlParameter("cidade", cidade),
             new SqlParameter("salarioInicial", salarioInicial),
             new SqlParameter("salarioFinal", salarioFinal)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaFuncionarios", p);
            var lista = new List<FuncionarioViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }
    }
}
