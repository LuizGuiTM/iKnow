using System.Data.SqlClient;
using System.Data;
using System;

namespace iKnow.DAO
{
    internal static class HelperDAO
    {
        public static void ExecutaSQL(
                    string sql,
                    SqlParameter[] parametros)
        {
            using (var conexao = ConexaoBD.GetConexao())
            {
                using (var comando = new SqlCommand(sql, conexao))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ExecutaSelect(string sql,
                                              SqlParameter[] parametros)
        {
            using (var cx = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    DataTable tabela = new DataTable();
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    adapter.Fill(tabela);
                    return tabela;
                }
            }
        }

        public static object NullAsDbNull(object valor)
        {
            if (valor == null)
                return DBNull.Value;
            else
                return valor;
        }


        public static void ExecutaProc(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(nomeProc, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabela = new DataTable();
                    if (tabela != null)
                    {
                        adapter.Fill(tabela);
                    }
                    return tabela;
                }
            }
        }



		/*
         --CREATE DATABASE

CREATE DATABASE iKnow  
GO
USE iKnow
GO

--DROP TABLES

DROP TABLE Clientes;
GO
DROP TABLE Funcionarios;
GO
DROP TABLE Produtos;
GO
DROP TABLE Compras;
GO
DROP TABLE ItensCompra;
GO

--CREATE TABLES

CREATE TABLE Clientes (
	 Id INT NOT NULL PRIMARY KEY
	,CPF VARCHAR(20) NOT NULL
	,Nome VARCHAR(max)
	,DataNascimento DATETIME NOT NULL
	,Estado VARCHAR(100)
	,Cidade VARCHAR(100)
	,Desconto FLOAT
	,Credito FLOAT
	,Documento VARBINARY(MAX)
	)
GO

CREATE TABLE Funcionarios (
	 Id INT NOT NULL PRIMARY KEY
	,CPF VARCHAR(20) NOT NULL
	,Nome VARCHAR(max)
	,DataNascimento DATETIME NOT NULL
	,Salario DECIMAL(10, 2)
	,Cargo VARCHAR(max)
	,Estado VARCHAR(100)
	,Cidade VARCHAR(100)
	,Senha VARCHAR(max)
	)  
GO

CREATE TABLE Produtos (
	 Id INT NOT NULL PRIMARY KEY
	,Nome VARCHAR(max)
	,Categoria VARCHAR(100)
	,Preco DECIMAL(10, 2)
	,QuantidadeDisponivel INT
	,Imagem VARBINARY(max)
	)  
GO

CREATE TABLE Compras (
	 Id INT NOT NULL PRIMARY KEY
	,IdCliente INT NOT NULL
	,ValorTotal DECIMAL(10, 2)
	,DataCompra DATETIME 
	,CONSTRAINT FK_Compras_IdCliente FOREIGN KEY (IdCliente) REFERENCES Clientes(Id)
	)  
GO


CREATE TABLE ItensCompra (
	 Id INT NOT NULL PRIMARY KEY
	,IdCompra INT NOT NULL
	,IdProduto INT NOT NULL
	,QuantidadeProduto INT   
	,CONSTRAINT FK_ItensCompra_IdCompra FOREIGN KEY (IdCompra) REFERENCES Compras(Id)
	,CONSTRAINT FK_ItensCompra_IdProduto FOREIGN KEY (IdProduto) REFERENCES Produtos(Id)
	)
GO


--PROCEDURES

CREATE PROCEDURE spInsert_Clientes (
	 @Id INT
	,@CPF VARCHAR(20)
	,@Nome VARCHAR(max)
	,@DataNascimento DATETIME
	,@Estado VARCHAR(100)
	,@Cidade VARCHAR(100)
	,@Desconto FLOAT
	,@Credito FLOAT
	,@Documento VARBINARY(MAX)
	)
AS
BEGIN
	INSERT INTO Clientes (
		 Id
		,CPF
		,Nome
		,DataNascimento
		,Estado
		,Cidade
		,Desconto
		,Credito
		,Documento
		)
	VALUES (
		 @Id
		,@CPF
		,@Nome
		,@DataNascimento
		,@Estado
		,@Cidade
		,@Desconto
		,@Credito
		,@Documento
		)
END
GO

CREATE PROCEDURE spUpdate_Clientes (
	 @Id INT
	,@CPF VARCHAR(20)
	,@Nome VARCHAR(max)
	,@DataNascimento DATETIME
	,@Estado VARCHAR(100)
	,@Cidade VARCHAR(100)
	,@Desconto FLOAT
	,@Credito FLOAT
	,@Documento VARBINARY(MAX)
	)
AS
BEGIN
	UPDATE Clientes
	SET CPF = @CPF
		,Nome = @Nome
		,DataNascimento = @DataNascimento
		,Estado = @Estado
		,Cidade = @Cidade
		,Desconto = @Desconto
		,Credito = @Credito
		,Documento = @Documento
	WHERE Id = @Id
END
GO

CREATE PROCEDURE spInsert_Funcionarios (
	 @Id INT
	,@CPF VARCHAR(20)
	,@Nome VARCHAR(max)
	,@DataNascimento DATETIME
	,@Salario DECIMAL(10, 2)
	,@Cargo VARCHAR(max)
	,@Estado VARCHAR(100)
	,@Cidade VARCHAR(100)
	,@Senha VARCHAR(max)
	)
AS
BEGIN
	INSERT INTO Funcionarios (
		 Id
		,CPF
		,Nome
		,DataNascimento
		,Salario
		,Cargo
		,Estado
		,Cidade
		,Senha
		)
	VALUES (
		 @Id
		,@CPF
		,@Nome
		,@DataNascimento
		,@Salario
		,@Cargo
		,@Estado
		,@Cidade
		,@Senha
		)
END
GO


CREATE PROCEDURE spUpdate_Funcionarios (
	 @Id INT
	,@CPF VARCHAR(20)
	,@Nome VARCHAR(max)
	,@DataNascimento DATETIME
	,@Salario DECIMAL(10, 2)
	,@Cargo VARCHAR(max)
	,@Estado VARCHAR(100)
	,@Cidade VARCHAR(100)
	,@Senha VARCHAR(max)
	)
AS
BEGIN
	UPDATE Funcionarios
	SET CPF = @CPF
		,Nome = @Nome
		,DataNascimento = @DataNascimento
		,Salario = @Salario
		,Cargo = @Cargo
		,Estado = @Estado
		,Cidade = @Cidade
		,Senha = @Senha
	WHERE Id = @Id
END
GO


CREATE PROCEDURE spInsert_Produtos (
	 @Id INT
	,@Nome VARCHAR(max)
	,@Categoria VARCHAR(100)
	,@Preco DECIMAL(10, 2)
	,@QuantidadeDisponivel INT
	,@Imagem VARBINARY(max)
	)
AS
BEGIN
	INSERT INTO Produtos (
		Id
		,Nome
		,Categoria
		,Preco
		,QuantidadeDisponivel
		,Imagem
		)
	VALUES (
		 @Id
		,@Nome
		,@Categoria
		,@Preco
		,@QuantidadeDisponivel
		,@Imagem
		)
END
GO

CREATE PROCEDURE spUpdate_Produtos (
	 @Id INT
	,@Nome VARCHAR(max)
	,@Categoria VARCHAR(100)
	,@Preco DECIMAL(10, 2)
	,@QuantidadeDisponivel INT
	,@Imagem VARBINARY(max)
	)
AS
BEGIN
	UPDATE Produtos
	SET Nome = @Nome
		,Categoria = @Categoria
		,Preco = @Preco
		,QuantidadeDisponivel = @QuantidadeDisponivel
		,Imagem = @Imagem
	WHERE Id = @Id
END
GO



CREATE PROCEDURE spInsert_Compras (
	 @Id INT
	,@IdCliente INT
	,@ValorTotal DECIMAL(10, 2)
	,@DataCompra DATETIME
	)
AS
BEGIN
	INSERT INTO Compras (
		Id
		,IdCliente
		,ValorTotal
		,DataCompra
		)
	VALUES (
		@Id
		,@IdCliente
		,@ValorTotal
		,@DataCompra
		)
END
GO

CREATE PROCEDURE spUpdate_Compras (
	 @Id INT
	,@IdCliente INT
	,@ValorTotal DECIMAL(10, 2)
	,@DataCompra DATETIME
	)
AS
BEGIN
	UPDATE Compras
	SET IdCliente = @IdCliente
		,ValorTotal = @ValorTotal
		,DataCompra = @DataCompra
	WHERE Id = @Id
END
GO


CREATE PROCEDURE spInsert_ItensCompra (
	 @Id INT
	,@IdCompra INT
	,@IdProduto INT
	,@QuantidadeProduto INT
	)
AS
BEGIN
	INSERT INTO ItensCompra (
		 Id
		,IdCompra
		,IdProduto
		,QuantidadeProduto
		)
	VALUES (
		@Id
		,@IdCompra
		,@IdProduto
		,@QuantidadeProduto
		)
END
GO

CREATE PROCEDURE spUpdate_ItensCompra (
	 @Id INT
	,@IdCompra INT
	,@IdProduto INT
	,@QuantidadeProduto INT
	)
AS
BEGIN
	UPDATE ItensCompra
	SET IdCompra = @IdCompra
		,IdProduto = @IdProduto
		,QuantidadeProduto = @QuantidadeProduto
	WHERE Id = @Id
END
GO

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
GO

CREATE PROCEDURE spConsultaCPF (
    @Cpf VARCHAR(max)
    ,@tabela VARCHAR(max)
    )
AS
BEGIN
    DECLARE @sql VARCHAR(max);

    SET @sql = 'select * from ' + @tabela + ' where Cpf = ' + CHAR(39) + @Cpf + CHAR(39)

    EXEC (@sql)
END
GO

create procedure [dbo].[spConsultaAvancadaProdutos]
(
 @nome varchar(max),
@categoria varchar(max),
@precoInicial float,
@precoFinal float)
as
begin
 select produtos.Id, produtos.Nome,Produtos.Categoria, Produtos.Preco, Produtos.QuantidadeDisponivel
from produtos
where produtos.Nome like '%' + @nome + '%' and
 Produtos.Preco between @precoInicial and @precoFinal and
 Produtos.Categoria like '%' + @categoria + '%';
end
GO

Create procedure [dbo].[spConsultaAvancadaClientes]
(
     @nome varchar(max),
    @cpf varchar(max),
    @descontoInicial float,
    @descontoFinal float)
as
begin
 select clientes.Id, clientes.Nome,clientes.CPF,clientes.DataNascimento,Clientes.Documento, Clientes.Cidade, clientes.Estado, Clientes.Credito, clientes.Desconto
from clientes
where clientes.Nome like '%' + @nome + '%' and
 clientes.Desconto between @descontoInicial and @descontoFinal and
 clientes.CPF like '%' + @cpf + '%';
end
         
         
 --Quantidade de funcionarios por estado (Bar Graph)
select count(id) as 'Value', Estado as 'Label' from Funcionarios group by Estado

--Quantiadade de produtos por Categoria (Pie Graph)
select count(id) as 'Value', Categoria as 'Label' from Produtos group by categoria

--Quantiadade disponivel de produtos por Categoria (Donut Graph)
select sum(QuantidadeDisponivel) as 'Value', Categoria as 'Label' from Produtos group by categoria

         */
	}
}
