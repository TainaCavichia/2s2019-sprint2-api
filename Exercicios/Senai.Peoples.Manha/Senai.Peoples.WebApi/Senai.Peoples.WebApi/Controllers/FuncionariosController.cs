using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository funcionariosRepository = new FuncionariosRepository();

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Listar()
        {
            return funcionariosRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionariosDomain Funcionario = funcionariosRepository.BuscarPorId(id);
            if (Funcionario == null)
            {
                return NotFound();
            }
            return Ok(Funcionario);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionariosRepository.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(FuncionariosDomain funcionarios, int id)
        {
            funcionarios.IdFuncionario = id;
            funcionariosRepository.Atualizar(funcionarios);
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionarios)
        {
            funcionariosRepository.Cadastrar(funcionarios);
            return Ok();
        }
    }
}
