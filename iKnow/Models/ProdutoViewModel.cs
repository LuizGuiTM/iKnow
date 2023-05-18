using System;
﻿using Microsoft.AspNetCore.Http;

namespace iKnow.Models
{
    public partial class ProdutoViewModel: PadraoViewModel
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        public int QtdDisponivel { get; set; }
                
                    public string Categoria { get; set; }

        public IFormFile Imagem { get; set; }

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
    }
}
