using System;

namespace iKnow.Models
{
    public partial class CompraViewModel: PadraoViewModel
    {
        //Para enviar e receber do SQL
        public int IdCliente { get; set; }

        public double ValorTotal { get; set; }
        public DateTime DataCompra { get; set; }

        //Somente para visualizar no site
        public double Desconto { get; set; }

        public string Nome { get; set; }
    }
}
