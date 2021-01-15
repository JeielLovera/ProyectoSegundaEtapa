using AutoMapper;
using Proyecto.Domain.Models.Response;
using Proyecto.Domain.Services.Querys;
using Proyecto.Infrastructure.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Proyecto.Domain.Models.Request;
using Microsoft.AspNetCore.WebUtilities;

namespace Proyecto.Application.ServicesImplementation.Querys
{
    public class GrupoGraduadoServiceQuery : IGrupoGraduadoServiceQuery
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrupoGraduadoServiceQuery(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IEnumerable<GrupoGraduadoResponse>> GetAll(string includeProperties = "")
        {
            var grupos = await _unitOfWork.grupoGraduadoRepository.Get(includeProperties: includeProperties);
            var gruposResponse = _mapper.Map<IEnumerable<GrupoGraduadoResponse>>(grupos);
            return gruposResponse;
        }

        public async Task<PagedResponse<GrupoGraduadoResponse>> GetAllPaged(PaginationFilter paginationFilter)
        {
            if(paginationFilter == null)
            {
                return null;
            }

            int skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            var grupos = await _unitOfWork.grupoGraduadoRepository.GetAllPaged(skip, paginationFilter.PageSize);

            if (grupos.Count() < 1 )
            {
                return null;
            }

            var gruposResponse = _mapper.Map<IEnumerable<GrupoGraduadoResponse>>(grupos);            

            var total = await _unitOfWork.grupoGraduadoRepository.GetCount();
            var maxPage = Math.Ceiling(total*1.0/ paginationFilter.PageSize);

            string nextPage;
            if(paginationFilter.PageNumber < maxPage)
            {
                nextPage = QueryHelpers.AddQueryString("GrupoGraduados", "pageNumber", (paginationFilter.PageNumber+1).ToString());
                nextPage = QueryHelpers.AddQueryString(nextPage, "pageSize", paginationFilter.PageSize.ToString());
            }
            else
            {
                nextPage = null;
            }

            string previousPage;
            if(paginationFilter.PageNumber > 1)
            {
                previousPage = QueryHelpers.AddQueryString("GrupoGraduados", "pageNumber", (paginationFilter.PageNumber - 1).ToString());
                previousPage = QueryHelpers.AddQueryString(previousPage, "pageSize", paginationFilter.PageSize.ToString());
            }
            else
            {
                previousPage = null;
            }

            return new PagedResponse<GrupoGraduadoResponse>
            {
                Data = gruposResponse,
                PageNumber = paginationFilter.PageNumber,
                PageSize = paginationFilter.PageSize,
                MaxPage = (int)maxPage,
                Total = total,
                NextPage = nextPage,
                PreviousPage = previousPage
            };


        }

        public async Task<GrupoGraduadoResponse> GetById(int id, string includeProperties = "")
        {
            var grupo = await _unitOfWork.grupoGraduadoRepository.Get(filter: x => x.Id == id, includeProperties: includeProperties);
            var grupoResponse = _mapper.Map<GrupoGraduadoResponse>(grupo.FirstOrDefault());
            return grupoResponse;
        }

        public async Task<IEnumerable<object>> GetSumGraduadosByCursoAndYear(DateTime date)
        {
            var data = await _unitOfWork.grupoGraduadoRepository.GetSumGraduadosByCursoAndYear(date);
            return data;
        }
    }
}
