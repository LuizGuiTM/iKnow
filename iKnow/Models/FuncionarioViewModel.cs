using System;

namespace iKnow.Models
{
    public partial class FuncionarioViewModel: PadraoViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }

        public double Salario { get; set; }

        public string Cargo { get; set; }

        public DateTime DataNasc { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
        public string Senha { get; set; }

    }
}