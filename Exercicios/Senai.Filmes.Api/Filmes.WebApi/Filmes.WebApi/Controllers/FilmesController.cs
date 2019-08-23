using Filmes.WebApi.Domains;
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
    public class FilmesController : ControllerBase
    {
        FilmesRepository filmesRepository = new FilmesRepository();

        [HttpGet]
        public IEnumerable<FilmesDomain> Listar()
        {
            return filmesRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FilmesDomain filme = filmesRepository.BuscarPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
           
        }
        [HttpPost]
        public IActionResult Cadastrar(FilmesDomain filmes)
        {
            try
            {
                filmesRepository.Cadastrar(filmes);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }

           
        }


    }
}
