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
    public class AutoresController : ControllerBase
    {
        AutorRepository AutorRepositorio = new AutorRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(AutorRepositorio.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(AutorDomain Autor)
        {
            AutorRepositorio.Cadastrar(Autor);
            return Ok();
        }
        [HttpGet("{id}/livros")]
        public IActionResult BuscarPorAutorId (int id)
        {
            return Ok(AutorRepositorio.BuscaPorAutor(id));
        }
        [HttpGet("Ativo")]
        public IActionResult Ativo()
        {
            return Ok(AutorRepositorio.ListarAutoresAtivos());
        }
        [HttpGet("{id}/ativos/livros")]
        public IActionResult AtivoIdAutor(int id)
        {
            return Ok(AutorRepositorio.BuscaPorAutorEAtivo(id));
        }
        [HttpGet("{AnoNascimento}/nascimento")]
        public IActionResult BuscarPorDataNascimento(DateTime DataNascimento)
        {
            return Ok(AutorRepositorio.DataSuperior(DataNascimento));
        }

    }
}