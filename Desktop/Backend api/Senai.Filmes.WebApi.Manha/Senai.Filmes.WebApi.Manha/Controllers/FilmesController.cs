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
    public class FilmesController : ControllerBase
    {
        FilmeRepository FilmeRepositorio = new FilmeRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeRepositorio.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(FilmeRepositorio.BuscarId(id));
        }
        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain Filme)
        {
            try
            {
                FilmeRepositorio.Cadastrar(Filme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro no sistema." + ex.Message });
            }
        }
    }
}