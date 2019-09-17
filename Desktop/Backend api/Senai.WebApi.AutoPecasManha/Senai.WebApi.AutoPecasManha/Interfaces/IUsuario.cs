using Senai.WebApi.AutoPecasManha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.AutoPecasManha.Interfaces
{
    interface IUsuario
    {
        List<Usuarios> Listar();
        void Cadastrar(Usuarios usuario);
    }
}
