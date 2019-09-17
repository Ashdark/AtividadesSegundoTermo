using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.WebApi.AutoPecasManha.Domains
{
    public partial class Pecas
    {
        public int PecaId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public float Peso { get; set; }
        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }
        [Required]
        public int FornecedorId { get; set; }

        public Fornecedores Fornecedor { get; set; }
    }
}
