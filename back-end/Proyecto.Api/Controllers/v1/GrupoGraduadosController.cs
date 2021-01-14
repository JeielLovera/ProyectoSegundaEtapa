using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Services.Commands;
using Proyecto.Domain.Services.Querys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GrupoGraduadosController : ControllerBase
    {
        private readonly IGrupoGraduadoServiceQuery _serviceQuery;
        private readonly IGrupoGraduadoServiceCommand _serviceCommand;

        public GrupoGraduadosController(IGrupoGraduadoServiceQuery serviceQuery, IGrupoGraduadoServiceCommand serviceCommand)
        {
            _serviceQuery = serviceQuery;
            _serviceCommand = serviceCommand;
        }

        [HttpGet]
        public async Task<ActionResult<List<GrupoGraduado>>> Get()
        {
            var grupos = await _serviceQuery.GetAll("Curso");
            return Ok(grupos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoGraduado>> Get(int id)
        {
            var grupo = await _serviceQuery.GetById(id, "Curso");
            return Ok(grupo);
        }

        [HttpGet("sum_graduados/{year}")]
        public async Task<ActionResult<GrupoGraduado>> GetSumGraduados(int year)
        {
            DateTime date = new DateTime(year,1,1);
            var data = await _serviceQuery.GetSumGraduadosByCursoAndYear(date);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GrupoGraduadoRequest grupoRequest)
        {
            var grupoSaved = await _serviceCommand.Save(grupoRequest);
            if (grupoSaved)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GrupoGraduadoRequest grupoRequest)
        {
            var grupoUpdated = await _serviceCommand.Update(id, grupoRequest);
            if (grupoUpdated)
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
            var grupoDeleted = await _serviceCommand.Delete(id);
            if (grupoDeleted)
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
