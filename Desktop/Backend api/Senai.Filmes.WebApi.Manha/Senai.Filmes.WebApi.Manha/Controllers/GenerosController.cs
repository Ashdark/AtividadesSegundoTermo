using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Manha.Domains;
using Senai.Filmes.WebApi.Manha.Repositories;

namespace Senai.Filmes.WebApi.Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepositorio = new GeneroRepository ();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(GeneroRepositorio.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            GeneroDomain Genero = GeneroRepositorio.BuscarId(id);
            if (Genero == null)
            {
                return NotFound();
            } return Ok(Genero);
        }
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain Genero)
        {
            GeneroRepositorio.Cadastrar(Genero);
            return Ok();
        }
        [HttpPut("{id}/{nome}")]
        public IActionResult Editar(string nome, int id)
        {
            GeneroRepositorio.Editar(id,nome);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            GeneroRepositorio.Deletar(id);
            return Ok();
        }
    }
}