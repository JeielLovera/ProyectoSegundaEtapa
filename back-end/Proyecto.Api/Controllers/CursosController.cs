using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Repository;

namespace Proyecto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoRepository _repository;

        public CursosController(ICursoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            var cursos = await _repository.GetAll();
            return Ok(cursos);
        }
    }
}