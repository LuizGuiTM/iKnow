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

        public IFormFile Documento { get; set; }

        public byte[] DocumentoEmByte { get; set; }
        /// <summary> /// Imagem usada para ser enviada ao form no formato para ser exibida /// </summary> 
        public string DocumentoEmBase64
        {
            get
            {
                if (DocumentoEmByte != null)
                    return Convert.ToBase64String(DocumentoEmByte);
                else
                    return string.Empty;
            }
        }
    }
}
}
