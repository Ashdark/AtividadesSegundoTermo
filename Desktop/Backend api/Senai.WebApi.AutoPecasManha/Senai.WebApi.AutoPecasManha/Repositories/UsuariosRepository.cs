using Senai.WebApi.AutoPecasManha.Domains;
using Senai.WebApi.AutoPecasManha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.AutoPecasManha.Repositories
{
    public class UsuariosRepository : IUsuario
    {
        public void Cadastrar(Usuarios usuario)
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
