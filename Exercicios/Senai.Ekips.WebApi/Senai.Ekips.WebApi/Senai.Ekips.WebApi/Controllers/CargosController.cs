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
    public class CargosController : ControllerBase
    {
        CargoRepository cargoRepository = new CargoRepository();

        [Authorize(Roles = "COMUM")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepository.Listar());
        }
        [Authorize(Roles = "COMUM")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos cargo = cargoRepository.BuscarPorId(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return Ok(cargo);
        }
        [Authorize(Roles = "COMUM")]
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                cargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }
        [Authorize(Roles = "COMUM")]
        [HttpPut]
        public IActionResult Atualizar(Cargos cargo)
        {
            try
            {
                Cargos CargoBuscado = cargoRepository.BuscarPorId(cargo.IdCargo);

                if (CargoBuscado == null)
                    return NotFound();

                cargoRepository.Atualizar(cargo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
