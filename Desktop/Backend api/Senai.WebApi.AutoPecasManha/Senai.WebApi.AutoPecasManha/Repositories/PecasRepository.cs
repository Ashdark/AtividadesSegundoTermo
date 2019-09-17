using Senai.WebApi.AutoPecasManha.Domains;
using Senai.WebApi.AutoPecasManha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.AutoPecasManha.Repositories
{
    public class PecasRepository : IPeca
    {
        public void Atualizar(Pecas peca)
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                Pecas pecabuscada = ctx.Pecas.Find(peca.PecaId);
                pecabuscada.Peso = peca.Peso;
                pecabuscada.Fornecedor = peca.Fornecedor;
                pecabuscada.Codigo = peca.Codigo;
                pecabuscada.Descricao = peca.Descricao;
                pecabuscada.PrecoCusto = peca.PrecoCusto;
                pecabuscada.PrecoVenda = peca.PrecoVenda;
                ctx.Pecas.Update(pecabuscada);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                return ctx.Pecas.Find(id);
            }
        }

        public void Cadastrar(Pecas peca)
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutopecasContext ctx = new AutopecasContext())
            {
                ctx.Pecas.Remove(ctx.Pecas.FirstOrDefault(x => x.PecaId == id));
                ctx.Pecas.Remove(ctx.Pecas.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using(AutopecasContext ctx = new AutopecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}
