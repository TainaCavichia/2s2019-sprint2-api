using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        
        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(x => x.Type == ClaimTypes.Role))
            {
                var permissao = currentUser.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                int id = Convert.ToInt32(currentUser.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                if ( permissao == "ADMINISTRADOR")
                {
                    return Ok(funcionarioRepository.Listar());
                }
                else if (permissao == "COMUM")
                {
                    return Ok(funcionarioRepository.ListarPorId(id));
                }
            }
            return BadRequest();
        }

        [Authorize(Roles = "COMUM")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios funcionario = funcionarioRepository.BuscarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }
        [Authorize(Roles = "COMUM")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            try
            {
                funcionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }
        [Authorize(Roles = "COMUM")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }
        [Authorize(Roles = "COMUM")]
        [HttpPut]
        public IActionResult Atualizar(Funcionarios funcionario)
        {
            try
            {
                Funcionarios funcionarioBuscado = funcionarioRepository.BuscarPorId(funcionario.IdFuncionario);

                if (funcionarioBuscado == null)
                    return NotFound();

                funcionarioRepository.Atualizar(funcionario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
