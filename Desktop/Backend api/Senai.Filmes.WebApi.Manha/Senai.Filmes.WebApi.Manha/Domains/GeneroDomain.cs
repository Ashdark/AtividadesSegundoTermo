using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Manha.Domains
{
    public class GeneroDomain
    {
        public int IdGenero { get; set; }
        [Required (ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

    }
}
