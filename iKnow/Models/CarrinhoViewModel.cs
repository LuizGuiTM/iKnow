using System;

namespace iKnow.Models
{
    public class CarrinhoViewModel
    {
        public int IdProduto { get; set; }

        public int QtdProduto { get; set; }

        public double Preco { get; set; }

        public byte[] ImagemEmByte { get; set; }

        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }

        public string Nome { get; set; }

        public string Categoria { get; set; }
    }
}
