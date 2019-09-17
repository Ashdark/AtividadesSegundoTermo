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
    public class LivrosController : ControllerBase
    {
        LivroRepository LivroRepositorio = new LivroRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LivroRepositorio.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar (LivroDomain Livro)
        {
            LivroRepositorio.Cadastrar(Livro);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            LivroDomain livro = LivroRepositorio.BuscarId(id);
            if(livro == null)
            {
                return NotFound();
            } return Ok(livro);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, LivroDomain Livro)
        {
            LivroRepositorio.Atualizar(id, Livro);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LivroRepositorio.Deletar(id);
            return Ok();
        }
    }
}