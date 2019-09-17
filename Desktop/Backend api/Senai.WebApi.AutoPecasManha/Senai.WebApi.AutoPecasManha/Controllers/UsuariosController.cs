using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.AutoPecasManha.Interfaces;
using Senai.WebApi.AutoPecasManha.Repositories;

namespace Senai.WebApi.AutoPecasManha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private IUsuario usuariosRepository { get; set; }
        public UsuariosController()
        {
            usuariosRepository = new UsuariosRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuariosRepository.Listar());
        }
    }
}