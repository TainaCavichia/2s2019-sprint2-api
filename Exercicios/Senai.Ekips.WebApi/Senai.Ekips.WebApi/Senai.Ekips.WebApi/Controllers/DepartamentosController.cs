using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();

        [Authorize(Roles = "COMUM")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(departamentoRepository.Listar());
        }

        [Authorize(Roles = "COMUM")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamentos departamento = departamentoRepository.BuscarPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }
        [Authorize(Roles = "COMUM")]
        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                departamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }
    }
}
