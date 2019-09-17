using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.AutoPecasManha.Domains;
using Senai.WebApi.AutoPecasManha.Interfaces;
using Senai.WebApi.AutoPecasManha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.AutoPecasManha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PecasController : ControllerBase
    {
        private IPeca PecasRepositorio { get; set; }
        public PecasController()
        {
            PecasRepositorio = new PecasRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepositorio.Listar());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(PecasRepositorio.BuscarPorId(id));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            PecasRepositorio.Cadastrar(peca);
            return Ok();
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,Pecas peca)
        {
            peca.PecaId = id;
            PecasRepositorio.Atualizar(peca);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecasRepositorio.Deletar(id);
            return Ok();
        }
    }
}
