using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Models.Response;
using Proyecto.Domain.Services.Commands;
using Proyecto.Domain.Services.Querys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CursosController : ControllerBase
    {
        private readonly ICursoServiceQuery _serviceQuery;
        private readonly ICursoServiceCommand _serviceCommand;

        public CursosController(ICursoServiceQuery serviceQuery, ICursoServiceCommand serviceCommand)
        {
            _serviceQuery = serviceQuery;
            _serviceCommand = serviceCommand;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoResponse>>> Get()
        {
            var cursos = await _serviceQuery.GetAll();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoResponse>> Get(int id)
        {
            var curso = await _serviceQuery.GetById(id);
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CursoRequest cursoRequest)
        {
            var cursoSaved = await _serviceCommand.Save(cursoRequest);
            if(cursoSaved)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CursoRequest cursoRequest)
        {
            var cursoUpdated = await _serviceCommand.Update(id, cursoRequest);
            if(cursoUpdated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cursoDeleted = await _serviceCommand.Delete(id);
            if(cursoDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
