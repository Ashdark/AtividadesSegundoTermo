using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Manha.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
        //Caso precise :)
        public GeneroDomain Genero { get; set; }
    }
}
