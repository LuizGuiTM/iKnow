using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System;
using System.Data.SqlClient;
using iKnow.Models;

namespace iKnow.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        public PadraoDAO()
        {
            SetTabela();
        }
        protected string Tabela { get; set; }
        protected string NomeSpListagem { get; set; } = "spListagem";
        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);
        protected abstract void SetTabela();

        public virtual void Insert(T model)
        {
            HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model));
        }
        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
        }
        public virtual void Delete(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            HelperDAO.ExecutaProc("spDelete", p);
        }
        public virtual T Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
        public virtual int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0][0]);
        }
        public virtual List<T> Listagem()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", Tabela),
                new SqlParameter("Ordem", "1") // 1 é o primeiro campo da tabela
            };
            var tabela = HelperDAO.ExecutaProcSelect(NomeSpListagem, p);
            List<T> lista = new List<T>();
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }
        //================================================ TABELAS ===========================================================
        /*
        --CREATE DATABASE iKnow

         

        USE iKnow

         


        CREATE TABLE Clientes
        (
        Id INT IDENTITY(1,1) NOT NULL primary key,
        CPF varchar(20) NOT NULL,
        Nome varchar(max),
        DataNascimento datetime NOT NULL,
        Estado varchar(100),
        Cidade varchar(100)
        )

         

        CREATE TABLE Funcionarios
        (
        Id INT IDENTITY(1,1) NOT NULL primary key,
        CPF varchar(20) NOT NULL,
        Nome varchar(max),
        DataNascimento datetime NOT NULL,
        Salario decimal (10,2),
        Cargo varchar(max),
        Estado varchar(100),
        Cidade varchar(100)
        )

         

        CREATE TABLE Produtos
        (
        Id INT IDENTITY(1,1) NOT NULL primary key,
        Nome varchar(max),
        Preco decimal(10, 2),
        QuantidadeDisponivel int
        )

         

        CREATE TABLE Compras
        (
        Id INT IDENTITY(1,1) NOT NULL primary key,
        IdCliente INT NOT NULL,
        ValorTotal decimal(10,2),
        DataCompra datetime

         

        CONSTRAINT FK_Compras_IdCliente FOREIGN KEY (IdCliente) REFERENCES Clientes(Id)
        )

         

        CREATE TABLE ItensCompra
        (
        Id INT IDENTITY(1,1) NOT NULL primary key,
        IdCompra int NOT NULL,
        IdProduto int NOT NULL,
        QuantidadeProduto int

         

        CONSTRAINT FK_ItensCompra_IdCompra FOREIGN KEY (IdCompra) REFERENCES Compras(Id),
        CONSTRAINT FK_ItensCompra_IdProduto FOREIGN KEY (IdProduto) REFERENCES Produtos(Id)
        )
        */




        //================================================ Procs ===========================================================
        /*
        Create procedure spDelete
        (
        @id int ,
        @tabela varchar(max)
        )
        as
        begin
        declare @sql varchar(max);
        set @sql = ' delete ' + @tabela +
        ' where id = ' + cast(@id as varchar(max))
        exec(@sql)
        end
        GO

         

        create procedure spConsulta
        (
        @id int ,
        @tabela varchar(max)
        )
        as
        begin
        declare @sql varchar(max);
        set @sql = 'select * from ' + @tabela +
        ' where id = ' + cast(@id as varchar(max))
        exec(@sql)
        end
        GO

         

        create procedure spListagem
        (
        @tabela varchar(max),
        @ordem varchar(max))
        as
        begin
        exec('select * from ' + @tabela +
        ' order by ' + @ordem)
        end
        GO

         

        create procedure spProximoId
        (@tabela varchar(max))
        as
        begin
        exec('select isnull(max(id) +1, 1) as MAIOR from '
        + @tabela)
        end
        GO;
        */
    }
}
