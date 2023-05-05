using System;

namespace iKnow.Models
{
    public abstract class CompraViewModel: PadraoViewModel
    {
        public int IdCliente { get; set; }

        public double ValorTotal { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
