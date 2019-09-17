using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers { 
[Produces ("application/json")]
[Route("api/[controller]")]
[ApiController]
    public class FilmesController : ControllerBase
    {
        FilmeRepository filmeRepository = new FilmeRepository();
        [HttpGet]
        public IEnumerable<FilmeDomain> Listar()
        {

            return filmeRepository.ListarTodos();

        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            FilmeDomain genero = filmeRepository.ListarPorId(id);
            if (genero == null)
            {
                return NotFound();
            } return Ok();
        }
    }
}