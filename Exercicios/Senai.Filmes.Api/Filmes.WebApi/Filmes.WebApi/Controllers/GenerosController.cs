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

    public class GenerosController : ControllerBase
    {
        List<GenerosDomain> generos = new List<GenerosDomain>();

        GenerosRepository generosRepository = new GenerosRepository();

        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {

        }
    }
}
