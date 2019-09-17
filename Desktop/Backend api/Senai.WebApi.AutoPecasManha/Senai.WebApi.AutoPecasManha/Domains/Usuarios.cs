using System;
using System.Collections.Generic;

namespace Senai.WebApi.AutoPecasManha.Domains
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Fornecedores Fornecedores { get; set; }
    }
}
