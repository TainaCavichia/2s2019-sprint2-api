using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private IFornecedorRepository FornecedorRepository { get; set; }

        public FornecedoresController()
        {
            FornecedorRepository = new FornecedorRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FornecedorRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Fornecedores fornecedor = FornecedorRepository.BuscarPorId(id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Cadastrar(Fornecedores fornecedor)
        {
            try
            {
                FornecedorRepository.Cadastrar(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Vish" + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Fornecedores fornecedor)
        {
            try
            {
                Fornecedores FornecedorBuscado = FornecedorRepository.BuscarPorId(fornecedor.FornecedorId);

                if (FornecedorBuscado == null)
                    return NotFound();

                FornecedorRepository.Atualizar(fornecedor);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FornecedorRepository.Deletar(id);
            return Ok();
        }
    }
}