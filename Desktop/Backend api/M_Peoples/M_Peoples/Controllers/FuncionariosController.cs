using M_Peoples.Domains;
using M_Peoples.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace M_Peoples.Controllers
{
[Route ("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class FuncionariosController : ControllerBase
    {
        FRepository Frepository = new FRepository();

        [HttpGet]
        public IEnumerable<FDomain> ListarTodos()
        {
            return Frepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FDomain funcionario = Frepository.BuscarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            } return Ok(funcionario);
        }
        [HttpPost]
        public IActionResult Cadastrar (FDomain funcionario)
        {
            Frepository.Cadastrar(funcionario);

            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar (FDomain funcionario)
        {
            Frepository.Atualizar(funcionario);

            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Deletar (int Id)
        {
            Frepository.Deletar(Id);
            return Ok();
        }
        [HttpGet("nomescompletos")]
        public IEnumerable<NomescompletoVM> NomesCompletos()
        {
            return Frepository.NomesCompletos();
        }
        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome (string nome)
        {
            FDomain funcionario = Frepository.BuscarPorNome(nome);
            if (funcionario == null)
            {
                return NotFound();
            } return Ok(funcionario);
        }
        [HttpGet("ordenacao/{ordem}")]
        public IEnumerable<FDomain> Ordem(string ordem)
        {
            if (ordem.Equals("asc"))
            {
                return Frepository.Ordernar(ordem);
            } else if (ordem.Equals("desc"))
            {
                return Frepository.Ordernar(ordem);
            }
            return null;
        }
    }
}
