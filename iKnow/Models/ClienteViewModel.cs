using Microsoft.AspNetCore.Http;
using System;
using System.Data;

namespace iKnow.Models
{
    public partial class ClienteViewModel: PadraoViewModel
    {

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime DataNasc { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public double Desconto { get; set; }

        public double Credito { get; set; }

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

