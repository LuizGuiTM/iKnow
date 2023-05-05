using System;

namespace iKnow.Models
{
    public partial class ClienteViewModel: PadraoViewModel
    {

        public string Cpf { get; set; }
        public string Nome { get; set; }

        public DateTime DataNasc { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }
}
