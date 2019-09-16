using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples.Domains
{
    public class FDomain
    {
        public int IdFuncionario { get; set; }
        [Required (ErrorMessage = "Precisa de nome fi, preenche ai")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Precisa de nome fi, preenche ai")]
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
