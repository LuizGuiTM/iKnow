using System;

namespace iKnow.Models
{
    public partial class ClienteViewModel: PadraoViewModel
    {
        /*        CREATE TABLE Clientes
        (
        Id INT IDENTITY(1,1) NOT NULL primary key,
        CPF varchar(20) NOT NULL,
        Nome varchar(max),
        DataNascimento datetime NOT NULL,
        Estado varchar(100),
        Cidade varchar(100)
        )
        */

        public string Cpf { get; set; }
        public string Nome { get; set; }

        public DateTime DataNasc { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }
}
