using Senai.WebApi.AutoPecasManha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.AutoPecasManha.Interfaces
{
    public interface IPeca
    {
        List<Pecas> Listar();
        void Cadastrar(Pecas peca);
        Pecas BuscarPorId(int id);
        void Deletar(int id);
        void Atualizar(Pecas peca);
    }
}
