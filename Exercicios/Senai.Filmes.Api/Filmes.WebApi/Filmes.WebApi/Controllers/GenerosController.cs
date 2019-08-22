﻿using Filmes.WebApi.Domains;
using Filmes.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class GenerosController : ControllerBase
    {
        List<GenerosDomain> generos = new List<GenerosDomain>();

        GenerosRepository generosRepository = new GenerosRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(generosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(GenerosDomain generos)
        {
            try
            {
                generosRepository.Cadastrar(generos);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
        }
    }
}
