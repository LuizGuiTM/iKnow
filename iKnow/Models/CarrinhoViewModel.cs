﻿namespace iKnow.Models
{
    public class CarrinhoViewModel
    {
        public int IdProduto { get; set; }

        public int QtdProduto { get; set; }

        public double Preco { get; set; }

        public string ImagemEmBase64 { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }
    }
}
