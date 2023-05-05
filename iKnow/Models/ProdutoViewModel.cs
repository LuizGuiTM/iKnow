namespace iKnow.Models
{
    public partial class ProdutoViewModel: PadraoViewModel
    {
        public string Descricao { get; set; }

        public double Preco { get; set; }

        public int QtdDisponivel { get; set; }
    }
}
