using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manha.BookStore.WebApi.Domains
{
    public class LivroDomain
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }
        public GeneroDomain Genero { get; set; }
        public AutorDomain Autor { get; set; }
    }
}
