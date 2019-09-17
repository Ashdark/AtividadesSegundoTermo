using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manha.BookStore.WebApi.Domains;
using Manha.BookStore.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manha.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepositorio = new GeneroRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(GeneroRepositorio.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain Genero)
        {
            GeneroRepositorio.Cadastrar(Genero);
            return Ok();
        }
        [HttpGet("buscar/{nome}/livros")]
        public IActionResult BuscarPorNomeGenero (string nome)
        {
            return Ok(GeneroRepositorio.BuscaPorGenero(nome));
        }
    }
}