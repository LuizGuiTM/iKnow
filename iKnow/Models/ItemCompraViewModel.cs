namespace iKnow.Models
{
    public abstract class ItemCompraViewModel : PadraoViewModel
    {
        public int IdCompra { get; set; }

        public int IdProduto { get; set; }

        public int QtdProduto{ get; set; }

    }
}
