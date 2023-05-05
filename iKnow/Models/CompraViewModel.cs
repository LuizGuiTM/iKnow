using System;

namespace iKnow.Models
{
    public partial class CompraViewModel: PadraoViewModel
    {
        public int IdCliente { get; set; }

        public double ValorTotal { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
