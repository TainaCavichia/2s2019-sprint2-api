using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();

        [Authorize(Roles = "COMUM")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepository.Listar());
        }
        [Authorize(Roles = "COMUM")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos estilo = estiloRepository.BuscarPorId(id);
            if (estilo == null)
            {
                return NotFound();
            }
            return Ok(estilo);
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                estiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepository.Deletar(id);
            return Ok();
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos EstiloBuscado = estiloRepository.BuscarPorId(estilo.IdEstilo);

                if (EstiloBuscado == null)
                    return NotFound();

                estiloRepository.Atualizar(estilo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
