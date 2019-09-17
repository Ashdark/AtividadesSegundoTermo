using Senai.WebApi.AutoPecasManha.Domains;
using Senai.WebApi.AutoPecasManha.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.AutoPecasManha.Repositories
{
    public class LoginRepository
    {
        public Usuarios Login(LoginViewModel login)
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                Usuarios usuariobuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if(usuariobuscado == null)
                {
                    return null;
                } return usuariobuscado;
            }
        }
    }
}
