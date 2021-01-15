using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Models.Response;
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

        [HttpGet("all")]
        public async Task<ActionResult<List<GrupoGraduadoResponse>>> Get()
        {
            var grupos = await _serviceQuery.GetAll("Curso");
            return Ok(grupos);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<GrupoGraduadoResponse>>> GetPaged([FromQuery] PaginationFilter paginationFilter)
        {
            if (paginationFilter == null || paginationFilter.PageNumber == 0 || paginationFilter.PageSize == 0)
            {
                paginationFilter.PageNumber = 1;
                paginationFilter.PageSize = 10;
            }

            if (paginationFilter.PageNumber < 0 || paginationFilter.PageSize < 0)
            {
                return BadRequest();
            }
                    
            var grupos = await _serviceQuery.GetAllPaged(paginationFilter);
            
            if(grupos == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(grupos);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoGraduadoResponse>> Get(int id)
        {
            var grupo = await _serviceQuery.GetById(id, "Curso");
            if (grupo != null)
            {
                return Ok(grupo);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("sum_graduados/{year}")]
        public async Task<ActionResult> GetSumGraduados(int year)
        {
            DateTime date = new DateTime(year,1,1);
            var data = await _serviceQuery.GetSumGraduadosByCursoAndYear(date);
            if(data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }
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
